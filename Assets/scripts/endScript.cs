using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class endScript : MonoBehaviour {

	public GameManager gm;
	public string GoodEndScene;
	public string BadEndScene;
	public string DryEndScene;
	public GameObject evilTree;
	public AudioSource asGood;
	public AudioSource asBad;
	private SpriteRenderer eTsr;
	private IEnumerator coroutine;
	// Use this for initialization
	void Start () {
		Debug.Log ("seed stage " + GameManager.GetSeedGrowth ());
		eTsr = evilTree.GetComponent<SpriteRenderer> ();
		eTsr.enabled = false;
		if (GameManager.IsGoodPlant ()) {
			Debug.Log ("good");
			asGood.Play ();
			coroutine = GetGoodEnd ();
			StartCoroutine (coroutine);
		}else if(GameManager.IsDryPlant()){
			Debug.Log ("dry");
			asBad.Play ();
			coroutine = GetDryEnd ();
			StartCoroutine (coroutine);
		} else {
			Debug.Log ("bad");
			asBad.Play ();
			coroutine = GetBadEnd ();
			StartCoroutine (coroutine);
		}
	}
	
	private IEnumerator GetGoodEnd(){
		yield return new WaitForSeconds (3);
		SceneManager.LoadSceneAsync (GoodEndScene, LoadSceneMode.Single);
	}

	private IEnumerator GetBadEnd(){
		eTsr.enabled = true;
		yield return new WaitForSeconds (3);
		SceneManager.LoadSceneAsync (BadEndScene, LoadSceneMode.Single);
	}

	private IEnumerator GetDryEnd(){
		yield return new WaitForSeconds (3);
		SceneManager.LoadSceneAsync (DryEndScene, LoadSceneMode.Single);
	}
}

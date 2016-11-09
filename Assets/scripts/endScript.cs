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
	public GameObject goodTree;
	public GameObject dryTree;
	private SpriteRenderer eTsr;
	private IEnumerator coroutine;
	// Use this for initialization
	void Start () {
		Debug.Log ("seed stage " + GameManager.GetSeedGrowth ());
		eTsr = evilTree.GetComponent<SpriteRenderer> ();
		eTsr.enabled = false;
		SpriteRenderer gtsr = goodTree.GetComponent<SpriteRenderer> ();
		SpriteRenderer dtsr = dryTree.GetComponent<SpriteRenderer> ();
		gtsr.enabled = false;
		dtsr.enabled = false;
		if (GameManager.IsGoodPlant ()) {
			Debug.Log ("good");
			gtsr.enabled = true;
			asGood.Play ();
			coroutine = GetGoodEnd ();
			StartCoroutine (coroutine);
		}else if(GameManager.IsDryPlant()){
			Debug.Log ("dry");
			dtsr.enabled = true;
			asBad.Play ();
			coroutine = GetDryEnd ();
			StartCoroutine (coroutine);
		} else {
			Debug.Log ("bad");
			eTsr.enabled = true;
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
		
		yield return new WaitForSeconds (3);
		SceneManager.LoadSceneAsync (BadEndScene, LoadSceneMode.Single);
	}

	private IEnumerator GetDryEnd(){
		yield return new WaitForSeconds (3);
		SceneManager.LoadSceneAsync (DryEndScene, LoadSceneMode.Single);
	}
}

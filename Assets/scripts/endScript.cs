using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class endScript : MonoBehaviour {

	public GameManager gm;
	public string GoodEndScene;
	public string BadEndScene;
	public GameObject evilTree;
	public AudioSource asGood;
	public AudioSource asBad;
	private SpriteRenderer eTsr;
	private IEnumerator coroutine;
	// Use this for initialization
	void Start () {
		eTsr = evilTree.GetComponent<SpriteRenderer> ();
		eTsr.enabled = false;
		if (GameManager.IsGoodPlant ()) {
			Debug.Log ("good");
			asGood.Play ();
			coroutine = GetGoodEnd ();
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
		yield return new WaitForSeconds (2);
		eTsr.enabled = true;
		yield return new WaitForSeconds (3);
		SceneManager.LoadSceneAsync (BadEndScene, LoadSceneMode.Single);
	}
}

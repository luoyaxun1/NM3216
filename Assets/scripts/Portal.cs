using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour {

	public string otherScene;
	// Use this for initialization
	void OnTriggerEnter2D(Collider2D other){
		Debug.Log ("enter: " + otherScene);
		SceneManager.LoadSceneAsync (otherScene, LoadSceneMode.Single);
	}

}

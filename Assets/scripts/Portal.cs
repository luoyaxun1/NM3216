using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour {

	public string otherScene;
	public int nextSeedGrowth;
	public int nextLevel;
	// Use this for initialization
	void OnTriggerEnter2D(Collider2D other){
		Debug.Log ("enter: " + otherScene);
		GameManager.SetSeedGrowth (nextSeedGrowth);
		GameManager.SetLevel (nextLevel);
		SceneManager.LoadSceneAsync (otherScene, LoadSceneMode.Single);
	}

}

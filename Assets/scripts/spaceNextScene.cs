using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class spaceNextScene : MonoBehaviour {

	public string newScene;
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Space)) {
			Debug.Log ("pressed space");
			SceneManager.LoadSceneAsync (newScene, LoadSceneMode.Single);
		}
	}
}

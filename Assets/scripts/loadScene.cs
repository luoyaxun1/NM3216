using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class loadScene : MonoBehaviour {
	public string otherScene;
	void Update(){
		if (Input.GetKey (KeyCode.Space)) {
			SceneManager.LoadSceneAsync (otherScene, LoadSceneMode.Single);

		}
	}
}

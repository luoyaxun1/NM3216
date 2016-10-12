using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class cave : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.CompareTag ("Player")) {
			//colided with player
			if(SceneManager.GetActiveScene().name == "Scene1"){
				//Canvas canvas = (Canvas)GameObject.Find ("Canvas");
				//scene1 is active, move to scene2
				SceneManager.LoadScene("Scene2");
				SceneManager.SetActiveScene (SceneManager.GetSceneByName ("Scene2"));
				//move player
				SceneManager.MoveGameObjectToScene(other.gameObject, SceneManager.GetActiveScene());
				//move canvas

				//SceneManager.MoveGameObjectToScene (canvas.gameObject, SceneManager.GetActiveScene ());
			}
		}
	}
}

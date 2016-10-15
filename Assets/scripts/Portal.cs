using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Portal : MonoBehaviour {

	public GameManager gameManager;
	public GameObject player;
	public int index;
	public Scene[] scenes;
	public string[] sceneText;
	public Text indicationText;
	public TextAsset txt;
	private BoxCollider2D b;
	// Use this for initialization
	void Start () {
		sceneText = txt.text.Split('\n');
		indicationText.text = "";
		b = this.GetComponentsInChildren<BoxCollider2D> ()[0];
	}

	void OnTriggerEnter2D(){
		indicationText.text = sceneText [index];
	}

	void OnTriggerExit2D(){
		indicationText.text = "";
	}

	void Update(){
		if (b.IsTouching (player.GetComponent<BoxCollider2D> ())) {
			if(index == 0){
				GameManager.loadMarket ();
			//print ("touching trigger 1");
			}else if(index == 1){
				GameManager.loadHome ();
			}
		}
	}

}

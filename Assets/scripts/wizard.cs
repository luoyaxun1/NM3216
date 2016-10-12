using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class wizard : MonoBehaviour {
	private int interactionCount;
	public Text interaction;
	private string[] dialogs;
	// Use this for initialization
	void Start () {
		interactionCount = 0;
		//dialogs = System.IO.File.ReadAllLines ("text/wizardtext.txt");
		dialogs = new string[1]{"\"Saving\" will help you progress the game!"};
	}
		

	void updateInteraction(){
		int i = interactionCount % dialogs.Length;
		interaction.text = "Wizard: " + dialogs[1];
		interactionCount++;
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.CompareTag ("Player")) {
			//colided with player
			updateInteraction ();
		}
	}
}

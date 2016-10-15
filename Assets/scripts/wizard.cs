using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class wizard : MonoBehaviour {
	private int interactionCount;
	public Text interaction;
	private string[] dialogs;
	public TextAsset dialog;

	// Use this for initialization
	void Start () {
		dialogs = dialog.text.Split ('\n');
		interaction.text = "";

	}
		

	void updateInteraction(){
		int i = interactionCount % dialogs.Length;
		interaction.text = "Wizard: " + dialogs[i];
		interactionCount++;
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.CompareTag ("Player")) {
			//colided with player
			updateInteraction ();
		}
	}
}

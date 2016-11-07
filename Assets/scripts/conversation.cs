using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class conversation : MonoBehaviour {
	public Text t;
	public TextAsset convo;
	public playerControler player;
	private string[] convos;
	private int convoLen;
	// Use this for initialization
	void Start () {
		convos = convo.text.Split ('\n');
		convoLen = convos.Length;
	}
	
	// Update is called once per frame
	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.CompareTag ("Player")) {
			//is player
			player.Pause();

			int i = 0;
			while(i < convoLen) {
				t.text = convos [i];
				if (Input.GetKey (KeyCode.Space)) {
					t.text = convos [i];
				}
			}
			player.Continue ();
		}
	}
}

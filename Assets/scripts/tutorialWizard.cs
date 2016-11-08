using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class tutorialWizard : MonoBehaviour {
	public Text t;
	public TextAsset ttxt;
	public playerControler p1;
	public Canvas c;

	private string[] st;
	private int count = 0;
	private bool isConvosing = false;
	//private BoxCollider2D bc2d;
	// Use this for initialization
	void Start () {
		st = ttxt.text.Split ('\n');
		//bc2d = GetComponent<BoxCollider2D> ();
		c.enabled = false;
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.CompareTag ("Player")) {
			p1.Pause ();
			c.enabled = true;
			isConvosing = true;
			t.text = st [count];
			count++;
		}
	}
	// Update is called once per frame
	void Update () {
		if (isConvosing) {
			if (count < st.Length && Input.GetKeyDown (KeyCode.Space)) {
				t.text = st [count];
				count++;
			} else if (count == st.Length && Input.GetKeyDown (KeyCode.Space)) {
				isConvosing = false;
				c.enabled = false;
				p1.Continue ();
			}
		}
	}
}

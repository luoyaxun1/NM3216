using UnityEngine;
using System.Collections;

public class squirelTree : MonoBehaviour {

	public bool isStree;
	public bool isCut;
	private SpriteRenderer sr;
	// Use this for initialization
	void Start () {
		isCut = false;
		sr = this.GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void OnTriggerEnter2D(Collider2D other){
		//print ("triggered");
		if (other.gameObject.CompareTag ("Player") && !isCut) {
			if (isStree) {
				sunGameScript.addKill ();
				CutDown (Color.red);
			}
			sunGameScript.addLight ();
			if (!isStree) {
				CutDown (Color.black);
			}
			isCut = true;

		}
	}
	void CutDown(Color c){
		Vector3 r = new Vector3 ((float)0.0, (float)0.0, (float)45);
		transform.Rotate (r);
		sr.color = c;
	}
}

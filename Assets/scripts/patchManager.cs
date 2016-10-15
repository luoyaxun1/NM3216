using UnityEngine;
using System.Collections;

public class patchManager : MonoBehaviour {
	private SpriteRenderer sr;
	private int seedStage;
	public Sprite growingPatch;
	// Use this for initialization
	void Start () {
		//growingPatch = Resources.Load ("growingPatch_1") as Sprite;
		sr = this.GetComponent<SpriteRenderer> ();
		seedStage = 0;
	}
	// Update is called once per frame
	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.CompareTag ("Player")) {
			sr.sprite = growingPatch;
		}
	}
}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class seedGrowth : MonoBehaviour {

	public GameManager gameManager;
	public Sprite[] seedStages;
	public Text plant;
	public GameObject toDisable;
	private int seedStage;
	private bool planted;
	private SpriteRenderer sr;
	private BoxCollider2D bc2d;
	// Use this for initialization
	void Start () {
		sr = GetComponent<SpriteRenderer> ();
		seedStage = GameManager.GetSeedGrowth ();
		sr.sprite = seedStages [seedStage];
		bc2d = GetComponent<BoxCollider2D> ();
		bc2d.isTrigger = false;
		if (seedStage == 0) {
			planted = false;
		} else {
			planted = true;
		}
	}

	void OnCollisionStay2D(Collision2D coll){
		if (planted == false) { 
			plant.text = "Press space to plant your seed";
			if (Input.GetKey(KeyCode.Space)) {
				Debug.Log ("plant");
				GameManager.AddSeedGrowth ();
				planted = true;
				seedStage = GameManager.GetSeedGrowth ();
				sr.sprite = seedStages [seedStage];
				bc2d.isTrigger = true;
				toDisable.SetActive (false);
			}

		}
	}



}

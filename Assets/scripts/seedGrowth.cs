using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class seedGrowth : MonoBehaviour {

	public GameManager gameManager;
	public Sprite[] goodSeedStages;
	public Sprite[] badSeedStages;
	private Sprite[] seedStages;
	public Text plant;
	public GameObject toDisable;
	private int seedStage;
	private bool planted;
	private SpriteRenderer sr;
	private BoxCollider2D bc2d;
	private bool plantS = false;
	// Use this for initialization
	void Start () {
		if (GameManager.IsGoodPlant()) {
			Debug.Log ("seed growth");
			seedStages = goodSeedStages;
		} else {
			Debug.Log ("seed growth");
			seedStages = badSeedStages;
		}
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
			plantS = true;
		}
	}

	void Update(){
		if (plantS) {
			if (Input.GetKey(KeyCode.Space)) {
				//Debug.Log ("plant");
				GameManager.SetSeedGrowth (1);
				planted = true;
				seedStage = GameManager.GetSeedGrowth ();
				Debug.Log ("seed stage " + seedStage);
				sr.sprite = seedStages [seedStage];
				bc2d.isTrigger = true;
				toDisable.SetActive (false);
			}
		}
	}

}

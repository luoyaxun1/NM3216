using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class patchManager : MonoBehaviour {
	public GameManager gameManager;
	private SpriteRenderer sr;
	public Sprite[] growingPatch;
	public TextAsset plantText;
	public Text text;
	private int seedStage;
	private BoxCollider2D b;
	private string[] dialogs;
	// Use this for initialization
	void Start () {
		print ("load seed stage");
		seedStage = GameManager.GetSeedGrowth ();
		//growingPatch = Resources.Load ("growingPatch_1") as Sprite;
		sr = this.GetComponent<SpriteRenderer> ();
		dialogs = plantText.text.Split ('\n');
		if (seedStage < growingPatch.Length) {
			sr.sprite = growingPatch [seedStage];
		}
		b = this.GetComponents<BoxCollider2D> ()[1];
		sr.sprite = growingPatch [seedStage];
	}
	// Update is called once per frame
	void OnTriggerEnter2D(Collider2D other){
		if (seedStage< dialogs.Length && other.gameObject.CompareTag ("Player")) {
			text.text = dialogs [seedStage];
		}
	}

	void OnTriggerExit2D(Collider2D other){
		if (seedStage< dialogs.Length && other.gameObject.CompareTag ("Player")) {
			text.text = "";
		}
	}

	void Update(){
		if (Input.GetKeyDown ("space") && seedStage < growingPatch.Length) {
			//if space is pressed

			GameManager.SetSeedGrowth (1);
			seedStage =  GameManager.GetSeedGrowth ();
			print (seedStage);
			sr.sprite = growingPatch [seedStage];
			b.isTrigger = true;
		} else if (seedStage > 0) {
			//planted
			b.isTrigger = true;
		}
	}
}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class timerRock : MonoBehaviour {

	public Sprite[] sprites;
	public int time;
	public playerControler player;
	private int maxStages;
	private int stages;
	private float standTime;
	private SpriteRenderer sr;
	private bool entered = false;
	// Use this for initialization
	void Start () {
		stages = 1;
		maxStages = sprites.Length;
		standTime = 0.0f;
		sr = GetComponent<SpriteRenderer> ();
		sr.sprite = sprites [0];
		//Debug.Log (maxStages);
	}

	void Update(){
		
		if (entered) {
			
			standTime += Time.deltaTime;
		
			if (stages == maxStages) {
				//no more rocks
				player.ExitGround();
				this.gameObject.SetActive (false);
			} else if(standTime > time) {
				//Debug.Log ("change stage");
				standTime = 0.0f;//reset
				sr.sprite = sprites[stages];
				stages++;
			}
		}

	}

	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.CompareTag ("Player")) {
			Debug.Log ("timer rock");
			entered = true;
		}
	}

	void OnCollisionExit2D(Collision2D coll){
		if (coll.gameObject.CompareTag ("Player")) {
			entered = false;
		}
	}
}

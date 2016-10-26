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
	private BoxCollider2D bc2d;
	// Use this for initialization
	void Start () {
		stages = 1;
		maxStages = sprites.Length;
		standTime = 0.0f;
		sr = GetComponent<SpriteRenderer> ();
		bc2d = GetComponent<BoxCollider2D> ();
		sr.sprite = sprites [0];
		//Debug.Log (maxStages);
	}

	void Update(){
		//Debug.Log (standTime);
		if (bc2d.IsTouching (player.GetComponent<BoxCollider2D> ())) {
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
	
	/*void OnCollisionStay2D(Collision2D coll) {
		Debug.Log (standTime);
		if (coll.gameObject.tag == "Player") {
			//if tag == maxStages
			if (stages == maxStages) {
				//no more rocks
				this.gameObject.SetActive(false);
			} else if(standTime > time) {
				standTime = 0.0f;//reset
				sr.sprite = sprites[stages - 1];
				stages++;
			}
		}
	}*/
}

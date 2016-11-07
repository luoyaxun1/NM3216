using UnityEngine;
using System.Collections;

public class movingGround : MonoBehaviour {
	//this moves in a direction until it hits an object
	//that is not the player
	// Use this for initialization
	public float velocity;
	public float maxTime;
	private float timer;
	private Rigidbody2D rb2d;
	void Start () {
		timer = 0;
		rb2d = GetComponent<Rigidbody2D> ();
		rb2d.velocity = new Vector2 (this.velocity, 0.0f);
	}
	
	// Update is called once per frame
	/*void OnCollisionEnter2D(Collision2D coll){
		if (!coll.gameObject.CompareTag ("Player")) {
			rb2d.velocity *= -1;
		}
	}*/

	void Update(){
		timer += Time.deltaTime;
		if (timer > maxTime) {
			timer = 0;
			changeDirection();
		}
	}

	public void changeDirection(){
		rb2d.velocity *= -1;
	}



}

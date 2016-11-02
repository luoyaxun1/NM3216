using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class playerControler : MonoBehaviour {
	//player controler is only incharge of moving the player


	private Rigidbody2D rb2d;
	private SpriteRenderer sr;
	private BoxCollider2D bc2d;
	//private BoxCollider2D groundBc2d;

	//motion variables
	public float speed;
	public float upForce;
	public float speedMax;
	public float upMax;
	public Sprite[] playerWalkLeft;
	public Sprite[] playerWalkRight;
	public Sprite[] playerJumpRight;
	public Sprite[] playerJumpLeft;
	private Sprite[] currentSprite;
	private int aniCounter;
	//private GameObject ground;

	private int groundedMeter = 0;//+1 -> grounded
	// Use this for initialization
	void Start() {
		//DontDestroyOnLoad (transform.gameObject);
		rb2d = this.GetComponent<Rigidbody2D> ();
		sr = this.GetComponent<SpriteRenderer> ();
		bc2d = this.GetComponent<BoxCollider2D> ();
		//ground = GameObject.FindWithTag ("ground");
		//groundBc2d = ground.GetComponent<BoxCollider2D> ();
		aniCounter = 0;
		currentSprite = playerWalkRight;
	}

	// Update is called once per frame


	void FixedUpdate1 () {
		//PrintStatus ();
		float vertical = Input.GetAxis ("Vertical") * Time.deltaTime * 10;
		float horizontal = Input.GetAxis ("Horizontal") * Time.deltaTime * 10;
		//Debug.Log (isGrounded(bc2d));
		if (Input.GetKey (KeyCode.UpArrow) && isGrounded (bc2d)) {
			//can jump
			//Debug.Log ("player jump");
			if (horizontal >= 0) {
				currentSprite = playerJumpRight;
			} else {
				currentSprite = playerJumpLeft;
			}
			if (rb2d.velocity.magnitude < 5) {
				rb2d.AddForce (new Vector3 (upForce * horizontal, upForce * vertical, 0.0f));
			} else {
				rb2d.AddForce (new Vector3 (0.0f, upForce * vertical, 0.0f));
			}
			//rb2d.MovePosition (rb2d.position + new Vector2 (horizontal * 5 * speed, 0.0f));
		} else if (isGrounded (bc2d)) {
			if (horizontal >= 0) {
				currentSprite = playerWalkRight;
			} else {
				currentSprite = playerWalkLeft;
			}
			rb2d.velocity = Vector3.zero;//lose all forces when standing
			rb2d.MovePosition (rb2d.position + new Vector2 (horizontal * speed, 0.0f));

		} else {
			//not standing on ground
		}
		anim ();
	}


	void FixedUpdate () {
		if (Input.GetKey (KeyCode.RightArrow) && rb2d.velocity.x <speedMax ) {
			Debug.Log ("move right");
			rb2d.AddForce (new Vector2 (speed, 0.0f));
		}

		if (Input.GetKey (KeyCode.LeftArrow) && rb2d.velocity.x > -1 * speedMax) {
			Debug.Log ("move left");
			rb2d.AddForce (new Vector2 (-speed, 0.0f));
		}
		if (isGrounded(bc2d) && Input.GetKey (KeyCode.UpArrow) && rb2d.velocity.y < upMax) {
			Debug.Log ("jump");
			rb2d.AddForce (new Vector2 (0.0f, upForce));
		}

		//animate
		if (isGrounded (bc2d)) {
			//walk
			if (rb2d.velocity.x >= 0) {
				currentSprite = playerWalkRight;
			} else {
				currentSprite = playerWalkLeft;
			}
		} else {
			//jump
			if (rb2d.velocity.x >= 0) {
				currentSprite = playerJumpRight;
			} else {
				currentSprite = playerJumpLeft;
			}
		}

		anim ();
	}
		

	void anim(){
		//change sprites
		aniCounter++;
		Sprite temp = currentSprite [(aniCounter/10) % currentSprite.Length];
		this.sr.sprite = temp;
	}

	bool isGrounded(Collider2D collider){
		//Debug.Log (this.groundedMeter);
		return (this.groundedMeter > 0);
	}

	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.tag == "ground") {
			this.groundedMeter++;
		}
	}

	void OnCollisionExit2D(Collision2D coll){
		if (coll.gameObject.tag == "ground") {
			this.groundedMeter--;
		}
	}

	public void ExitGround(){
		this.groundedMeter--;
	}

	void PrintStatus(){
		Debug.Log (rb2d.velocity);
		Debug.Log (transform.position);
	}
}

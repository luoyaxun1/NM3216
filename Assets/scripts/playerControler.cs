using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class playerControler : MonoBehaviour {
	//player controler is only incharge of moving the player


	private Rigidbody2D rb2d;
	private SpriteRenderer sr;
	private BoxCollider2D bc2d;
	private BoxCollider2D groundBc2d;

	//motion variables
	public float speed;
	public float upForce;
	public Sprite[] playerWalkLeft;
	public Sprite[] playerWalkRight;
	public Sprite[] playerJumpRight;
	public Sprite[] playerJumpLeft;
	private Sprite[] currentSprite;
	private int aniCounter;
	private GameObject ground;
	// Use this for initialization
	void Start() {
		//DontDestroyOnLoad (transform.gameObject);
		rb2d = this.GetComponent<Rigidbody2D> ();
		sr = this.GetComponent<SpriteRenderer> ();
		bc2d = this.GetComponent<BoxCollider2D> ();
		ground = GameObject.FindWithTag ("ground");
		groundBc2d = ground.GetComponent<BoxCollider2D> ();
		aniCounter = 0;
		currentSprite = playerWalkRight;
	}

	// Update is called once per frame


	void FixedUpdate () {
		float vertical = Input.GetAxis ("Vertical") * Time.deltaTime * 10;
		float horizontal = Input.GetAxis ("Horizontal") * Time.deltaTime * 10;
		//Debug.Log (Time.deltaTime);

		if (Input.GetKey (KeyCode.UpArrow) && bc2d.IsTouching (groundBc2d)) {
			//can jump
			//Debug.Log ("player jump");
			if (horizontal >= 0) {
				currentSprite = playerJumpRight;
			} else {
				currentSprite = playerJumpLeft;
			}
			rb2d.AddForce (new Vector3 (upForce * horizontal, upForce * vertical, 0.0f));
		} else if(bc2d.IsTouching(groundBc2d)) {
			if (horizontal >= 0) {
				currentSprite = playerWalkRight;
			} else {
				currentSprite = playerWalkLeft;
			}
			rb2d.MovePosition (rb2d.position + new Vector2(horizontal * speed, 0.0f));
		}
		anim (currentSprite);
	}

	void anim(Sprite[] sprites){
		//change sprites
		aniCounter++;
		Sprite temp = currentSprite [(aniCounter/10) % currentSprite.Length];
		this.sr.sprite = temp;
	}
}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class playerControler : MonoBehaviour {
	//player controler is only incharge of moving the player


	private Rigidbody2D rb2d;
	private SpriteRenderer sr;
	//motion variables
	public float speed;
	public float trust;


	private int[] supply;//fertiliser, water, sunlight, carrots
	// Use this for initialization
	void Start() {
		//DontDestroyOnLoad (transform.gameObject);
		rb2d = this.GetComponent<Rigidbody2D> ();
		sr = this.GetComponent<SpriteRenderer> ();
	}

	// Update is called once per frame
	void FixedUpdate () {
		float vertical = Input.GetAxis ("Vertical");
		float horizontal = Input.GetAxis ("Horizontal");

		rb2d.MovePosition (rb2d.position + new Vector2(horizontal * speed, vertical * speed));
	}


}

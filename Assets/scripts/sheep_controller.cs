using UnityEngine;
using System.Collections;

public class sheepController : MonoBehaviour {
	private Animator animator;
	private Rigidbody2D rb2d;
	public float speed;
	// Use this for initialization
	void Start () {
		animator = this.GetComponent<Animator> ();
		rb2d = this.GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		var vertical = Input.GetAxis ("Vertical");
		var horizontal = Input.GetAxis ("Horizontal");

		if (vertical > 0) {
		
			animator.SetInteger ("Direction", 2);
		} else if (vertical < 0) {
			animator.SetInteger ("Direction", 0);
		} else if (horizontal < 0) {
			animator.SetInteger ("Direction", 1);
		}else if(horizontal > 0){
			animator.SetInteger ("Direction", 3);
		}

		rb2d.MovePosition (rb2d.position + new Vector2(horizontal * speed, vertical* speed));
	}
}

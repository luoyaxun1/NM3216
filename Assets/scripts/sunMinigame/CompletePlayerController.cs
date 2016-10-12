using UnityEngine;
using System.Collections;

//Adding this allows us to access members of the UI namespace including Text.
using UnityEngine.UI;

public class CompletePlayerController : MonoBehaviour {


	private Rigidbody2D rb2d;		//Store a reference to the Rigidbody2D component required to use 2D Physics.
	public float speed;
	// Use this for initialization
	void Start()
	{
		//Get and store a reference to the Rigidbody2D component so that we can access it.
		rb2d = GetComponent<Rigidbody2D> ();


	}

	//FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
	void FixedUpdate()
	{
		//Store the current horizontal input in the float moveHorizontal.
		float moveHorizontal = Input.GetAxis ("Horizontal") * speed;

		//Store the current vertical input in the float moveVertical.
		float moveVertical = Input.GetAxis ("Vertical")* speed;

		rb2d.transform.position = new Vector3 (rb2d.transform.position.x + moveHorizontal,
			rb2d.transform.position.y + moveVertical, rb2d.transform.position.z);
	}
		
}

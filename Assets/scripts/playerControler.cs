using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class playerControler : MonoBehaviour {
	public GameManager gameManager;
	//private playerControler instance = null;
	private Rigidbody2D rb2d;
	private SpriteRenderer sr;
	//motion variables
	public float speed;
	public float trust;
	//supply variables
	public Text fertilizer;
	public Text water;
	public Text sunlight;
	public Text carrots;

	private int[] supply;//fertiliser, water, sunlight, carrots
	// Use this for initialization
	void Start() {
		//DontDestroyOnLoad (transform.gameObject);
		rb2d = this.GetComponent<Rigidbody2D> ();
		//set supply starting values
		supply = GameManager.GetSupply();
		print (supply[2]);
		sr = this.GetComponent<SpriteRenderer> ();
		//init supply variables
		UpdateSupplies();

	}

	// Update is called once per frame
	void FixedUpdate () {
		float vertical = Input.GetAxis ("Vertical");
		float horizontal = Input.GetAxis ("Horizontal");

		rb2d.MovePosition (rb2d.position + new Vector2(horizontal * speed, (float)0.0));
	}

	void UpdateSupplies(){
		fertilizer.text = "Fertilizer: " + supply[0] + "/5";
		water.text = "Water: " + supply [1] + "/5";
		sunlight.text = "Sunlight: " + supply [2] + "/10";
		carrots.text = "Carrots: " + supply [3] + "/10";
	}


}

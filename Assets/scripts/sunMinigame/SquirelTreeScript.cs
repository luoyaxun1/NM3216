using UnityEngine;
using System.Collections;

public class SquirelTreeScript : MonoBehaviour {
	//trees need sprite renderer, box collider 2d
	//public SunGameScript sungameObject;
	public GameManager gameManager;
	public bool isSquirelTree;
	//private int currLevel;
	private float sTreeChance;
	private bool isStree;
	private bool isCut;
	private SpriteRenderer sr;
	private BoxCollider2D bc;
	private int hitCounter;//how many times current tree has been hit
	private int MAXCUT = 4;

	public Sprite[] treeSprite;//how tree looks when cut down
	public Sprite[] sTreeSprite;

	private Sprite[] sprites;

	//private static GameObject Player1;

	//to check if the player can cut the tree
	private bool inRange = false;

	// Use this for initialization
	void Start () {
		//start is called before any updates, but after awake
		//this.currLevel = GameManager.GetLevel();
		//this.sTreeChance = this.currLevel * 0.3f; //0.3 for lvl1, 0.6 for lvl 2, 0.9 for lvl3
		this.isStree =  isSquirelTree;
		this.isCut = false;//init as not cut

		this.sr = this.GetComponent<SpriteRenderer> ();
		this.bc = this.GetComponent<BoxCollider2D> ();
		this.hitCounter = 0;

		//Debug.Log (isStree);
		//set differences between trees
		initTree();
		//Player1 = gameManager.getPlayer ();//get the player to refer to
	}

	void initTree(){
		if (this.isStree) {
			this.sprites = sTreeSprite;
		} else {
			this.sprites = treeSprite;
		}
		this.sr.sprite = sprites [0];
		this.bc.isTrigger = true;
	}

	//when player goes near the tree
	void OnTriggerEnter2D(Collider2D other){
		if (other.CompareTag ("Player")) {
			this.inRange = true;
		}
	}
		

	void OnTriggerExit2D(Collider2D  other){
		if (other.CompareTag ("Player")) {
			this.inRange = false;
		}
	}

	public Vector3 getLocation(){
		return this.transform.position;
	}

	void Update(){

		//this function detects if a player trys to cut a tree
		if (this.inRange && Input.GetKeyDown (KeyCode.Space) && !this.isCut) {
			//Debug.Log ("pressed space");
			//1. update cut count
			this.hitCounter++;
			this.sr.sprite = this.sprites [this.hitCounter];
			if (this.hitCounter == MAXCUT) {
				this.isCut = true;
				//Debug.Log ("tree is cut");
				if(this.isStree){
					GameManager.AddKill ();
				}
				//spawn sun drops
				gameManager.SpawnSunDrops(this.transform.position, 5);
			}
		}
	}

}

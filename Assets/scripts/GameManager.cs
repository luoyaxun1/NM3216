using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public GameObject player1;
	public GameObject sunDrop;
	public Canvas canvas;

	private static int currLevel;
	
	private static int killCount = 0;
	private static int seedGrowth = 0;
	private static int sunlight = 0;
	private static int water = 0;
	private static int fertilizer = 0;//discard
	private static int carrots = 10;
	private static int[] supply;

	public static GameManager instance = null;
	// Use this for initialization

	void Awake () {
		//Awake is called when the script instance is being loaded
		if (instance == null) {
			instance = this;

		} else if (instance != this) {
			Destroy (gameObject);
		}
		DontDestroyOnLoad (gameObject);
		//init values
		if(player1 == null){
			Instantiate (player1);
			Debug.Log ("player1 null");
		}
		if (canvas == null) {
			Instantiate (canvas);
			Debug.Log ("instantiate canvas");
		}
		player1.transform.position = new Vector3 (0.0f, 0.0f, 0.0f);
		supply = new int[4]{fertilizer, water, sunlight, carrots};
		currLevel = 1;//hard code to 1
		Rigidbody2D rb2d = player1.GetComponent<Rigidbody2D>();
		rb2d.gravityScale = 0.0f;

		canvas.transform.position = new Vector3 (0.0f, 0.0f, 0.0f);

	}



	public static int[] GetSupply(){
		return supply;
	}
	public static void AddSupply(int f, int w, int s, int c){
		print ("adding supply");
		supply [0] += f;
		supply [1] += w;
		supply [2] += s;
		supply [3] += c;
	}
	public static int GetKillCount(){
		return killCount;
	}
	public static void AddKill(){
		Debug.Log ("added kill");
		killCount++;
	}

	public static void AddSunlight(){
		Debug.Log ("added sun");
		sunlight++;
	}

	public static int GetSeedGrowth(){
		return seedGrowth;
	}

	public static void AddSeedGrowth(){
		seedGrowth++;
	}


	public static void loadHome(){
		SceneManager.LoadSceneAsync ("home", LoadSceneMode.Single);
	}

	public static void loadCave(){
		SceneManager.LoadSceneAsync ("cave", LoadSceneMode.Single);
	}

	public static void loadMarket(){
		SceneManager.LoadSceneAsync ("market", LoadSceneMode.Single);
	}

	public static void loadSunminigame(){
		SceneManager.LoadSceneAsync ("sunMinigame", LoadSceneMode.Single);
	}

	//player accessors
	public GameObject getPlayer(){
		return player1;
	}

	//level accessor
	public static int GetLevel(){
		return currLevel;
	}

	//spawn sundrops at a specific location
	public void SpawnSunDrops(Vector3 location, int n){
		GameObject temp;
		for (int i = 0; i < n; i++) {
			temp = Instantiate (sunDrop);
			temp.transform.position = location;
			temp.transform.localScale = new Vector3 (0.3f, 0.3f, 0.3f);
			Rigidbody2D srb2d = temp.GetComponent<Rigidbody2D> ();
			srb2d.gravityScale = 0.01f;
			srb2d.isKinematic = false;
			srb2d.AddForce (new Vector2 (Random.value*50, Random.value*50));
		}
	}

	void Update(){
		Text t = canvas.GetComponentInChildren <Text> ();
		t.text = "water: " + water + "\n" + "sunlight: " + sunlight;
	}
}

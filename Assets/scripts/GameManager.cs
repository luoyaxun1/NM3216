using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public GameObject player1;
	public GameObject sunDrop;
	public GameObject canvas;

	private static int currLevel;
	
	private static int killCount = 0;
	private static int seedGrowth = 0;
	private static int sunlight = 0;
	private static int water = 0;

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
		if (GameObject.FindWithTag ("Player") == null) {
			this.player1 = Instantiate (player1);
			player1.transform.position = new Vector3 (0.0f, 0.0f, 0.0f);//player load position
			Debug.Log ("instantiateplayer");
		} else {
			this.player1 = GameObject.FindWithTag ("Player");
		}
		if (canvas == null) {
			Instantiate (canvas);
			Debug.Log ("instantiate canvas");
		} else {
			//set canvas to itself
		}
		//player settings
		currLevel = 1;//hard code to 1
		Rigidbody2D rb2d = player1.GetComponent<Rigidbody2D>();
		rb2d.gravityScale = 1.0f;
	}


	public static int GetKillCount(){
		return killCount;
	}
	public static void AddKill(){
		Debug.Log ("added kill");
		killCount++;
	}

	public static  void AddWater(){
		water++;
	}

	public static int GetWater(){
		return water;
	}

	public static int GetSunLight(){
		return sunlight;
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

	public void PlayerExitGround(){
		
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
		}
	}

}

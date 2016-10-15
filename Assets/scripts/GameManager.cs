using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
	
	private static int killCount = 0;
	private static int seedGrowth = 0;
	private static int sunlight = 0;
	private static int water = 0;
	private static int fertilizer = 0;
	private static int carrots = 10;
	private static int[] supply;

	public static GameManager instance = null;
	// Use this for initialization

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
		killCount++;
	}

	public static int GetSeedGrowth(){
		return seedGrowth;
	}

	public static void AddSeedGrowth(){
		seedGrowth++;
	}
	void Awake () {
		
		if (instance == null) {
			instance = this;

		} else if (instance != this) {
			Destroy (gameObject);
		}
		DontDestroyOnLoad (gameObject);
		//init values


		supply = new int[4]{fertilizer, water, sunlight, carrots};
		print ("load gameManager");
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
}

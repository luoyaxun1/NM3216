using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class sunGameScript : MonoBehaviour {

	private static int squirelsKilled;
	private static int sunDropsCollected;
	private static Light lighting;
	public static float increment;
	public Text timer;
	//public static Time timer;
	// Use this for initialization
	void Start () {
		squirelsKilled = 0;
		sunDropsCollected = 0;
		lighting = this.GetComponentInChildren<Light> ();
	}

	
	// Update is called once per frame
	public static void addKill(){
		squirelsKilled++;
	}
	public static void addLight(){
		sunDropsCollected++;
		lighting.intensity = lighting.intensity + (float)0.5;
	}
	void Update(){
		if (sunDropsCollected > 4) {
			//timer.text =;
		}
	}
}

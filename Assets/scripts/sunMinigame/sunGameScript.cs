using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SunGameScript: MonoBehaviour {

	private static int squirelsKilled;
	private static int sunDropsCollected;
	private static Light lighting;
	public static float increment;
	public Text timer;
	public Rigidbody2D player;
	public SquirelTreeScript[] trees;

	public static float value = 0.5f;
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
		lighting.intensity = lighting.intensity + value * value *value;
	}
	void Update(){
		if (sunDropsCollected > 4) {
			//timer.text =;
		}
		if (Input.GetKey("space")) {
			for (int i = 0; i < trees.Length; i++) {
				trees [i].Hit (player);
				//print ("hitting trees");
			}

		}
	}
}

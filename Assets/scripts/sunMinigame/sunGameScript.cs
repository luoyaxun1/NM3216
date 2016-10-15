using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SunGameScript: MonoBehaviour {
	public static GameManager gameManager;
	private Light lighting;
	public Text timer;
	public Rigidbody2D player;
	public SquirelTreeScript[] trees;

	public static float value = 0.5f;
	//public static Time timer;
	// Use this for initialization
	void Start () {
		lighting = this.GetComponentInChildren<Light> ();
	}

	
	// Update is called once per frame
	public void addKill(){
		GameManager.AddKill ();
	}
	public void addLight(){
		GameManager.AddSupply (0, 0, 1, 0);
		lighting.intensity = lighting.intensity + value * value *value;
	}
	void Update(){
		if (GameManager.GetSupply()[2] > 4) {
			GameManager.loadHome ();
		}
		if (Input.GetKey("space")) {
			for (int i = 0; i < trees.Length; i++) {
				trees [i].Hit (player);
				//print ("hitting trees");
			}

		}
	}
}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CanvasScript : MonoBehaviour {

	public Text water;
	public Text sunlight;
	public GameManager gameManager;
	
	// Update is called once per frame
	void Update () {
		water.text = "Water: " + GameManager.GetWater ();
		sunlight.text = "SunLight: " + GameManager.GetSunLight ();
	}
}

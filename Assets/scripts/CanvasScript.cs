using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CanvasScript : MonoBehaviour {

	public GameManager gameManager;
	public Image waterBar;
	public Image sunLightBar;
	public Image karmarBar;
	public float totalWater;
	public float totalSun;
	public float totalKill;
	
	// Update is called once per frame
	void Update () {
		waterBar.fillAmount = (float)GameManager.GetWater () / totalWater;
		sunLightBar.fillAmount = (float)GameManager.GetSunLight ()/totalSun;
		karmarBar.fillAmount = (float)GameManager.GetKillCount()/totalKill;
	}
}

using UnityEngine;
using System.Collections;

public class seedGrowth : MonoBehaviour {

	public GameManager gameManager;
	public Sprite[] seedStages;
	private int seedStage;
	private SpriteRenderer sr;
	// Use this for initialization
	void Start () {
		sr = GetComponent<SpriteRenderer> ();
		seedStage = GameManager.GetSeedGrowth ();
		sr.sprite = seedStages [seedStage];
	}
	

}

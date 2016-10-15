using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class instructions : MonoBehaviour {
	public static GameManager gameManager;
	public int level;
	public Text instructionText;
	public TextAsset instructionTxt;
	public Button b;
	public Scene nextScene;
	private int pressIndex;
	private string[] T;
	// Use this for initialization
	void Start () {
		T = instructionTxt.text.Split ('\n');
		b.onClick.AddListener (NextLine);
	}
	
	// Update is called once per frame
	void Update () {
		instructionText.text = T [pressIndex];
		//print (T [pressIndex]);
	}

	void NextLine(){
		if (pressIndex < T.Length-1) {
			pressIndex++;
		} else {
			//load new scene here
			GameManager.loadCave();
		}
	}
	
}

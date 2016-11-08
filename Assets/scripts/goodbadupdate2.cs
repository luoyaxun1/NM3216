using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class goodbadupdate2 : MonoBehaviour {
	public string nextScene;
	public TextAsset goodt;
	public TextAsset badt;
	private TextAsset ttxt;
	public Text t;
	private string[] st;
	private int count = 0;
	// Use this for initialization
	void Start () {
		if (GameManager.IsGoodPlant ()) {
			ttxt = goodt;	
		} else {
			ttxt = badt;
		}

		st = ttxt.text.Split ('\n');
		t.text = st [count];
		count++;
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space) && count < st.Length) {
			t.text = st [count];
			count++;
		} else if (Input.GetKeyDown (KeyCode.Space) && count == st.Length) {
			SceneManager.LoadSceneAsync (nextScene, LoadSceneMode.Single);
		}
	}
}

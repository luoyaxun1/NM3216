using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class pressSpaceTextTillScene : MonoBehaviour {
	public string nextScene;
	public Text t;
	public TextAsset ttxt;
	private string[] st;
	private int count = 0;
	// Use this for initialization
	void Start () {
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

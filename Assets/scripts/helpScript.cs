using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections;

public class helpScript : MonoBehaviour {
	public Button b;
	public Image i;
	// Use this for initialization
	void Start () {
		b.onClick.AddListener (ToggleImage);
		i.enabled = false;
	}


	void ToggleImage(){
		Debug.Log ("help clicked");
		if (i.enabled) {
			i.enabled = false;
		} else {
			i.enabled = true;
		}
	}

}

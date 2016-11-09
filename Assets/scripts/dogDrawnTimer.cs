using UnityEngine;
using System.Collections;

public class dogDrawnTimer : MonoBehaviour {
	public float delay;
	private Animator ani;
	public playerControler p;
	//private bool isSteppedOn = false;
	// Use this for initialization

	void Start(){
		ani = GetComponent<Animator> ();
	}


	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.CompareTag ("Player")) {
			Debug.Log ("step");
			//set trigger
			ani.SetTrigger("drown");
			//make dog drown

			Invoke ("DeactivateObject", delay);
		}
	}



	void DeactivateObject(){
		
		this.gameObject.SetActive (false);
		//p.ExitGround ();
	}
}

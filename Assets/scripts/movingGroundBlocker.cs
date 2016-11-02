using UnityEngine;
using System.Collections;
//DISCARD
public class movingGroundBlocker : MonoBehaviour {

	public movingGround toAffect;
	// Use this for initialization
	void Start(){
		Debug.Log ("blocker start");
	}

	void OnTriggerEnter2D(Collider2D other){
		Debug.Log ("entered");
		if (other.gameObject.CompareTag("ground")) {
			Debug.Log ("sensed ground");
			//the only ground tagged object that can tag this is moving ground
			toAffect.changeDirection();
		}
	}


}

using UnityEngine;
using System.Collections;

public class respawnObject : MonoBehaviour {

	public GameObject initialSpawnPoint;
	public Sprite[] states;//0 is not on, 1 is on.
	private static Vector3 lastSpawnPoint;
	private bool spawnActivated;
	private SpriteRenderer sr;
	private Rigidbody2D rb2d;
	// Use this for initialization
	void Start () {
		lastSpawnPoint = initialSpawnPoint.transform.position;
		//Debug.Log ("last spawn point" + lastSpawnPoint);
		sr = this.GetComponent<SpriteRenderer> ();
		if (this.gameObject == initialSpawnPoint) {
			spawnActivated = false;//TODO
			sr.sprite = states [0];
		} else {
			spawnActivated = false;
			sr.sprite = states [1];
		}
	}
	
	void OnTriggerStay2D(Collider2D coll){
		if (spawnActivated == false && coll.gameObject.CompareTag ("Player")) {
			//if player comes here
			//set spawn point
			lastSpawnPoint = this.transform.position;
			//Debug.Log ("updated spawn point at" + lastSpawnPoint);
			//change sprite
			sr.sprite = states[1];
			respawnGround.updateSpawnPoint (lastSpawnPoint);
		}		
	}

	public static Vector3 GetLastTriggerPosition(){
		//Debug.Log ("last spawn point:" + lastSpawnPoint);
		return lastSpawnPoint;
	}
}

using UnityEngine;
using System.Collections;

public class respawnGround : MonoBehaviour {

	public GameObject spawnPoint;
	public GameObject cameraObject;
	private BoxCollider2D bc2d;
	// Use this for initialization
	void Start () {
		bc2d = this.GetComponent<BoxCollider2D> ();
		bc2d.isTrigger = false;
	}
	
	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Player") {
			Debug.Log ("player to respawn");
			coll.gameObject.transform.position = spawnPoint.transform.position;
			cameraObject.transform.position = coll.gameObject.transform.position;
		}
	}
}

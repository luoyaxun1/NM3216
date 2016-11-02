using UnityEngine;
using System.Collections;

public class respawnGround : MonoBehaviour {

	public GameObject spawnPoint;
	public GameObject cameraObject;
	private BoxCollider2D bc2d;
	private static Vector3 respawnPoint;
	// Use this for initialization
	void Start () {
		bc2d = this.GetComponent<BoxCollider2D> ();
		bc2d.isTrigger = false;
		respawnPoint = spawnPoint.transform.position;
	}
	
	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Player") {
			Debug.Log ("player to respawn");
			coll.gameObject.transform.position = respawnPoint;
			cameraObject.transform.position = new Vector3( coll.gameObject.transform.position.x, 
				coll.gameObject.transform.position.y, cameraObject.transform.position.z);
		}
	}

	public static void updateSpawnPoint(Vector3 location){
		respawnPoint = location;
	}
}

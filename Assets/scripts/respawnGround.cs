using UnityEngine;
using System.Collections;

public class respawnGround : MonoBehaviour {

	public GameObject spawnPoint;
	public GameObject cameraObject;
	public playerControler p;
	private BoxCollider2D bc2d;
	private static Vector3 respawnPoint;
	private AudioSource aSource;
	// Use this for initialization
	void Start () {
		bc2d = this.GetComponent<BoxCollider2D> ();
		bc2d.isTrigger = false;
		respawnPoint = spawnPoint.transform.position;
		aSource = GetComponent<AudioSource> ();
	}
	
	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Player") {
			Debug.Log ("player to respawn");
			if (GameManager.GetLevel () == 2) {
				aSource.Play ();
			}

			coll.gameObject.transform.position = respawnPoint;
			cameraObject.transform.position = new Vector3( coll.gameObject.transform.position.x, 
				coll.gameObject.transform.position.y, cameraObject.transform.position.z);
			p.ResetGround ();
		}
	}

	public static void updateSpawnPoint(Vector3 location){
		respawnPoint = location;
	}
}

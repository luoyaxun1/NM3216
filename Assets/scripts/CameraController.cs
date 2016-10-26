using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public GameManager gameManager;
	public GameObject player;
	public float cameraDisplacement;


	private Vector3 offset;
	private BoxCollider2D bc2d;
	private Camera cam;
	// Use this for initialization
	void Start () {
		//initialise offset from player position
		//this.player = gameManager.getPlayer();
		offset = new Vector3((float)0.0f , -player.transform.position.y + cameraDisplacement, (float)-10.0);
		bc2d = GetComponent<BoxCollider2D> ();
		cam = GetComponent<Camera> ();
		transform.position = this.player.transform.position + offset;

		//Vector3 bcPosition = this.transform.position - new Vector3 (cam.orthographicSize, 0.0f, 0.0f);
		//Debug.Log (cam.orthographicSize);
		//bc2d.transform.position = bcPosition;
	}
	
	// Late Update is called once per frame after Update
	void LateUpdate () {

		if (this.player.transform.position.x > transform.position.x) {
			//player is moving forward and position is more than center
			transform.position = this.player.transform.position + offset;
		} else {
			//just follow y
			float newY = this.player.transform.position.y + offset.y;
			transform.position = new Vector3 (transform.position.x, newY, transform.position.z);
		}
	}
}

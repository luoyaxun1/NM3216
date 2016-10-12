using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public GameObject player;
	public float cameraDisplacement;

	private Vector3 offset;
	// Use this for initialization
	void Start () {
		//initialise offset from player position
		offset = new Vector3((float)0.0 , -player.transform.position.y, (float)-10.0);
	}
	
	// Late Update is called once per frame after Update
	void LateUpdate () {
		//make self's position the same as player's position + offset
		transform.position = player.transform.position + offset;
	}

	void Awake(){
		DontDestroyOnLoad (transform.gameObject);
	}
}

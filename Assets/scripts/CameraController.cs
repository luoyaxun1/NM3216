using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public GameManager gameManager;
	public GameObject player;
	public float cameraDisplacement;
	public float cameraTop;
	public float cameraBottom;


	private Vector3 offset;
	// Use this for initialization
	void Start () {
		//initialise offset from player position
		//this.player = gameManager.getPlayer();
		offset = new Vector3((float)0.0f , -player.transform.position.y + cameraDisplacement, (float)-10.0);

		transform.position = this.player.transform.position + offset;


		//fix aspect ratio
		float targetaspect = 16.0f / 9.0f;
		float windowaspect = (float)Screen.width / (float)Screen.height;
		float scaleheight = windowaspect / targetaspect;
		Camera camera = GetComponent<Camera> ();
		// if scaled height is less than current height, add letterbox
		if (scaleheight < 1.0f)
		{  
			Rect rect = camera.rect;

			rect.width = 1.0f;
			rect.height = scaleheight;
			rect.x = 0;
			rect.y = (1.0f - scaleheight) / 2.0f;

			camera.rect = rect;
		}
		else // add pillarbox
		{
			float scalewidth = 1.0f / scaleheight;

			Rect rect = camera.rect;

			rect.width = scalewidth;
			rect.height = 1.0f;
			rect.x = (1.0f - scalewidth) / 2.0f;
			rect.y = 0;

			camera.rect = rect;
		}
	}
	
	// Late Update is called once per frame after Update
	void LateUpdate () {
		//PrintStatus ();

		if (this.player.transform.position.x > transform.position.x) {
			//player is moving forward and position is more than center
			transform.position = this.player.transform.position + offset;
		} else {
			//just follow y
			float newY = this.player.transform.position.y + offset.y;
			transform.position = new Vector3 (transform.position.x, newY, transform.position.z);
		}
	}

	void PrintStatus(){
		Debug.Log (transform.position);
	}
}

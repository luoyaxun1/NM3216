using UnityEngine;
using System.Collections;

public class SunDrop : MonoBehaviour {
	public GameManager gameManager;
	public float size;
	public float waitTime;
	private CircleCollider2D cc2d;
	private bool canCatch;
	void Start(){
		//this.transform.localScale = new Vector3 (size, size, 0.3f);
		Rigidbody2D srb2d = GetComponent<Rigidbody2D> ();
		srb2d.gravityScale = 0.01f;
		srb2d.isKinematic = false;
		srb2d.AddForce (new Vector2 (Random.value*50, Random.value*50));
		canCatch = false;
		if (gameObject.activeInHierarchy) {
			cc2d = GetComponent<CircleCollider2D> ();
			cc2d.isTrigger = false;
			StartCoroutine (ActivatationRoutine ());
			canCatch = true;
		}
	}

	private IEnumerator ActivatationRoutine(){
		Debug.Log ("waiting for" + waitTime);
		yield return new WaitForSeconds (waitTime);
		//cc2d.isTrigger = true;
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (canCatch && coll.gameObject.tag == "Player") {
			Debug.Log ("player caught sundrop");
			GameManager.AddSunlight ();
			this.gameObject.SetActive (false);
		}
	}
}

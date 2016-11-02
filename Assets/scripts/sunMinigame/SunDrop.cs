using UnityEngine;
using System.Collections;

public class SunDrop : MonoBehaviour {
	public GameManager gameManager;
	private CircleCollider2D cc2d;
	void Start(){
		this.transform.localScale = new Vector3 (0.3f, 0.3f, 0.3f);
		Rigidbody2D srb2d = GetComponent<Rigidbody2D> ();
		srb2d.gravityScale = 0.01f;
		srb2d.isKinematic = false;
		srb2d.AddForce (new Vector2 (Random.value*50, Random.value*50));

		if (gameObject.activeInHierarchy) {
			cc2d = GetComponent<CircleCollider2D> ();
			cc2d.isTrigger = false;
			StartCoroutine (ActivatationRoutine ());
		}
	}

	private IEnumerator ActivatationRoutine(){
		yield return new WaitForSeconds (0.4f);
		//cc2d.isTrigger = true;
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Player") {
			Debug.Log ("player caught sundrop");
			GameManager.AddSunlight ();
			this.gameObject.SetActive (false);
		}
	}
}

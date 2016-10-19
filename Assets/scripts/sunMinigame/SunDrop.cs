using UnityEngine;
using System.Collections;

public class SunDrop : MonoBehaviour {
	public GameManager gameManager;
	private CircleCollider2D cc2d;
	void Start(){
		if (gameObject.activeInHierarchy) {
			cc2d = GetComponent<CircleCollider2D> ();
			cc2d.isTrigger = false;
			StartCoroutine (ActivatationRoutine ());
		}
	}

	private IEnumerator ActivatationRoutine(){
		yield return new WaitForSeconds (0.4f);
		cc2d.isTrigger = true;
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.CompareTag ("Player")) {
			Debug.Log ("sundrop sensed player");
			GameManager.AddSunlight ();
			this.gameObject.SetActive (false);
		}
	}
}

using UnityEngine;
using System.Collections;

public class SquirelTreeScript : MonoBehaviour {

	public bool isStree;
	public bool isCut;
	private SpriteRenderer sr;
	private int hitCounter;

	public Sprite healthyTree;
	public Sprite cutTree1;
	public Sprite cutTree2;
	public Sprite cutTree3;

	private Rigidbody2D rb2d;
	private BoxCollider2D bc;


	// Use this for initialization
	void Start () {
		isCut = false;
		sr = this.GetComponent<SpriteRenderer> ();
		rb2d = this.GetComponent<Rigidbody2D> ();
		bc = this.GetComponent<BoxCollider2D> ();
	}
	
	// Update is called once per frame
	/*void OnTriggerEnter2D(Collider2D other){
		//print ("triggered");
		if (other.gameObject.CompareTag ("Player") && !isCut) {
			if (isStree) {
				sunGameScript.addKill ();
				CutDownAnimation (Color.red);
			}
			sunGameScript.addLight ();
			if (!isStree) {
				CutDownAnimation (Color.black);
			}
			isCut = true;

		}
	}*/
	void CutDownAnimation(Color c){
		Vector3 r = new Vector3 ((float)0.0, (float)0.0, (float)45);
		transform.Rotate (r);
		sr.color = c;
	}

	public void Hit(Rigidbody2D other){
		Collider2D otherCollider= other.gameObject.GetComponent<Collider2D> ();
		if (rb2d.IsTouching(otherCollider) && !isCut) {
			//print ("is hitting");
			hitCounter++;
			if (hitCounter == 1) {
				sr.sprite = cutTree1;
			} else if (hitCounter == 2) {
				sr.sprite = cutTree2;
			} else if (hitCounter == 3) {
				sr.sprite = cutTree3;
				isCut = true;

				if (isStree) {
					SunGameScript.addKill ();
				}
				SunGameScript.addLight ();
				bc.isTrigger = true;
			}


		}
	}
}

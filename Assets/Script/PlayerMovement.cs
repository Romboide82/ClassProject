using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float speed, jumpForce;
	bool isGrounded;
	// Use this for initialization
	void Start () {
		isGrounded = true;
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector2 (speed, gameObject.GetComponent<Rigidbody2D> ().velocity.y);
		if (isGrounded) {
			if((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) || Input.GetKeyDown(KeyCode.Space)){
				Jump ();
				isGrounded = false;
			}

		}
	}

	public void Jump(){
		gameObject.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0, jumpForce * 1000));
	}

	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag == "Terrain") {
			isGrounded = true;
		}
	}
}

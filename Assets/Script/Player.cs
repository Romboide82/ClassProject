using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float speedX, speedY, jumpForce;
	bool isGrounded;
	Animator animator;
	GameObject mainCamera;
	// Use this for initialization
	void Start () {
		mainCamera = GameObject.FindGameObjectWithTag ("MainCamera");
		animator = gameObject.GetComponent<Animator> ();
		isGrounded = true;
	}
	
	// Update is called once per frame
	void Update () {
		mainCamera.transform.position = new Vector3 (transform.position.x + 500, mainCamera.transform.position.y, mainCamera.transform.position.z);
		speedY = gameObject.GetComponent<Rigidbody2D> ().velocity.y;
		gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector2 (speedX, speedY);
		if (isGrounded) {
			if((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) || Input.GetKeyDown(KeyCode.Space)){
				Jump ();
				isGrounded = false;
				animator.SetBool ("Jump", true);
			}

		}
	}

	void Death(){
		Destroy (this.gameObject);
		GameObject.Find ("GameController").GetComponent<SceneTransition> ().invokeMethod ("ToStartMenu", 1);
	}

	void Win(){
		speedX = speedY = 0;
		gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0,0);
		gameObject.GetComponent<Rigidbody2D> ().gravityScale = 0;
		transform.position = GameObject.FindGameObjectWithTag ("Portal").GetComponent<Transform> ().position;
		animator.SetBool ("Win", true);
		GameObject.Find ("GameController").GetComponent<SceneTransition> ().invokeMethod ("ToStartMenu", 2);
	}

	public void Jump(){
		gameObject.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0, jumpForce * 1000));
	}

	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag == "Terrain") {
			isGrounded = true;
			animator.SetBool ("Jump", false);
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Obstacle") {
			Death();
		}
		if (other.gameObject.tag == "Portal") {
			Win ();
		}
	}
}

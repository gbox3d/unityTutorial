using UnityEngine;
using System.Collections;

public class ex1_move1 : MonoBehaviour {

	public float speed;
	private Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();

	}
	
	void FixedUpdate () {

		float movH = Input.GetAxis ("Horizontal");
		float movV = Input.GetAxis ("Vertical");
		Vector3 movement = new Vector3 (movH, 0.0f, movV);
		Debug.Log (movH);
		//movement.Normalize ();
		rb.AddForce (movement * speed);
	
	}
}

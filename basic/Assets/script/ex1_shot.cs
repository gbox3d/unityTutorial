using UnityEngine;
using System.Collections;

public class ex1_shot : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate() {

		Rigidbody rb = GetComponent<Rigidbody> ();

		if (Input.GetButtonDown ("Fire1")) {
			rb.AddForce (Vector3.forward * 500);
		}


	}
}

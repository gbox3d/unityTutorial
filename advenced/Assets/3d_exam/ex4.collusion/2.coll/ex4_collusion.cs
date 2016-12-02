using UnityEngine;
using System.Collections;

public class ex4_collusion : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(
			new Vector3(
				Input.GetAxis("Horizontal") * Time.deltaTime * 10,
				0,
				Input.GetAxis("Vertical") * Time.deltaTime * 10)
		);
	
	}


	void OnCollisionEnter(Collision collision) {
		foreach (ContactPoint contact in collision.contacts) {
			//Debug.DrawRay(contact.point, contact.normal, Color.white);
			Debug.Log (contact.point);
		}

		collision.collider.gameObject.GetComponent<Renderer> ().material.color = Color.blue;

	}

	void OnCollisionExit(Collision collision)
	{
		collision.collider.gameObject.GetComponent<Renderer> ().material.color = Color.white;
		
	}

}

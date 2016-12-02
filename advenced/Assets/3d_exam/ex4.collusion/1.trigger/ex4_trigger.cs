using UnityEngine;
using System.Collections;

public class ex4_trigger : MonoBehaviour {

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


	void OnTriggerEnter(Collider hit)
	{

		hit.gameObject.GetComponent<Renderer> ().material.color = Color.red;
		
	}

	void OnTriggerExit(Collider hit)
	{
		hit.gameObject.GetComponent<Renderer> ().material.color = Color.white;
		
	}
}

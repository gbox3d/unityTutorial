using UnityEngine;
using System.Collections;

public class ex3_tank_move : MonoBehaviour {

	private GameObject turet;

	// Use this for initialization
	void Start () {
		turet = (GameObject.Find("/tank/turet"));
	
	}
	
	// Update is called once per frame
	void Update () {
		float hoz = Input.GetAxis("Horizontal");
		float hoz2 = Input.GetAxis("Horizontal2");
		float vert = Input.GetAxis("Vertical");

		//body control
		transform.Rotate(0,Time.deltaTime*hoz*45.0f,0); 
		transform.Translate(Vector3.forward * vert * Time.deltaTime * 5.0f);

		Debug.Log(hoz2);
		//turet control
		turet.transform.Rotate(0,Time.deltaTime*hoz2*45.0f ,0);
	
	}
}

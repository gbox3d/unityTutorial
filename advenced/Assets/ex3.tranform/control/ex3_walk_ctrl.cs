using UnityEngine;
using System.Collections;

public class ex3_walk_ctrl : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.forward*Time.deltaTime * Input.GetAxis("Vertical") * 10);
		transform.Rotate(new Vector3(0,1,0) * Time.deltaTime * Input.GetAxis("Horizontal") * 45.0f);
	
	}
}

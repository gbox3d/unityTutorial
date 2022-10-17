using UnityEngine;
using System.Collections;

public class ex4_1_trkball : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(Input.GetAxis("Vertical") , Input.GetAxis("Horizontal"),0); 
	}
}

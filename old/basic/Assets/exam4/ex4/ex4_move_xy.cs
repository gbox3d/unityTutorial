using UnityEngine;
using System.Collections;

public class ex4_move_xy : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float diffy = Input.GetAxis( "Vertical" ) * Time.deltaTime * 2.0f; 
		float diffx = Input.GetAxis( "Horizontal" ) * Time.deltaTime * 2.0f; 

		transform.Translate(new Vector3(diffx,diffy,0));
	
	}
}

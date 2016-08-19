using UnityEngine;
using System.Collections;

public class ex6_moveto : MonoBehaviour {

	public Vector3 dest;
	private int WorkStep;

	// Use this for initialization
	void Start () {

		WorkStep = 0;
	
	}
	
	// Update is called once per frame
	void Update () {

		switch( WorkStep) 
		{
		case 0:
			WorkStep = 10;

			break;
		case 10:
			transform.position = Vector3.MoveTowards( 
				transform.position,dest, 
				Time.deltaTime * 2.0f
			);

			if( Vector3.Distance( transform.position, dest) < 0.0001) {
				WorkStep = 100;
				(gameObject.GetComponent<ex6_control>() as ex6_control).ChangeStatus_stop();
			}

			break;
		case 100:

			break;
		}
	
	}
}

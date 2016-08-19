using UnityEngine;
using System.Collections;

public class ex6_picking : MonoBehaviour {

	public GameObject pf_target_point;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetButtonDown("Fire1")) {

			Ray pick_ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;

			if( GetComponent<Collider>().Raycast( pick_ray,out hit, 100.0f) ) {
				//Debug.Log( hit.point.x + ',' +hit.point.z );
				Instantiate( pf_target_point, hit.point, Quaternion.identity);
				/*
			var comp = heroObject.GetComponent('scene6_control') as scene6_control;
			comp.calltest(hit.point);
			//comp.calltest();
			*/

			}
		}
	
	}
}

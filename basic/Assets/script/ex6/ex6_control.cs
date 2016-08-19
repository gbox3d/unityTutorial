using UnityEngine;
using System.Collections;

public class ex6_control : MonoBehaviour {

	public GameObject picking_ground;
	private Component current_action;

	public void ChangeStatus_moveto( Vector3 pos )
	{
		if( current_action) {
			Destroy( current_action );
		}

		ex6_moveto stobj = gameObject.AddComponent<ex6_moveto>();

		stobj.dest = pos;

		current_action = stobj;
	}

	public void ChangeStatus_stop()
	{
		if( current_action) {
			Destroy( current_action );
		}

		current_action = gameObject.AddComponent<ex6_stop>();
	}


	// Use this for initialization
	void Start () {
		//current_action = UnityEngineInternal.APIUpdaterRuntimeServices.AddComponent(gameObject, "Assets/script/ex6_control.cs (12,20)", "scene6_st_stp");
		//UnityEngineInternal.APIUpdaterRuntimeServices.AddComponent(gameObject, "Assets/script/ex6_control.cs (13,3)", "scene6_st_moveto");
		current_action = gameObject.AddComponent<ex6_stop>();
	
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetButtonDown("Fire1")) {
			Ray pick_ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;


			if( picking_ground.GetComponent<Collider>().Raycast( pick_ray,out hit, 100.0f) ) 
			{

				Debug.Log(current_action.GetType().Name);
				Debug.Log( hit.point.x + ',' +hit.point.z );

				ChangeStatus_moveto( hit.point );
			}
		}
	
	}
}

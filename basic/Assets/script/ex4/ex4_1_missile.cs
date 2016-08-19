using UnityEngine;
using System.Collections;

public class ex4_1_missile : MonoBehaviour {

	private GameObject mTarget;
	// Use this for initialization
	void Start () {

		mTarget = GameObject.Find ("/target_root/target");
	
	}
	
	// Update is called once per frame
	void Update () {

		//Vector3 target_dir = targetObj.transform.FindChild('target').transform.position - transform.position;
		Vector3 target_dir = mTarget.transform.position - transform.position;

		transform.rotation = 
			Quaternion.Slerp( transform.rotation,
				Quaternion.FromToRotation( Vector3.forward, target_dir ) ,Time.deltaTime);

		transform.Translate(Vector3.forward * Time.deltaTime);
	
	}
}

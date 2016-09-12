using UnityEngine;
using System.Collections;

public class ex4_lookat : MonoBehaviour {

	public GameObject mObjTarget;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 target_dir = mObjTarget.transform.position - transform.position;

		target_dir.Normalize();

		transform.rotation = Quaternion.FromToRotation (Vector3.forward, target_dir);
	
	}
}

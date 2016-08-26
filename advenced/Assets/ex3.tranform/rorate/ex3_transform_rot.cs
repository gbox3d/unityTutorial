using UnityEngine;
using System.Collections;

public class ex3_transform_rot : MonoBehaviour {

	private GameObject[] mObjs = new GameObject[2];

	// Use this for initialization
	void Start () {
		mObjs [0] = GameObject.CreatePrimitive (PrimitiveType.Cube);
		mObjs [0].transform.position = new Vector3 (-2, 0, 0);

		mObjs [1] = GameObject.CreatePrimitive (PrimitiveType.Cylinder);
		mObjs [1].transform.position= new Vector3 (2, 0, 0);

		GameObject obj = GameObject.CreatePrimitive (PrimitiveType.Plane);
		obj.transform.position = new Vector3 (0, -2, 0);
	
	}
	
	// Update is called once per frame
	void Update () {

		mObjs [0].transform.rotation *= Quaternion.Euler (0, Time.deltaTime * 45, 0);

		mObjs [1].transform.Rotate (0,0,Time.deltaTime*45);
	
	}
}

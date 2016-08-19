using UnityEngine;
using System.Collections;

public class ex10_makeObject : MonoBehaviour {

	// Use this for initialization
	void Start () {

		GameObject plane  = GameObject.CreatePrimitive(PrimitiveType.Plane);
		plane.name = "my plane";
		plane.transform.position = new Vector3(0, 0, 0);
		plane.GetComponent<Renderer> ().material.color = Color.red;

		GameObject cube   = GameObject.CreatePrimitive(PrimitiveType.Cube);
		cube.transform.position = new Vector3(0, 0.5f, 0);

		GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
		sphere.transform.position = new Vector3(0, 1.5f, 0);

		GameObject capsule = GameObject.CreatePrimitive(PrimitiveType.Capsule);
		capsule.transform.position = new Vector3(2, 1, 0);

		GameObject cylinder = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
		cylinder.transform.position = new Vector3(-2, 1, 0);
	
	}

	// Update is called once per frame
	void Update () {
	
	}
}

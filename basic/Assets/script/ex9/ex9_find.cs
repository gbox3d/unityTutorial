using UnityEngine;
using System.Collections;

public class ex9_find : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameObject obj = GameObject.Find("/root/Cube");

		Debug.Log("find object " + obj.name);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

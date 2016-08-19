using UnityEngine;
using System.Collections;

public class ex6_killdown : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Destroy( gameObject,3);
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(new Vector3(0,-(Time.deltaTime * 1.0f),0));
	}
}

using UnityEngine;
using System.Collections;

public class ex1_prjmatrix : MonoBehaviour {

	private Matrix4x4 originalProjection;

	// Use this for initialization
	void Start () {
		originalProjection = GetComponent<Camera>().projectionMatrix;
	}
	
	// Update is called once per frame
	void Update () {
		Matrix4x4 p  = originalProjection;
		// change some values from the original matrix
		p.m01 += Mathf.Sin (Time.time * 1.2f) * 0.1f;
		p.m10 += Mathf.Sin (Time.time * 1.5f) * 0.1f;
		GetComponent<Camera>().projectionMatrix = p;
	
	}
}

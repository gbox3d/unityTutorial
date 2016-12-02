using UnityEngine;
using System.Collections;

public class ex2_1 : MonoBehaviour {



	// Use this for initialization
	void Start () {


		float[] values = new float[3];

		values [0] = 1;
		values [1] = 9;
		values [2] = 7;

		foreach (float val in values) {
			Debug.Log (val);
		}

		float[] array_test1 = { 1, 2, 3, 4, 5 };

		for (int i = 0; i < array_test1.Length; i++) {
			Debug.Log (array_test1 [i]);
		}

		GameObject[] objs = GameObject.FindGameObjectsWithTag ("target");

		foreach (GameObject obj in objs) {
			obj.GetComponent<Renderer> ().material.color = Color.red;
			Debug.Log (obj.name);
		}


	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

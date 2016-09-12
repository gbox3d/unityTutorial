using UnityEngine;
using System.Collections;

public class ex7_test1 : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetButtonDown("Fire1")) {

			ex7_test2 comp = gameObject.GetComponent<ex7_test2>() as ex7_test2;

			comp.val_test1 = "unity";
			comp.call_test("hello");

			ex7_test3.call_test ("hi~");

			//Debug.Log("myclass public vale : " + comp.call_test1() );
			//scene7_myclass.test();
		}
	
	}
}

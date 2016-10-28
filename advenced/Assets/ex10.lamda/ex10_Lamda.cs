using UnityEngine;
using System.Collections;

public class ex10_Lamda : MonoBehaviour {

	delegate void MyDelegateType();

	// Use this for initialization
	void Start () {

		MyDelegateType test = new MyDelegateType (() => {
			Debug.Log("hello lamda");
		});
		test ();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

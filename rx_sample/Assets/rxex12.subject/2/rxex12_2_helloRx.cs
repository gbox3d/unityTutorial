using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

using UniRx;
using UniRx.Triggers;

using UnityEngine.UI;

public class rxex12_2_helloRx : MonoBehaviour {



	// Use this for initialization
	void Start () {

		Subject <string> HelloSubject = new Subject<string> ();

		HelloSubject.Subscribe (_ => {
			Debug.Log("hello subject" + _);
		});

		HelloSubject.OnNext (" hi 1 ");
		HelloSubject.OnNext (" hi 2 ");
		HelloSubject.OnNext (" hi 3 ");
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

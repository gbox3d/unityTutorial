using UnityEngine;
using System.Collections;
using UniRx;
using System;

public class rxex6_timer : MonoBehaviour {

	// Use this for initialization
	void Start () {

		Observable.Interval (TimeSpan.FromMilliseconds (1000))
			.Subscribe (
				_=> {
					Debug.Log("tick :" + Time.realtimeSinceStartup);
				}
			);

		//Observable.Timer

		Observable.Timer (TimeSpan.FromMilliseconds (5000))
			.Subscribe (
				_=> {
					Debug.Log("timer :" + Time.realtimeSinceStartup);
				}
		);
		


	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

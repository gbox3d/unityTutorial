using UnityEngine;
using System.Collections;
using UniRx;
using System;

using UnityEngine.UI;

public class rxex6_timer : MonoBehaviour {

	// Use this for initialization
	void Start () {


		Button btn_stop = GameObject.Find ("Button_stop").GetComponent<Button>();

		IDisposable stream1 = Observable.Interval (TimeSpan.FromMilliseconds (1000))
			.Subscribe (
			              _ => {
				Debug.Log ("tick :" + Time.realtimeSinceStartup);
			}
		              );

		//Observable.Timer

		Observable.Timer (TimeSpan.FromMilliseconds (5000))
			.Subscribe (
				_=> {
					Debug.Log("timer :" + Time.realtimeSinceStartup);
				}
		);


		btn_stop.onClick.AsObservable ()
			.Subscribe ((_) => {
				Debug.Log("stop timer");
				stream1.Dispose();
		});




	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

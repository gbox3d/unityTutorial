using UnityEngine;
using System.Collections;
using UniRx;
using UniRx.Triggers;
using System;

public class rxex7_mouse : MonoBehaviour {

	// Use this for initialization
	void Start () {

		var MouseDownStream = this.OnMouseDownAsObservable ();

		MouseDownStream
			.Subscribe (_ => {
				gameObject.GetComponent<Renderer>().material.color = Color.red;
		
			}
			);

		MouseDownStream
			.Buffer(MouseDownStream.Throttle(TimeSpan.FromMilliseconds(250)))
			.Where(x=>x.Count>1)
			.Subscribe (_ => {
				Debug.Log("dblclk");
				gameObject.GetComponent<Renderer> ().material.color = Color.green;
				}
			);

	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

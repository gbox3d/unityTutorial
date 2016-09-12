using UnityEngine;
using System.Collections;

using UniRx;
using UniRx.Triggers;

public class animex2_test : MonoBehaviour {
	
	private Animator mAnimator;

	public void testEvent (float theValue) {
		Debug.Log ("PrintFloat is called with a value of " + theValue);
		if (theValue < 3.0f)
			gameObject.GetComponent<Renderer> ().material.color = Color.red;
		else {
			gameObject.GetComponent<Renderer> ().material.color = Color.white;
		}
	}

	// Use this for initialization
	void Start () {
		
		//Observable.EveryUpdate ()
		var fire1Stream = gameObject.UpdateAsObservable()
			.Where (_=>Input.GetButtonDown("Fire1"));

		fire1Stream.Subscribe (_ => {
			GetComponent<Animator> ().SetTrigger("testtrigger");
			
		});
	
	}
	
	// Update is called once per frame
	void Update () {

//		if (Input.GetButtonDown ("Fire1")) {
//			mAnimator.SetTrigger ("testtrigger");
//		}
		
	
	}
}

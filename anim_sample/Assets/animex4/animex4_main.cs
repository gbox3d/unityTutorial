using UnityEngine;
using System.Collections;

using UniRx;
using UniRx.Triggers;

public class animex4_main : MonoBehaviour {

	// Use this for initialization
	void Start () {

		gameObject.UpdateAsObservable ()
			.Select (_ => Input.GetButtonDown ("Fire1"))
			.Where (x => x)
			.Subscribe (_ => 
				{
					gameObject.GetComponent<Animator>().SetTrigger("trigger1");
				}
		);

	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

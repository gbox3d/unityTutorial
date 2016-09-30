using UnityEngine;
using System.Collections;


using UniRx;
using UniRx.Triggers;

public class sound_ex1_main : MonoBehaviour {

	// Use this for initialization
	void Start () {

		this.UpdateAsObservable ()
			.Where (_ =>Input.GetButtonDown ("Fire1"))
			.Subscribe (_ => {
				gameObject.GetComponent<AudioSource>().Play();

		});

	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

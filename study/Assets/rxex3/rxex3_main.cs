using UnityEngine;
using System.Collections;
using UniRx;
using UniRx.Triggers;

public class rxex3_main : MonoBehaviour {

	// Use this for initialization
	void Start () {

		gameObject.AddComponent<ObservableUpdateTrigger> ()
			.UpdateAsObservable ()
			.Select (_=> new Vector2(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical" ) ))
			.Subscribe (
				(evt)=> {
					transform.Translate(evt.x * Time.deltaTime * 10,0,evt.y * Time.deltaTime * 10);
				}
			).AddTo(gameObject);



	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

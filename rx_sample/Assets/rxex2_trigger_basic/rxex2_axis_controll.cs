using UnityEngine;
using System.Collections;
using UniRx;
using UniRx.Triggers;

public class rxex2_axis_controll : MonoBehaviour {

	void Start () {


		//ObservableUpdateTrigger updateStream = gameObject.AddComponent<ObservableUpdateTrigger> ();

		//ObservableUpdateTrigger updateStream = gameObject.UpdateAsObservable()
		IObservable<Unit> stream_update =	gameObject.UpdateAsObservable ();

		stream_update.Select (_=> new Vector2(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical" ) ))
			.Subscribe (
				(evt)=> {
					transform.Translate(evt.x * Time.deltaTime * 10,0,evt.y * Time.deltaTime * 10);
				}
			).AddTo(gameObject);
		


	}
}

using UnityEngine;
using System;
using System.Collections;

using UniRx;
using UniRx.Triggers;


public class rxex10_combine_1 : MonoBehaviour {

	// Use this for initialization
	void Start () {		

		IObservable<Vector3> move_stream = Observable.EveryUpdate()
			.Select (_ => Input.mousePosition);

		IObservable<Vector3> down_stream = Observable.EveryUpdate()
			.Select(_=>Input.GetMouseButton (0))
			.Where ( x=>x)
			.DistinctUntilChanged()
			//.Select(_=>Input.GetMouseButtonDown (0)) // some bug?
			//.Where ( x=>x)
			.Select ( (_) => {
				Debug.Log("down");
				return Input.mousePosition;
			});


		IObservable<long> up_stream = Observable.EveryUpdate()
			.Where (_ => !Input.GetMouseButton (0) );



		Observable.CombineLatest (move_stream, down_stream)
			.Select (_ => _ [0].ToString () + " : " + _ [1].ToString ())
			.TakeUntil (up_stream)
			.Repeat ()
			.Subscribe (x => {
				Debug.Log(" drag-1 ");
				//Debug.Log(x.ToString());
			})
			.AddTo (this.gameObject);



		/*move_stream
			.TakeUntil (up_stream2)
			.Repeat ()
			.Subscribe (x => {
				Debug.Log(" drag-2 ");
			})
			.AddTo (this.gameObject);
			*/

	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

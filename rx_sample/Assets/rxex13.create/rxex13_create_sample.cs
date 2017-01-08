using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

using UniRx;
using UniRx.Triggers;

using UnityEngine.UI;
public class rxex13_create_sample : MonoBehaviour
{

	// Use this for initialization
	void Start()
	{

		IObservable<string> stream = Observable.Create<string>((Observer) =>
		{
			Debug.Log("create Observale");

			transform.FindChild("Button_next").GetComponent<Button>().onClick.AsObservable().Subscribe((obj) =>
			{
				Observer.OnNext("click button");
			});
			transform.FindChild("Button_complete").GetComponent<Button>().onClick.AsObservable().Subscribe((obj) =>
			{
				Observer.OnCompleted();
			});
			//transform.FindChild("Button_error").GetComponent<Button>().onClick.AsObservable().Subscribe((obj) =>
			//{
			//	Observer.OnError(null);
			//});

			return Disposable.Create(() =>
			{
				Debug.Log("Dispose");
			});
		});

		stream.Subscribe((msg) =>
		{
			Debug.Log(msg);
		}, (e) =>
		{
			Debug.Log(e.Message);
		}, () =>
		  {
			  Debug.Log("complete");
		  }).AddTo(this);



	}

	// Update is called once per frame
	void Update()
	{

	}
}

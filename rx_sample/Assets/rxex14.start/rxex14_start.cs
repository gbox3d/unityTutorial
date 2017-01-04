using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

using UniRx;
using UniRx.Triggers;

using UnityEngine.UI;


public class rxex14_start : MonoBehaviour
{

	// Use this for initialization
	void Start()
	{

		bool bLoop = true;

		//thread start 
		Observable.Start(() =>
			{
				Debug.Log("blocking start");
				//blocking
				while (bLoop)
				{
					//transform.FindChild("Text").GetComponent<Text>().text = "delat : " + Time.deltaTime;
				}
				Debug.Log("blocking end");

				return "hello";

			}).ObserveOnMainThread()
				  .Repeat()
			.TakeUntilDestroy(this)
				  .Subscribe((_) =>
			{
				Debug.Log("complete : " + _);
				transform.FindChild("Text").GetComponent<Text>().text = "complete : " + _;
				bLoop = true;

			});

		transform.FindChild("Button").GetComponent<Button>().onClick.AsObservable().Subscribe((obj) =>
		{
			bLoop = false;

		});


	}

	// Update is called once per frame
	void Update()
	{

	}
}

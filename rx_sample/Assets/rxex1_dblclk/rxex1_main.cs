using UnityEngine;
using System.Collections;
using UniRx;
using UniRx.Triggers;
using UnityEngine.UI;
using System;

public class rxex1_main : MonoBehaviour {

	[SerializeField] private Text textResult;
	
	void Start () {

		//global mouse down event 

		var clickStream = Observable.EveryUpdate()
			.Where(_ => Input.GetMouseButtonDown(0));

		clickStream.Buffer (clickStream.Throttle (TimeSpan.FromMilliseconds (250)))
			.Where (x => x.Count >= 2)
			.Subscribe (
			(x) => {

					textResult.text = string.Format("DoubleClick detected!\n Count:{0}", x.Count);
					
			}
			
		);
		

	
	}
	

}

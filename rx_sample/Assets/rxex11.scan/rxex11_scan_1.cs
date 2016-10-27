using UnityEngine;
using System;
using System.Collections;

using UniRx;
using UniRx.Triggers;

using System.Collections.Generic;




public class rxex11_scan_1 : MonoBehaviour {

	class my_FSM {
		public string m_StatusName;
		public float m_fTick;
		
	};

	// Use this for initialization
	void Start () {

		IObservable<int> clickStream = this.UpdateAsObservable ()
			.Where (_ => Input.GetMouseButtonDown (0))
			.Select (_ => 1)
			.Scan ((acc, current) => acc + current);

		clickStream.Subscribe (x => Debug.Log (x))
			.AddTo (this);


		/*
		Dictionary<string,int> Fsm = new Dictionary<string,int> ();

		Fsm ["main"] = 0;
		Fsm ["tick"] = 0;
*/

		my_FSM fsmObj = new my_FSM ();
		fsmObj.m_StatusName = "ready";
		fsmObj.m_fTick = 0;

		Observable.Interval( TimeSpan.FromMilliseconds (1000))
			.Select(_=> Time.realtimeSinceStartup)
			.Scan( fsmObj, (regs,x) => {

				if(regs.m_StatusName == "ready")
				{
					regs.m_StatusName = "play";
				}
				else {
					regs.m_StatusName = "ready";
				}

				regs.m_fTick = x;

				return regs;

			})
			.Subscribe (
				(x) => {

					Debug.Log ("tick :" + x.m_fTick + "," + x.m_StatusName);

				}
			);
		



	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

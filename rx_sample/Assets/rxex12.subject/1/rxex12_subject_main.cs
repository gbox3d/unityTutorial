using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

using UniRx;
using UniRx.Triggers;

using UnityEngine.UI;

public class rxex12_subject_main : MonoBehaviour {

	[SerializeField] Button m_btn1;
	[SerializeField] Button m_btn2;

	private Subject<int> m_counter1 =  new  Subject < int > ();
	private Subject<int> m_counter2 =  new  Subject < int > ();

	public IObservable<int> OnCounter_1
	{
		get { return m_counter1;}

	}

	public IObservable<int> OnCounter_2
	{
		get { return m_counter2;}

	}

	// Use this for initialization
	void Start () {

		int counter1 = 0;
		int counter2 = 0;

		m_btn1.onClick.AsObservable ().Subscribe (_=> {
			counter1++;
			m_counter1.OnNext(counter1);
		});

		m_btn2.onClick.AsObservable ().Subscribe (_=> {
			counter2++;
			m_counter2.OnNext(counter2);
		});
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

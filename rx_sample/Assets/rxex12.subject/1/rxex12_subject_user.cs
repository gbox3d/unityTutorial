using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

using UniRx;
using UniRx.Triggers;

using UnityEngine.UI;

public class rxex12_subject_user : MonoBehaviour {

	[SerializeField] GameObject SubectTest;
	//[SerializeField] Text m_outText;

	// Use this for initialization
	void Start () {

		SubectTest.GetComponent<rxex12_subject_main>().OnCounter_1.Subscribe ( (count) => {
			transform.GetComponent<Text>().text += "counter 1 : " + count + "\n";			
		});
		SubectTest.GetComponent<rxex12_subject_main>().OnCounter_2.Subscribe ( (count) => {
			transform.GetComponent<Text>().text += "counter 2 : " + count + "\n";
		});

//		SubectTest.GetComponent<rxex12_subject_main>().Subscribe ( (count) => {
//			m_outText.text += "counter 2" + count;
//
//		});

		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

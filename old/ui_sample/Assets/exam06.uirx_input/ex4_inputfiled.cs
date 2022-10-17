using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UniRx;

public class ex4_inputfiled : MonoBehaviour {

	[SerializeField] private Button btnTest;
	[SerializeField] private InputField inpfdTest;
	[SerializeField] private Text textOutResult;

	// Use this for initialization
	void Start () {

		btnTest.onClick.AsObservable ()
			.Subscribe (_ => {
				textOutResult.text = inpfdTest.text;

				
				
			}
		);
	
	}

}

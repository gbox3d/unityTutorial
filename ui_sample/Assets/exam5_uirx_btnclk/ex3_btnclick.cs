using UnityEngine;
using System.Collections;
using UniRx;
using UnityEngine.UI;

public class ex3_btnclick : MonoBehaviour {

	[SerializeField] private Button button;
	[SerializeField] private Text textResultOut;

	// Use this for initialization
	void Start () {
		/*
		button.
		OnClickAsObservable ().
		SubscribeToText (textResultOut, _ => textResultOut.text + "clicked \n");
		*/
		button.onClick.AsObservable ()
			.Subscribe (_ => {
				textResultOut.text += "clicked \n";
				
			});
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

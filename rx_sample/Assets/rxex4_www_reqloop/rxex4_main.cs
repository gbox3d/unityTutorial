using UnityEngine;
using System.Collections;
using UniRx;
using UnityEngine.UI;

public class rxex4_main : MonoBehaviour {

	[SerializeField] private Button btnConnect;
	[SerializeField] private Text textOutput;

	IEnumerator reqLoop() {

		yield return new WaitForSeconds (0.5f);

		btnConnect.enabled = false;
		btnConnect.transform.Find ("Text").GetComponent<Text> ().text = "wait";

		yield return new WaitForSeconds (0.5f);

		ObservableWWW.Get("http://localhost:8080")
			.Subscribe(
				(data) => {
					Debug.Log(data);
					textOutput.text += data;


					btnConnect.enabled = true;
					btnConnect.transform.Find ("Text").GetComponent<Text> ().text = "Connect";

					StartCoroutine (reqLoop());


				},
				(error) => {Debug.Log(error);btnConnect.enabled = true;}
			);
	
	}

	void Start () {

		btnConnect.onClick.AsObservable ()
			.Subscribe (
				_ => StartCoroutine (reqLoop())
		);








	
	}
	

}

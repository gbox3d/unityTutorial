using UnityEngine;
using System.Collections;

using UniRx;
using UniRx.Triggers;

using UnityEngine.UI;



public class exam9_main : MonoBehaviour {
	
	// Use this for initialization
	void Start () {

		//http://answers.unity3d.com/questions/674127/how-to-find-a-prefab-via-script.html
		GameObject prefeb_test = Resources.Load ("testUI",typeof(GameObject)) as GameObject;
		Button btn_Test = GameObject.Find ("Canvas/Button_Instantiate").GetComponent<Button> ();
		GameObject root_canvas = GameObject.Find ("Canvas");

		btn_Test.OnClickAsObservable ()
			.Subscribe (_ => {
				Debug.Log("click");
				GameObject obj = (GameObject)Instantiate (prefeb_test,root_canvas.transform );
				obj.GetComponent<RectTransform> ().localPosition = new Vector3 (Random.Range(-500.0f, 500.0f),Random.Range(-200.0f, 200.0f), 0);
		});

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

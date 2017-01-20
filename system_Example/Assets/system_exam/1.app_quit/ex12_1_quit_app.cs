using UnityEngine;

using System;
using System.Text;
using System.Net;
using System.Net.Sockets;

using UniRx;
using UniRx.Triggers;

using UnityEngine.UI;

using LitJson;

public class ex12_1_quit_app : MonoBehaviour {

	// Use this for initialization
	void Start () {

		gameObject.GetComponent<Button> ().onClick.AsObservable ()
			.Subscribe (_ => {

				//http://answers.unity3d.com/questions/161858/startstop-playmode-from-editor-script.html

				#if UNITY_EDITOR
				UnityEditor.EditorApplication.isPlaying = false;
				#elif UNITY_WEBPLAYER
				Application.OpenURL(webplayerQuitURL);
				#else
				Application.Quit();
				#endif
				
		});
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

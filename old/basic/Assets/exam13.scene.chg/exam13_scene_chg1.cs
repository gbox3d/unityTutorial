using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using UniRx;
using UniRx.Triggers;
using UnityEngine.UI;

public class exam13_scene_chg1 : MonoBehaviour {

	[SerializeField]
	string m_targetSceneName;
	// Use this for initialization
	void Start () {

		this.GetComponent<Button>().onClick.AsObservable().Subscribe((obj) => {
			SceneManager.LoadScene(m_targetSceneName);
		});


		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

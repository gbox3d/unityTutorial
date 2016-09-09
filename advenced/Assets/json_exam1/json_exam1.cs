using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//http://lbv.github.io/litjson/
//
using LitJson;

public class MyClass
{
	public int level;
	public float timeElapsed;
	public string playerName;
}


public class json_exam1 : MonoBehaviour {


	// Use this for initialization
	void Start () {

		var json = @"{""level"":1,""timeElapsed"":47.5,""playerName"":""Dr Charles Francis""}";

		var myObject = JsonUtility.FromJson< MyClass >(json);

		Debug.Log (myObject.playerName);


	

	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

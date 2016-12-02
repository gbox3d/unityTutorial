using UnityEngine;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

using System.IO;

using UniRx;
using UniRx.Triggers;

using UnityEngine.UI;

using LitJson;

public class json_exam2 : MonoBehaviour {

	// Use this for initialization
	void Start () {

		InputField resultOut = transform.FindChild("InputField").GetComponent<InputField>();

		string strTest = @"[{""latency"":2164,""FSM"":""disconnect"",""info"":{""index"":0,""ip"":""192.168.9.21"",""port"":1470},""game_status"":{""mode"":""stop"",""sub_mode"":"""",""hit"":{""head"":false,""chest"":false,""back"":false,""gogle"":false},""device"":{""armor_bettry"":0,""gun_bettry"":0},""team_info"":{""ground"":0,""team"":""""}}},{""latency"":944203172,""FSM"":""ping-wait"",""info"":{""index"":1,""ip"":""192.168.9.22"",""port"":1470},""game_status"":{""mode"":""stop"",""sub_mode"":"""",""hit"":{""head"":false,""chest"":false,""back"":false,""gogle"":false},""device"":{""armor_bettry"":3,""gun_bettry"":3},""team_info"":{""ground"":0,""team"":""""}}},{""latency"":943986392,""FSM"":""ping-wait"",""info"":{""index"":2,""ip"":""192.168.9.23"",""port"":1470},""game_status"":{""mode"":""stop"",""sub_mode"":"""",""hit"":{""head"":false,""chest"":false,""back"":false,""gogle"":false},""device"":{""armor_bettry"":3,""gun_bettry"":3},""team_info"":{""ground"":0,""team"":""""}}},{""latency"":944055438,""FSM"":""ping-start"",""info"":{""index"":3,""ip"":""192.168.9.24"",""port"":1470},""game_status"":{""mode"":""stop"",""sub_mode"":"""",""hit"":{""head"":false,""chest"":false,""back"":false,""gogle"":false},""device"":{""armor_bettry"":0,""gun_bettry"":0},""team_info"":{""ground"":0,""team"":""""}}}]";
		// string -> json
		var jsonObj = JsonMapper.ToObject(strTest);

		Debug.Log(jsonObj[0]["FSM"]);
		Debug.Log(jsonObj[0]["info"]["ip"]);


		JsonData test_json = new JsonData();
		test_json["test_int"] = 1;
		test_json["test_str"] = "hello json";
		test_json["test_array"] = JsonMapper.ToObject("[1,2,3]");
		int nCount = 0;
		transform.FindChild("Button").GetComponent<Button>().OnClickAsObservable()
				 .Subscribe(_ =>
				 {
					 
					
					 //json -> string
					 //Debug.Log(test_json.ToJson());

					test_json["test_int"] = nCount;
					 nCount++;

					 resultOut.text = test_json.ToJson();



				 });


	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

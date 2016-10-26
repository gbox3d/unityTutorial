using UnityEngine;
using System.Collections;

using LitJson;

public class json_exam2 : MonoBehaviour {

	// Use this for initialization
	void Start () {

		string strTest = @"[{""latency"":2164,""FSM"":""disconnect"",""info"":{""index"":0,""ip"":""192.168.9.21"",""port"":1470},""game_status"":{""mode"":""stop"",""sub_mode"":"""",""hit"":{""head"":false,""chest"":false,""back"":false,""gogle"":false},""device"":{""armor_bettry"":0,""gun_bettry"":0},""team_info"":{""ground"":0,""team"":""""}}},{""latency"":944203172,""FSM"":""ping-wait"",""info"":{""index"":1,""ip"":""192.168.9.22"",""port"":1470},""game_status"":{""mode"":""stop"",""sub_mode"":"""",""hit"":{""head"":false,""chest"":false,""back"":false,""gogle"":false},""device"":{""armor_bettry"":3,""gun_bettry"":3},""team_info"":{""ground"":0,""team"":""""}}},{""latency"":943986392,""FSM"":""ping-wait"",""info"":{""index"":2,""ip"":""192.168.9.23"",""port"":1470},""game_status"":{""mode"":""stop"",""sub_mode"":"""",""hit"":{""head"":false,""chest"":false,""back"":false,""gogle"":false},""device"":{""armor_bettry"":3,""gun_bettry"":3},""team_info"":{""ground"":0,""team"":""""}}},{""latency"":944055438,""FSM"":""ping-start"",""info"":{""index"":3,""ip"":""192.168.9.24"",""port"":1470},""game_status"":{""mode"":""stop"",""sub_mode"":"""",""hit"":{""head"":false,""chest"":false,""back"":false,""gogle"":false},""device"":{""armor_bettry"":0,""gun_bettry"":0},""team_info"":{""ground"":0,""team"":""""}}}]";

		// string -> json
		var jsonObj = JsonMapper.ToObject (strTest);

		Debug.Log (jsonObj[0]["FSM"]);
		Debug.Log (jsonObj[0]["info"]["ip"]);


		JsonData test_json = new JsonData ();
		test_json ["test_int"] = 1;
		test_json ["test_str"] = "hello json";

		//json -> string
		Debug.Log (test_json.ToJson ());
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

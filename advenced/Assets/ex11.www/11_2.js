#pragma strict

function Start () {
	var www:WWW = new WWW("http://sf2009.web-bi.net/work/api/json_2.php?name=lee");
	
	yield www;
	
	Debug.Log(www.text);
	
	

}

function Update () {

}
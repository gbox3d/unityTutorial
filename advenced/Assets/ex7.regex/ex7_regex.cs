using UnityEngine;
using System.Collections;
using System.Linq;

using System.Text.RegularExpressions;

public class ex7_regex : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
		string strTest = "192.168.9.1";

		string[] strResult =  Regex.Matches(strTest, @"\d+").Cast<Match>().Select(p => p.Value).ToArray();


		foreach (string item in strResult) {
			Debug.Log (item);
		}


	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

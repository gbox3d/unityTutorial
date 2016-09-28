using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ex6_main : MonoBehaviour {
	
	// Use this for initialization
	void Start () {

		//list sample
		List<ex6_goodguy> guys = new List<ex6_goodguy> ();

		guys.Add (new ex6_goodguy ("jeo",100));
		guys.Add (new ex6_goodguy ("jack",120));
		guys.Add (new ex6_goodguy ("hangk",80));

		foreach (ex6_goodguy guy in guys) {
			print (guy.m_strName + "," + guy.m_nPower);
		}

		print (guys [0].m_strName);


		Debug.Log ("--------remove------------");
		guys.RemoveAt (0);
		for ( int i=0; i < guys.Count;i++) {
			Debug.Log(guys[i].m_strName + "," + guys[i].m_nPower);
		}
		Debug.Log ("--------*******------------");

		Debug.Log ("--------Insert------------");
		guys.Insert (0, new ex6_goodguy ("jeo", 100));
		for ( int i=0; i < guys.Count;i++) {
			Debug.Log(guys[i].m_strName + "," + guys[i].m_nPower);
		}
		Debug.Log ("--------*******------------");

		Debug.Log ("--------sort------------");
		guys.Sort ();
		foreach (ex6_goodguy guy in guys) {
			print (guy.m_strName + "," + guy.m_nPower);
		}
		Debug.Log ("--------*******------------");


		//dic sample
		Dictionary<string,ex6_goodguy> guyDic = new Dictionary<string,ex6_goodguy> ();

		foreach (ex6_goodguy guy in guys) {
			//print (guy.m_strName + "," + guy.m_nPower);
			guyDic.Add(guy.m_strName,guy);
		}

		ex6_goodguy temp;

		if (guyDic.TryGetValue ("joe", out temp)) {
			print (temp.m_strName + "," + temp.m_nPower);
		} else {
			print ("cannot found : joe");
		}

		if (guyDic.TryGetValue ("jeo", out temp)) {
			print (temp.m_strName + "," + temp.m_nPower);
		} else {
			print ("cannot found : joe");
		}

		foreach (string key in guyDic.Keys) {
			Debug.Log ("key : " + key);
		}

		Debug.Log ("------add gbox-----------");
		guyDic ["gbox"] = new ex6_goodguy ("gbox", 666);
		//http://answers.unity3d.com/questions/957494/iterate-through-stringfloat-dictionary.html
		foreach (KeyValuePair<string,ex6_goodguy> item in guyDic) {
			Debug.Log (item.Key + "," + item.Value.m_nPower);
		}

		Debug.Log ("-------remove jack----------");
		guyDic.Remove ("jack");
		foreach (string key in guyDic.Keys) {
			Debug.Log ("key : " + key);
		}



	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

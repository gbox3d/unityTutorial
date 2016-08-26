using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ex6_main : MonoBehaviour {


	void testDic() {
		



	}

	// Use this for initialization
	void Start () {

		//list sample
		List<ex6_goodguy> guys = new List<ex6_goodguy> ();

		guys.Add (new ex6_goodguy ("jeo",100));
		guys.Add (new ex6_goodguy ("jack",120));
		guys.Add (new ex6_goodguy ("hangk",80));

		guys.Sort ();

		foreach (ex6_goodguy guy in guys) {
			print (guy.m_strName + "," + guy.m_nPower);
		}

		print (guys [1].m_strName);

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




	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

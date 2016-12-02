using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ex8_deligate : MonoBehaviour {


	delegate void MyDelegateType();

	Dictionary<string,MyDelegateType> dicMyDele;

	void test_fun1()
	{
		Debug.Log ("hello dele");
	}

	void test_fun2()
	{
		Debug.Log ("hi dele");
	}

	// Use this for initialization
	void Start () {

		dicMyDele = new Dictionary<string,MyDelegateType> ();
		MyDelegateType test1;
		test1 = new MyDelegateType (test_fun1);

		test1 ();

		dicMyDele["callbackTest"] = new MyDelegateType (test_fun2);

		//setup callback
		MyDelegateType callBackTest;
		if (dicMyDele.TryGetValue ("callbackTest", out callBackTest)) {
			callBackTest ();
			
		} else {
			Debug.Log ("not found");
		}		

		//remove it 
		dicMyDele.Remove ("callbackTest");

		if (dicMyDele.TryGetValue ("callbackTest", out callBackTest)) {
			callBackTest ();

		} else {
			Debug.Log ("not found");
		}	

	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

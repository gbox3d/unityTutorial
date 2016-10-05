using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ex9_HashTest : MonoBehaviour {

	delegate void MyDelegateType(GameObject obj);


	void test1(GameObject obj)
	{
		Debug.Log ("test1");
	}

	void test2(GameObject obj)
	{
		Debug.Log ("test2");
	}

	//const int hashcode_hit = 100;//(const int)("hit".GetHashCode ());
	// Use this for initialization
	void Start () {
		
		//string strTest = "fire";
		//int nHashTest = strTest.GetHashCode ();

		Dictionary<int,MyDelegateType> guyDic = new Dictionary<int,MyDelegateType> ();

		guyDic ["test1".GetHashCode ()] = new MyDelegateType (test1);
		guyDic ["test2".GetHashCode ()] = new MyDelegateType (test2);

		string cmd = "test2";
		int nHC_cmd = cmd.GetHashCode ();

		guyDic [nHC_cmd] (gameObject);



	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

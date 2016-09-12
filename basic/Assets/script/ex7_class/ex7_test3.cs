using UnityEngine;
using System.Collections;

public class ex7_test3 : MonoBehaviour {

	static public float public_vartest = 3.14f; 

	static public void call_test( string param )
	{
		Debug.Log( public_vartest );
		Debug.Log( param );
	}
}

using UnityEngine;
using System.Collections;

public class ex7_test2 : MonoBehaviour {

	public string val_test1;

	public void call_test( string param )
	{
		Debug.Log( val_test1 + '/' + param);
	}

}

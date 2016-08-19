using UnityEngine;
using System.Collections;

public class ex9_trv_child : MonoBehaviour {

	private void trv_child(  Transform  trns)
	{
		foreach(Transform child in trns)
		{
			//print(' way2 : ' + child.name);
			Debug.Log("traverse :" + child.name);
			trv_child(child);
		}
	}

	// Use this for initialization
	void Start () {

		trv_child (gameObject.transform);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

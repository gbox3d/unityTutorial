using UnityEngine;
using System.Collections;

public class ex3_2_move : MonoBehaviour {

	public GameObject targetObj;

	IEnumerator processSteps() {

		print("wait for input");

		while(true) {
			if(Input.anyKeyDown) {
				break;
			}
			yield return null;
		}

		print("starting move");


		while(true) {

			transform.position = Vector3.MoveTowards(
				transform.position,
				targetObj.transform.position,
				Time.deltaTime * 10
			);



			if( Vector3.Distance( transform.position, targetObj.transform.position) < Mathf.Epsilon) {
				break;
			}


			yield return null;
		}

		print("move finished");
	}

	// Use this for initialization
	void Start () {

		StartCoroutine (processSteps());
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

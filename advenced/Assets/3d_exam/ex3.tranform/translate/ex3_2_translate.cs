using UnityEngine;
using System.Collections;

public class ex3_2_translate : MonoBehaviour {

	// Use this for initialization
	IEnumerator Start () {

		GameObject cube  = GameObject.CreatePrimitive(PrimitiveType.Cube);
		cube.transform.position = new Vector3(0, 0, 0);
		cube.name = "cube1";

		while(true) {

			while(true) {

				cube.transform.Translate( new Vector3(1,0,0) * Time.deltaTime * 5.0f);


				if(cube.transform.position.x > 5) 
				{
					break;
				}

				yield return null;

			}

			while(true) {

				cube.transform.Translate(new Vector3(-1,0,0) * Time.deltaTime * 5.0f);


				if(cube.transform.position.x < -5) 
				{
					break;
				}

				yield return null;

			}
			yield return null;
		}

	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

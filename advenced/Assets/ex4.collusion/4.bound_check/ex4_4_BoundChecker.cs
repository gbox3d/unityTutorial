using UnityEngine;
using System.Collections;
using UniRx;
using UniRx.Triggers;

//bound check sample

public class ex4_4_BoundChecker : MonoBehaviour {

	// Use this for initialization
	void Start () {

		gameObject.OnMouseDragAsObservable()
			.TakeUntilDestroy(this)          
			.Select(_ => Input.mousePosition)
			.Subscribe((pos) => {
				//camdist = 10;
				//Vector3 pos3d =  Camera.main.ScreenToWorldPoint( new Vector3(pos.x,pos.y, camdist ) );
				//this.transform.position = pos3d;
				transform.position = Camera.main.ScreenToWorldPoint( new Vector3(pos.x,pos.y, 10 ) );

			}
			);

		gameObject.OnMouseUpAsObservable()
			.Select(_ => Input.mousePosition)
			.Subscribe((pos) => {

				if(GameObject.Find("dropper").GetComponent<BoxCollider>().bounds.Intersects(				
					gameObject.GetComponent<BoxCollider>().bounds
				)) {
					gameObject.GetComponent<Renderer>().material.color = Color.red;
				}
				else {
					gameObject.GetComponent<Renderer>().material.color = Color.green;
				}

			}
			);

	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

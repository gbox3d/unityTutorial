using UnityEngine;
using System.Collections;

using UniRx;
using UniRx.Triggers;

public class rxex8_main : MonoBehaviour {

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
		gameObject.OnTriggerEnterAsObservable ()
			.Subscribe ((coll) => 
				{
					//Debug.Log("coll : " + coll.tag );

					coll.gameObject.GetComponent<Renderer>().material.color = Color.red;

				}
			);
		gameObject.OnTriggerExitAsObservable ()
			.Subscribe ((coll) => 
				{
					coll.gameObject.GetComponent<Renderer>().material.color = Color.white;
					
				}
		);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


}

using UnityEngine;
using System.Collections;

using UniRx;
using UniRx.Triggers;

public class ex4_coll_kinetic_test : MonoBehaviour {

	// Use this for initialization
	void Start () {

		this.OnMouseDragAsObservable ()			
			.Select(_ => Input.mousePosition)
			.Subscribe ((pos) => {
				transform.position = Camera.main.ScreenToWorldPoint( new Vector3(pos.x,pos.y, 10 ) );

				/*
				transform.position = Camera.main.ScreenToWorldPoint( new Vector3(pos.x,pos.y, 10.0f ) );

				Ray ray = Camera.main.ScreenPointToRay(pos);
				RaycastHit[] hits;
				//hits = Physics.RaycastAll(ray, 100);
				hits = Physics.RaycastAll(ray, 100);

				for (int i = 0; i < hits.Length; i++) {
					RaycastHit hit = hits[i];
					if(hit.collider.tag == "teamplate") {
						//Debug.Log(hit.point);
						transform.position = new Vector3(hit.point.x,hit.point.y,hit.point.z);

					}
				}
				*/
				
		});
		
		/*
		 * Vector3 origin_pos = transform.position;
		this.OnMouseUpAsObservable ()
			.Subscribe (_ => {
				transform.position = origin_pos;
		});
		*/


		gameObject.OnTriggerEnterAsObservable ()
			.Subscribe ((coll) => 
				{
					//Debug.Log("coll : " + coll.tag );

					coll.gameObject.GetComponent<Renderer>().material.color = Color.red;

				}
			);
		gameObject.OnTriggerExitAsObservable ()
			.Subscribe (coll => {
				coll.gameObject.GetComponent<Renderer>().material.color = Color.green;
		});



	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

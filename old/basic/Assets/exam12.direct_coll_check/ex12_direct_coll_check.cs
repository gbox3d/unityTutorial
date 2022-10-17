using UnityEngine;
using System.Collections;
using UniRx;
using UniRx.Triggers;
using UnityEngine.UI;
using System;

public class ex12_direct_coll_check : MonoBehaviour {

	[SerializeField] GameObject mCollObject;

	// Use this for initialization
	void Start () {

		this.OnMouseDragAsObservable ()
			.Select (_ => Input.mousePosition)
			.Subscribe ((pos) => {
				transform.position = Camera.main.ScreenToWorldPoint (new Vector3 (pos.x, pos.y, 10));

		}
		).AddTo (this);

		//http://answers.unity3d.com/questions/465384/test-if-boxcollider-is-within-another-boxcollider.html
		//Bounds bound_1 = mCollObject.GetComponent<BoxCollider> ().bounds;

		this.OnMouseUpAsObservable ()
			.Subscribe ((_) => {
				Debug.Log(transform.position);

				if(gameObject.GetComponent<BoxCollider>().bounds.Intersects(
					mCollObject.GetComponent<BoxCollider> ().bounds
				)) {
					Debug.Log("hit !");
					gameObject.GetComponent<Renderer>().material.color = Color.red;
				}
				else {
					gameObject.GetComponent<Renderer>().material.color = Color.white;
				}

		}
		).AddTo (this);



	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

﻿using UnityEngine;
using System.Collections;

using UnityEngine.UI;

using UniRx;
using UniRx.Triggers;

public class exam10_uirx_drag : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
		gameObject.UpdateAsObservable ()
			.Select (_ => {
				Vector3 pos = Input.mousePosition;
				Vector3 pos_tran = gameObject.GetComponent<RectTransform>().position;
				return new Vector2(pos.x - pos_tran.x,pos.y - pos_tran.y);
			})
			.DistinctUntilChanged() // remove samethings
			.Select(pos=>gameObject.GetComponent<RectTransform>().rect.Contains(pos))
			.Subscribe ((hover) => {
				//Debug.Log( Mathf.RoundToInt( pos.x) + " , " +  Mathf.RoundToInt( pos.y) );
				if(hover == true) gameObject.GetComponent<Image>().color = Color.red;
				else gameObject.GetComponent<Image>().color = Color.green;
		});



		/*
		int FSM = 0;
		gameObject.UpdateAsObservable ()
			.Select (_ => Input.mousePosition)
			.Where((pos)=> {
				Vector3 pos_tran = gameObject.GetComponent<RectTransform>().position;
				Vector2 mouse_pos = new Vector2(
					pos.x - pos_tran.x,
					pos.y - pos_tran.y);


				if(gameObject.GetComponent<RectTransform>().rect.Contains(mouse_pos)) {

					return false;
				}

				if(FSM == 0) return false;
				else {
					FSM = 0;
				}

				return true;

			})
			.Subscribe ((pos) => {
				Debug.Log( Mathf.RoundToInt( pos.x) + " , " +  Mathf.RoundToInt( pos.y) );
				gameObject.GetComponent<Image>().color = Color.green;


			});

*/







	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

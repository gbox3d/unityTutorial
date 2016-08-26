using UnityEngine;
using System.Collections;
using UniRx;
using UniRx.Triggers;


public class rxex2_main : MonoBehaviour {

	private float _rotationSpeed = 500.0f;

	// Use this for initialization
	void Start () {
		
		var obs = gameObject.AddComponent<ObservableUpdateTrigger> ();
		obs.UpdateAsObservable()                      
			.SkipUntil( obs.OnMouseDownAsObservable() ) 
			.Select(
				_ => new Vector2(Input.GetAxis("Mouse X"),Input.GetAxis("Mouse Y")))
			.TakeUntil( obs.OnMouseUpAsObservable())   
			.Repeat()                             
			.Subscribe(
				(move) => {
					transform.rotation =
						Quaternion.AngleAxis(move.y * _rotationSpeed * Time.deltaTime, Vector3.right) *
						Quaternion.AngleAxis(-move.x * _rotationSpeed * Time.deltaTime, Vector3.up) *
						transform.rotation;
				}
			);
		
		obs.UpdateAsObservable ()
			.Select (_ => Input.GetButtonDown ("Fire1"))
			.Where(x=>x)
			.Subscribe (
				(x)=> {
					gameObject.GetComponent<Renderer>().material.color = Color.red;
				}
			);



	
	}

}

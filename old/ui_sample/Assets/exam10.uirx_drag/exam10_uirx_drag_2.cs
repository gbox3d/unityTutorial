using UnityEngine;
using System.Collections;

using UnityEngine.UI;

using UniRx;
using UniRx.Triggers;

public class exam10_uirx_drag_2 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		/* Hover */
		this.UpdateAsObservable ()
			.Select (_ => this.GetComponent<RectTransform> ().rect.Contains (
				Input.mousePosition - this.transform.position
			))
			.DistinctUntilChanged () // remove duplicates
			.Subscribe (isHover => this.GetComponent<Image> ().color = 
				isHover ? Color.red : Color.green
			);

		/* Drag and Drop */
		var downStream = Observable.EveryUpdate()
			.Select (_ => Input.GetMouseButton(0))
			.DistinctUntilChanged() //it's likes Input.GetMouseButton (0)
			.Where (x => x)
			.Select (_ => {
				//Debug.Log("down start! : " + Time.realtimeSinceStartup);
				//Debug.Log( " downstream " + (Input.mousePosition - this.transform.position).ToString() + " : " + Time.realtimeSinceStartup);
				return Input.mousePosition - this.transform.position;
			});

		/* capture position stream */
		var moveStream =  Observable.EveryUpdate()//this.UpdateAsObservable ()
			.Where (_ => Input.GetMouseButton (0)) /* anyway */
			.Select(_=> {
				return Input.mousePosition;
			})
			.DistinctUntilChanged ();

		/* only once triggered, doesn't need distinct */
		IObservable<long> up_stream = Observable.EveryUpdate ()
			.Where (_ => {
				if(gameObject.GetComponent<RectTransform>().rect.Contains(Input.mousePosition - this.transform.position)) {
					return !Input.GetMouseButton (0);
				}
				return true;
			});
		

		Observable.CombineLatest<Vector3> (downStream, moveStream)
			.Select (_ => {				
				return _[1]-_[0];
			})
			.TakeUntil (up_stream)
			.Repeat ()
			.Subscribe (position => this.transform.position = position);

		/* drag end , mouse up event*/
		this.UpdateAsObservable()			
			.Select ( (_) => {
				if(gameObject.GetComponent<RectTransform>().rect.Contains(Input.mousePosition - this.transform.position)) {
					return Input.GetMouseButtonUp(0);
				}
				return false;
			})
			.DistinctUntilChanged()
			.Where(x=>x)
			.Subscribe ((x) => {
					Debug.Log("drop ");
		});




	}

	// Update is called once per frame
	void Update () {

	}
}

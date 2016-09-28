using UnityEngine;
using System.Collections;

using UnityEngine.UI;

using UniRx;
using UniRx.Triggers;

public class exam10_uirx_drag : MonoBehaviour {

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
		var downStream = Observable.EveryUpdate()//.UpdateAsObservable ()
			.Where (_ => Input.GetMouseButtonDown (0))
			.Select (_ => Input.mousePosition - this.transform.position);

		/* capture position stream */
		var moveStream =  Observable.EveryUpdate()//this.UpdateAsObservable ()
			.Where (_ => Input.GetMouseButton (0)) /* anyway */
			.Select (_ => Input.mousePosition)     /* but, capture mousePosition only */
			.DistinctUntilChanged ();

		/* only once triggered, doesn't need distinct */
		var upStream =  Observable.EveryUpdate()//this.UpdateAsObservable ()
			.Where (_ => Input.GetMouseButtonUp (0)); /* when mouse move */

		Observable.CombineLatest<Vector3> (downStream, moveStream)
			.Select (_ => _[1]-_[0])
			.TakeUntil (upStream)
			.Repeat ()
			.Subscribe (position => this.transform.position = position);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

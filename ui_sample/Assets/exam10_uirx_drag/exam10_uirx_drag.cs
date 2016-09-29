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
		var downStream = this.UpdateAsObservable ()
			.Where (_ => Input.GetMouseButtonDown (0)) /* when mouse down capture delta position */
			.Select (_ => Input.mousePosition - this.transform.position)
			.Do (_ => Debug.Log ( "mouseDown" + _));

		/* capture position stream */
		var moveStream = this.UpdateAsObservable ()
			.Where (_ => Input.GetMouseButton (0)) /* anyway */
			.Select (_ => Input.mousePosition)     /* but, mousePosition only */
			.DistinctUntilChanged ()
			.Do (_ => Debug.Log ( "mouseMove" + _));
		
		Observable.CombineLatest<Vector3> (downStream, moveStream)
			.Select (_ => _[1]-_[0])
			.Subscribe (position => this.transform.position = position)
			.AddTo(this.gameObject); /* add to disposable */
	}

	// Update is called once per frame
	void Update () {

	}
}

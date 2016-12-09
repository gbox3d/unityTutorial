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
			//.Where (_ => Input.GetMouseButton (0))
			.Select (_ => Input.GetMouseButton(0))
			.Where (x => x)
			//.DistinctUntilChanged()
			.Select (_ => {
				//Debug.Log("down start! : " + Time.realtimeSinceStartup);
				Debug.Log( " downstream " + (Input.mousePosition - this.transform.position).ToString() + " : " + Time.realtimeSinceStartup);
				return Input.mousePosition - this.transform.position;
			});

		/*IObservable<Vector3> down_stream = Observable.EveryUpdate()
			.Select (_ => Input.GetMouseButton(0))
			.Where (x => x)
			.DistinctUntilChanged()
			.Select (_ => {
				//Debug.Log("down");
				Vector3 pos = Input.mousePosition - this.transform.position;
				//Debug.Log( "down " + Input.mousePosition.ToString());
				Debug.Log( "down pos" + this.transform.position.ToString());
				return pos;
				//Vector3 pos = Input.mousePosition;
				//Vector3[] ar = { Input.mousePosition, gameObject.GetComponent<RectTransform> ().position };
				//return ar;
			});
			*/



		/* capture position stream */
		var moveStream =  Observable.EveryUpdate()//this.UpdateAsObservable ()
			.Where (_ => Input.GetMouseButton (0)) /* anyway */
			//.Select (_ => Input.mousePosition)     /* but, capture mousePosition only */
			.Select(_=> {
				//Debug.Log("down moving  : " + Time.realtimeSinceStartup);
				//Debug.Log( (Input.mousePosition - this.transform.position).ToString() + " : " + Time.realtimeSinceStartup);
				//Debug.Log( "move : " + this.transform.position.ToString());
				//Debug.Log( "move" + Input.mousePosition.ToString());
				return Input.mousePosition;
			})
			.DistinctUntilChanged ();

		/* only once triggered, doesn't need distinct */
//		var upStream =  Observable.EveryUpdate()//this.UpdateAsObservable ()
//			.Where (_ => Input.GetMouseButtonUp (0)); /* when mouse move */

		IObservable<long> up_stream = Observable.EveryUpdate ()
			.Where (_ => {
				if(gameObject.GetComponent<RectTransform>().rect.Contains(Input.mousePosition - this.transform.position)) {
					return !Input.GetMouseButton (0);
				}
				return true;
			});

		Observable.CombineLatest<Vector3> (downStream, moveStream)
			//.Select (_ => _[1]-_[0])
			.Select (_ => {
//				Debug.Log( "down pos 2" + this.transform.position.ToString());
//				Debug.Log( "move" +  _[1].ToString());
//				Debug.Log( "down 1" + _[0].ToString());
				//Debug.Log( "down 2" + (Input.mousePosition - this.transform.position).ToString() );

				Debug.Log( " combine " + (  Input.mousePosition - this.transform.position).ToString() + " : " + Time.realtimeSinceStartup);

				return _[1]-_[0];
			})
			.TakeUntil (up_stream)
			.Repeat ()
			.Subscribe (position => this.transform.position = position);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

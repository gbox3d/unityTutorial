using UnityEngine;
using System.Collections;

using UnityEngine.UI;

using UniRx;
using UniRx.Triggers;

public class exam14_rectUtil_1 : MonoBehaviour {

	// Use this for initialization
	void Start () {

		//GameObject test_1 = GameObject.Find ("test1");
		GameObject test_2 = GameObject.Find ("test2");
		//GameObject Canvas_1 = GameObject.Find ("Canvas");

		this.UpdateAsObservable ()
			.Select (_ => Input.mousePosition)
			.Where(_=>Input.GetMouseButtonDown(0))
			.Subscribe ((cur_mpos) => {

				Vector2 tempPt;
				RectTransformUtility.ScreenPointToLocalPointInRectangle(
					test_2.GetComponent<RectTransform>(),
					cur_mpos,
					Camera.current,
					out tempPt
				);

				Debug.Log(tempPt);

				bool bTemp = RectTransformUtility.RectangleContainsScreenPoint(
					test_2.GetComponent<RectTransform>(),
					cur_mpos
				);
				Debug.Log(bTemp);

				if(bTemp) {
					test_2.transform.FindChild("Panel").GetComponent<Image>().color = Color.cyan;
				}
				else {
					test_2.transform.FindChild("Panel").GetComponent<Image>().color = Color.white;
				}


				/*
				Rect tempRt = RectTransformUtility.PixelAdjustRect(test_2.GetComponent<RectTransform>(),
					Canvas_1.GetComponent<Canvas>());

				Debug.Log(tempRt);
			


				Vector3 temp3dPt;
				RectTransformUtility.ScreenPointToWorldPointInRectangle(
					test_2.GetComponent<RectTransform>(),
					tempPt,
					Camera.current,
					out temp3dPt
				);

				Debug.Log(temp3dPt);
				*/


			});

	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using UnityEngine.UI;

using UniRx;
using UniRx.Triggers;

public class ex14_RectTranformUtil2 : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
		Transform test_root_panel = transform.FindChild ("root_test");
		Transform test_root_panel_wp = transform.FindChild ("root_test_wp");
		Transform test_box_lp = transform.FindChild ("root_test/test_box_lp");
		Transform test_box_wp = GameObject.Find ("test_box_wp").transform; // 종속된객체아님 

		this.UpdateAsObservable ()
			.Select (_ => Input.mousePosition)
			.Where (_ => Input.GetMouseButtonDown (0))
			.Subscribe ((cur_mpos) => {

//마우스포인터가 사각형영역에 있는지 검사한다.
				if(RectTransformUtility.RectangleContainsScreenPoint(test_root_panel.GetComponent<RectTransform>(),cur_mpos)) {
					Vector2 tempPt;
					RectTransformUtility.ScreenPointToLocalPointInRectangle(
						test_root_panel.GetComponent<RectTransform>(),
						cur_mpos,
						Camera.current,
						out tempPt
					);
					//test_box_lp 는 test_root_panel 의 자식으로 들어있는 객체이다.
					test_box_lp.GetComponent<RectTransform>().localPosition = tempPt;
				}

				if(RectTransformUtility.RectangleContainsScreenPoint(test_root_panel_wp.GetComponent<RectTransform>(),cur_mpos)) {
					Vector3 temp_pt3d;
					RectTransformUtility.ScreenPointToWorldPointInRectangle(
						test_root_panel_wp.GetComponent<RectTransform>(),
						cur_mpos,
						Camera.current,
						out temp_pt3d
					);
					//월드 객체 이므로 월드 좌표를 직접 넣어준다.
					//test_box_wp.position = temp_pt3d;
					test_box_wp.GetComponent<RectTransform>().position = temp_pt3d;

				
				}



				
		});
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
}

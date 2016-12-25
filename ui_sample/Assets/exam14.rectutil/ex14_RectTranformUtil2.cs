using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using UnityEngine.UI;

using UniRx;
using UniRx.Triggers;

public class ex14_RectTranformUtil2 : MonoBehaviour
{

	// Use this for initialization
	void Start()
	{
		Transform test_root_panel = transform.FindChild("root_test");
		Transform test_root_panel_wp = transform.FindChild("root_test_wp");
		Transform test_box_lp = transform.FindChild("root_test/test_box_lp");
		Transform test_box_wp = GameObject.Find("test_box_wp").transform; // 종속된객체아님 

		Camera mainCam = GameObject.Find("Main Camera").GetComponent<Camera>();

		Text wp_log = transform.FindChild("Text_log_wp").GetComponent<Text>();

		this.UpdateAsObservable()
			.Select(_ => Input.mousePosition)
			.Where(_ => Input.GetMouseButtonDown(0))
			.Subscribe((cur_mpos) =>
			{

				//마우스포인터가 사각형영역에 있는지 검사한다.
				if (RectTransformUtility.RectangleContainsScreenPoint(test_root_panel.GetComponent<RectTransform>(), cur_mpos))
				{
					Vector2 tempPt;
					RectTransformUtility.ScreenPointToLocalPointInRectangle(
						test_root_panel.GetComponent<RectTransform>(),
						cur_mpos,
						//Camera.current,
						null,//카메라값이 null이면 2디 모드 기준으로 좌표를 반환한다. 그렇지 않으면 3디 좌표계로 나온다.
						out tempPt
					);
					//test_box_lp 는 test_root_panel 의 자식으로 들어있는 객체이다.
					test_box_lp.GetComponent<RectTransform>().localPosition = tempPt;
				}

				if (RectTransformUtility.RectangleContainsScreenPoint(test_root_panel_wp.GetComponent<RectTransform>(), cur_mpos))
				{
					Vector3 temp_pt3d;
					RectTransformUtility.ScreenPointToWorldPointInRectangle(
						test_root_panel_wp.GetComponent<RectTransform>(),
						cur_mpos,
					//Camera.current, //에디터모드일때만 값을 가지며 실행기상태일땐 null이된다.
					//mainCam,
						null, //2디 모드 기준으로 좌표를 반환한다. 카메라가 주어지면 3디 좌표계로 나온다.
						out temp_pt3d
					);
					//월드 객체 이므로 월드 좌표를 직접 넣어준다.
					//test_box_wp.position = temp_pt3d;
					//test_box_wp.GetComponent<RectTransform>().position = temp_pt3d;
					test_box_wp.GetComponent<RectTransform>().position = cur_mpos;
					wp_log.text = cur_mpos.ToString() + "," + temp_pt3d.ToString();


				}




			});

	}

	// Update is called once per frame
	void Update()
	{

	}
}

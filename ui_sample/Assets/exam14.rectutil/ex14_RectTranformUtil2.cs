using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using UnityEngine.UI;

using UniRx;
using UniRx.Triggers;

public class ex14_RectTranformUtil2 : MonoBehaviour
{
	public GameObject m_sprGrade;
	//public GameObject m_sprGrade2;
	public Text m_log_lp;


	// Use this for initialization
	void Start()
	{
		Transform test_root_panel = transform.FindChild("root_test");
		Transform test_root_panel_wp = transform.FindChild("root_test_wp");
		Transform test_box_lp = transform.FindChild("root_test/test_box_lp");
		Transform test_box_wp = GameObject.Find("test_box_wp").transform; // 종속된객체아님 

		//Camera.current 가 에디터모드일때는 null값을 가지므로 직접 카메라를 선택한다. 
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
						//Camera.current,//주의! 에디터모드일때 null이된다.
						null,//카메라값이 null이면 캔버스랜더러용 직교 카메라 기준으로 좌표계를 변환한다.
						//일반적으로 ScreenPointToLocalPointInRectangle 에서의 카메라값은 null이 되어야할거같다. 
						out tempPt
					);
					//test_box_lp 는 test_root_panel 의 자식으로 들어있는 객체이다.

					test_box_lp.GetComponent<RectTransform>().localPosition = tempPt;
					//m_sprGrade2.transform.localPosition = tempPt;
				}

				if (RectTransformUtility.RectangleContainsScreenPoint(test_root_panel_wp.GetComponent<RectTransform>(), cur_mpos))
				{

					//canvas ui 객체의 포인팅은 그대로 마우스값(스크린좌표)를 넣어준다.
					test_box_wp.GetComponent<RectTransform>().position = cur_mpos;//우측의 빨간색 박스 

					Vector3 temp_pt3d;
					RectTransformUtility.ScreenPointToWorldPointInRectangle(
						test_root_panel_wp.GetComponent<RectTransform>(),
						cur_mpos,
						mainCam,
						out temp_pt3d //2d 좌표인 cur_mpos 좌표를 카메라기준(mainCam)의 3d 좌표계로 바꾸어 temp_pt3d 에 넘겨준다. 
					);
					//3d 랜더러 좌표계 처리 
					m_sprGrade.transform.position = temp_pt3d;
					wp_log.text = cur_mpos.ToString() + "," + temp_pt3d.ToString();
				}

			});

	}

	// Update is called once per frame
	void Update()
	{

	}
}

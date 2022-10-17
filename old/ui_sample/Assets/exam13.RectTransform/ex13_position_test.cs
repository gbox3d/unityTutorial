using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;



public class ex13_position_test : MonoBehaviour {
	[SerializeField] GameObject m_prefeb_test_box;
	[SerializeField] GameObject m_root_test;

	// Use this for initialization
	void Start () {

//월드좌표기준으로 정렬된다 원점은 스크린 좌하단기준이다.
		GameObject obj = Instantiate (m_prefeb_test_box, m_root_test.transform);
		obj.transform.FindChild ("Text").GetComponent<Text>().text = "world";
		obj.GetComponent<RectTransform> ().position = new Vector2 (0, 0);
//부모객체의 피벗기준으로 정렬된다. 원점은 부모객체의 피벗이된다.
		obj = Instantiate (m_prefeb_test_box, m_root_test.transform);
		obj.transform.FindChild ("Text").GetComponent<Text>().text = "local";
		obj.GetComponent<RectTransform> ().localPosition = new Vector2 (0, 0);
//자신의 앵커프리셋정보에 따른기준으로 정렬된다. 좌상단이라면 원점이 부모객체의 좌상단 끝점이된다.
//부모객체의 크기가 동적으로 바뀔경우 비율에 따라 위치 바꾸고 싶을때 이용할수있을것같다.
		obj = Instantiate (m_prefeb_test_box, m_root_test.transform);
		obj.transform.FindChild ("Text").GetComponent<Text>().text = "anchored";
		obj.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (0, 0);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

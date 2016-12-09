using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UniRx;
using UniRx.Triggers;

public class touch_exam1 : MonoBehaviour
{

	// Use this for initialization
	void Start()
	{


		this.UpdateAsObservable()
			.Subscribe((obj) =>
			{
#if UNITY_ANDROID

				// 현재 터치되어 있는 카운트 가져오기
				int cnt = Input.touchCount;
				for (int i = 0; i < cnt; ++i)
				{
					Touch touch = Input.GetTouch(i);
					Vector2 pos = touch.position;
					// 조금 더 디테일하게!

					if (touch.phase == TouchPhase.Began)
					{
						Debug.Log("시작점 : (" + i + ") : x = " + pos.x + ", y = " + pos.y);
					}
					else if (touch.phase == TouchPhase.Ended)
					{
						Debug.Log("끝점 : (" + i + ") : x = " + pos.x + ", y = " + pos.y);
					}
					else if (touch.phase == TouchPhase.Moved)
					{
						Debug.Log("이동중 : (" + i + ") : x = " + pos.x + ", y = " + pos.y);

					}
				}
#endif
				//Input.touches[0]
			});


	}

	// Update is called once per frame
	void Update()
	{

	}
}

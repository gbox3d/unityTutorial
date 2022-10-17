using UnityEngine;
//using System.Collections;

using UnityEngine.UI;

using UniRx;
using UniRx.Triggers;

public class exam10_uirx_drag_v2 : MonoBehaviour {

	// Use this for initialization
	void Start () {

		GameObject dropper = GameObject.Find ("dropper");
		GameObject panel = transform.FindChild ("Panel").gameObject;

		/* Hover */
		this.UpdateAsObservable ()
			.Select (_ => GetComponent<RectTransform> ().rect.Contains (
				Input.mousePosition - transform.position
			))
			.DistinctUntilChanged () // remove duplicates
			.Subscribe (isHover => panel.GetComponent<Image> ().color = 
				isHover ? Color.red : Color.green
			);

		{
			
			int nFsm = 0;
			//Vector3 screen_center = new Vector3 (Screen.width/2,Screen.height/2,0);
			Vector3 down_pos = Input.mousePosition;
			this.UpdateAsObservable ()
				.Select (_ => Input.mousePosition)
				//.Where(x=> gameObject.GetComponent<RectTransform>().rect.Contains(x - this.transform.position))
				.Subscribe ((cur_mpos) => {
					
				switch (nFsm) {
				case 0:
						{
							bool btn_down = Input.GetMouseButtonDown (0);
							if (btn_down == true 
								//&& gameObject.GetComponent<RectTransform>().rect.Contains(cur_mpos - transform.position)
								&& RectTransformUtility.RectangleContainsScreenPoint(transform.GetComponent<RectTransform>(),cur_mpos)
							) {		
								nFsm = 10; //start darg
								Debug.Log("drag start");
								down_pos = cur_mpos - transform.position;
							}
						}
					
					break;
				case 10:
					//Debug.Log(Input.GetMouseButton(0));
					{
						bool btn_down = Input.GetMouseButton (0);
						if (btn_down == false) {
							nFsm = 0;
							Debug.Log("drag end");
//영역정보 갱신하기 
							Bounds bound_this = RectTransformUtility.CalculateRelativeRectTransformBounds(transform);
							Bounds bound_dropper = RectTransformUtility.CalculateRelativeRectTransformBounds(dropper.transform);
							Debug.Log(bound_this);
//반드시 위치는 재지정, Bounds 는 기본적으로 원점으로 만들어짐
							bound_this.center = transform.position;
							bound_dropper.center = dropper.transform.position;

//박스끼리 충돌처리 하기
							//collusion check 
							if(bound_dropper.Intersects(bound_this)) {
								Debug.Log("hit!");
								dropper.transform.FindChild("Panel").GetComponent<Image>().color = Color.blue;
							}
							else {
								dropper.transform.FindChild("Panel").GetComponent<Image>().color = Color.white;
							} 
						} else {

							//http://answers.unity3d.com/questions/781643/unity-46-beta-rect-transform-position-new-ui-syste.html
							//this.GetComponent<RectTransform>().anchoredPosition = cur_mpos - screen_center;
							//this.GetComponent<RectTransform>().anchoredPosition = (cur_mpos - down_pos)- screen_center;
							GetComponent<RectTransform>().position = (cur_mpos - down_pos);

						}
					}
					
					break;
				}
			});
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

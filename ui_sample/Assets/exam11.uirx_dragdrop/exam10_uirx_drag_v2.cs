using UnityEngine;
using System.Collections;

using UnityEngine.UI;

using UniRx;
using UniRx.Triggers;

public class exam10_uirx_drag_v2 : MonoBehaviour {

	// Use this for initialization
	void Start () {

		GameObject dropper = GameObject.Find ("dropper");
		GameObject panel = this.transform.FindChild ("Panel").gameObject;

		/* Hover */
		this.UpdateAsObservable ()
			.Select (_ => this.GetComponent<RectTransform> ().rect.Contains (
				Input.mousePosition - this.transform.position
			))
			.DistinctUntilChanged () // remove duplicates
			.Subscribe (isHover => panel.GetComponent<Image> ().color = 
				isHover ? Color.red : Color.green
			);

		{
			
			int nFsm = 0;
			Vector3 screen_center = new Vector3 (Screen.width/2,Screen.height/2,0);
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
								&& gameObject.GetComponent<RectTransform>().rect.Contains(cur_mpos - this.transform.position)
							) {		
								nFsm = 10; //start darg
								Debug.Log("drag start");
								down_pos = cur_mpos - this.transform.position;
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

								//collusion check
								Rect rt1 = new Rect(
									this.GetComponent<RectTransform>().position.x - this.GetComponent<RectTransform>().rect.width/2,
									this.GetComponent<RectTransform>().position.y - this.GetComponent<RectTransform>().rect.height/2,
									this.GetComponent<RectTransform>().rect.width,
									this.GetComponent<RectTransform>().rect.height
								);

								Rect rt2 = new Rect(
									dropper.GetComponent<RectTransform>().position.x - dropper.GetComponent<RectTransform>().rect.width/2,
									dropper.GetComponent<RectTransform>().position.y - dropper.GetComponent<RectTransform>().rect.height/2,
									dropper.GetComponent<RectTransform>().rect.width,
									dropper.GetComponent<RectTransform>().rect.height
								);


								if( rt2.Overlaps(rt1) == true ) {
									dropper.transform.FindChild("Panel").GetComponent<Image>().color = Color.blue;
								}
								else {
									dropper.transform.FindChild("Panel").GetComponent<Image>().color = Color.white;
								}
							} else {

								//http://answers.unity3d.com/questions/781643/unity-46-beta-rect-transform-position-new-ui-syste.html
								//this.GetComponent<RectTransform>().anchoredPosition = cur_mpos - screen_center;
								this.GetComponent<RectTransform>().anchoredPosition = (cur_mpos - down_pos)- screen_center;
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

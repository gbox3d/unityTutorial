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
			Vector3 down_pos = Input.mousePosition;
			gameObject.UpdateAsObservable ()
				.Select (_ => Input.mousePosition)
				//.Where(x=> gameObject.GetComponent<RectTransform>().rect.Contains(x - this.transform.position))
				.Subscribe ((cur_mpos) => {
				bool btn_down = Input.GetMouseButton (0);
				switch (nFsm) {
				case 0:
					if (btn_down == true 
							&& gameObject.GetComponent<RectTransform>().rect.Contains(cur_mpos - this.transform.position)
						) {		
						nFsm = 10; //start darg
						Debug.Log("drag start");
						down_pos = cur_mpos - this.transform.position;
					}
					break;
				case 10:
					//Debug.Log(Input.GetMouseButton(0));
					if (btn_down == false) {
							nFsm = 0;
							Debug.Log("drag end");


							Rect rt1 = new Rect(
								this.transform.position.x - this.GetComponent<RectTransform>().rect.width/2,
								this.transform.position.y - this.GetComponent<RectTransform>().rect.height/2,
								this.GetComponent<RectTransform>().rect.width,
								this.GetComponent<RectTransform>().rect.height
							);


							Rect rt2 = new Rect(
								dropper.transform.position.x - dropper.GetComponent<RectTransform>().rect.width/2,
								dropper.transform.position.y - dropper.GetComponent<RectTransform>().rect.height/2,
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

							this.transform.position = cur_mpos - down_pos;
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

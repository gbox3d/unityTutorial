using UnityEngine;
using System.Collections;

using UnityEngine.UI;

using UniRx;
using UniRx.Triggers;

public class exam12_ui_scrollview_1 : MonoBehaviour {

	[SerializeField] Button btn_Extend;
	[SerializeField] GameObject scroll_root;


	// Use this for initialization
	void Start () {

		btn_Extend.onClick.AsObservable ()
			.Subscribe (_ => {
				//http://answers.unity3d.com/questions/775779/change-size-of-the-new-ui-rect-transform-using-scr.html
				scroll_root.GetComponent<RectTransform>().sizeDelta = new Vector2(128,512);
		});

	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

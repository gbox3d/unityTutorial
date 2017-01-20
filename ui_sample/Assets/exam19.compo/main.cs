using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

using UniRx;
using UniRx.Triggers;

namespace exam19
{
	public class main : MonoBehaviour
	{

		// Use this for initialization
		void Start ()
		{
			transform.FindChild ("Button_test").GetComponent<Button> ().OnClickAsObservable ()
				.Subscribe (_ => {

					com_gunpower_ui.AlertDlgBox dlg = com_gunpower_ui.AlertDlgBox.createInstance(transform);
					dlg.show("test","hihi","ok");
			});
		
		}
	
		// Update is called once per frame
		void Update ()
		{
		
		}
	}

}

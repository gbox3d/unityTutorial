using UnityEngine;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

using UniRx;
using UniRx.Triggers;

using UnityEngine.UI;

using LitJson;

using System.Linq;

namespace com_gunpower_ui
{

	public class yesno_dlg : MonoBehaviour
	{
	
		public delegate void dg_CallBack (bool is_yes);

		dg_CallBack m_CallbackBtn;


		public static yesno_dlg createInstance(Transform parent)
		{
			GameObject prefeb = Resources.Load ("gunpowerUI/yesno_dlg/yesno_dlg",typeof(GameObject)) as GameObject;

			GameObject dlgbox = GameObject.Instantiate (prefeb,parent) as GameObject;

			return dlgbox.GetComponent<yesno_dlg>();
			
		}

		public void show (string title, string msg, dg_CallBack callback)
		{
			transform.localPosition = new Vector3 (0, 0, 0);
			transform.FindChild ("header/Text").GetComponent<Text> ().text = title;
			transform.FindChild ("body/Text").GetComponent<Text> ().text = msg;

			m_CallbackBtn = callback;

			gameObject.SetActive (true);

		}

		public void close ()
		{
			//m_CallbackBtn();
			gameObject.SetActive (false);
			Destroy (gameObject, 0.5f);
		}

		// Use this for initialization
		void Start ()
		{

			transform.FindChild ("body/Button_yes").GetComponent<Button> ().OnClickAsObservable ().Subscribe ((obj) => {
				m_CallbackBtn (true);
				close ();
			});

			transform.FindChild ("body/Button_no").GetComponent<Button> ().OnClickAsObservable ().Subscribe ((obj) => {
				m_CallbackBtn (false);
				close ();

			});
		
		}
	
		// Update is called once per frame
		void Update ()
		{
		
		}


	}

}
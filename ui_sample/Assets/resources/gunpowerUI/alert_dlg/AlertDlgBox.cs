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
	public class AlertDlgBox : MonoBehaviour
	{
		public Text m_textMsg;
		public Button m_close_Btn;

		public delegate void dg_CallBack ();

		dg_CallBack m_CallbackBtn;
		bool m_reUse = false;

		//[SerializeField] static GameObject m_prefebObj;

		public static AlertDlgBox createInstance(Transform parent)
		{
			GameObject prefeb = Resources.Load ("gunpowerUI/alert_dlg/AlertDlgBox",typeof(GameObject)) as GameObject;

			GameObject dlgbox = GameObject.Instantiate (prefeb,parent) as GameObject;

			return dlgbox.GetComponent<AlertDlgBox>();

		}


		public void show (string title, string msg, string btn_text, dg_CallBack callback = null, bool reuse = false)
		{
			m_reUse = reuse;
			transform.localPosition = new Vector3 (0, 0, 0);
			transform.FindChild ("header/Text").GetComponent<Text> ().text = title;
			transform.FindChild ("body/Text").GetComponent<Text> ().text = msg;
			transform.FindChild ("body/Button/Text").GetComponent<Text> ().text = btn_text;

			m_CallbackBtn = callback;

			gameObject.SetActive (true);

		}

		public void close ()
		{
			if (m_CallbackBtn != null) {
				m_CallbackBtn ();
			}

			gameObject.SetActive (false);
			if (!m_reUse) {
				Destroy (gameObject, 0.5f);
			}
		}

		// Use this for initialization
		void Start ()
		{
			m_close_Btn.OnClickAsObservable ()
		           .Subscribe ((obj) => {			
				close ();			
			}).AddTo (this);
			
		}
	
		// Update is called once per frame
		void Update ()
		{
		
		}
	}

}
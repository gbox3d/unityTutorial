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
	
	public class input_dlg : MonoBehaviour
	{

		[SerializeField]GameObject m_header;
		[SerializeField]GameObject m_Input;

		[SerializeField]Button m_btnOk;
		[SerializeField]Button m_btnCancel;

		public delegate void dg_CallBack (JsonData datJson);

		dg_CallBack m_CallbackBtn;

		bool m_reUse = false;

		public static input_dlg createInstance(Transform parent)
		{
			GameObject prefeb = Resources.Load ("gunpowerUI/input_dlg/input_dlg",typeof(GameObject)) as GameObject;
			GameObject dlgbox = GameObject.Instantiate (prefeb,parent) as GameObject;

			return dlgbox.GetComponent<input_dlg>();
		}

		public void show (string title, string strVal, dg_CallBack callback,bool isReUse=false)
		{
			transform.localPosition = new Vector3 (0, 0, 0);
			m_header.transform.FindChild ("Text").GetComponent<Text> ().text = title;
			m_Input.GetComponent<InputField> ().text = strVal;
			m_CallbackBtn = callback;
			m_reUse = isReUse;
			gameObject.SetActive (true);

		}

		public void close ()
		{
			//m_CallbackBtn();
			gameObject.SetActive (false);
			if (m_reUse == false) {
				Destroy (gameObject, 0.5f);
			}
		
		}

		// Use this for initialization
		void Start ()
		{
			//m_Input = transform.FindChild("body/InputField").gameObject;

			m_btnOk.OnClickAsObservable ().Subscribe ((obj) => {

				string strTemp = m_Input.transform.FindChild ("Text").GetComponent<Text> ().text;

				if (strTemp.Length > 0) {
					JsonData json_obj = new JsonData();
					json_obj["ok"] = true;
					json_obj["val"] = strTemp;
					m_CallbackBtn (json_obj);
					close ();
				}
			
			});

			m_btnCancel.OnClickAsObservable ().Subscribe ((obj) => {
				JsonData json_obj = new JsonData();
				json_obj["ok"] = false;
				//json_obj["val"] = strTemp;
				m_CallbackBtn (json_obj);
				close ();

			});

		}
	
		// Update is called once per frame
		void Update ()
		{
		
		}
	}

}
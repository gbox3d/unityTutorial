using UnityEngine;

using System;
using System.Text;
using System.Net;
using System.Net.Sockets;

using System.Collections;
using System.Collections.Generic;


using System.Threading;

using UniRx;
using UniRx.Triggers;

using UnityEngine.UI;

using LitJson;

namespace com_gunpower_ui
{

	public class fileinfoItem : MonoBehaviour
	{
		public string m_fileinfo_strName;
		public int m_fileinfo_nSize;

		public GameObject m_textFileName;

		public Subject<string> m_OnSelect = new Subject<string>();


		public void init(string strName,int nSize)
		{
			m_fileinfo_nSize = nSize;
			m_fileinfo_strName = strName;

			m_textFileName.GetComponent<Text> ().text = strName + "," + nSize;

		}

		public void remove()
		{
			Destroy (gameObject);
		}

		// Use this for initialization
		void Start ()
		{

			this.UpdateAsObservable ().Subscribe (_=> {
				if(Input.GetMouseButtonUp(0)) {
					if( RectTransformUtility.RectangleContainsScreenPoint( transform.GetComponent<RectTransform>() ,Input.mousePosition)) {
						//Debug.Log("select :" + m_fileinfo_strName); 
						m_OnSelect.OnNext(m_fileinfo_strName);
					}
				}
			});
		
		}
	
		// Update is called once per frame
		void Update ()
		{
		
		}
	}

}
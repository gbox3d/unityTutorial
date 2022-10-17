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

	public class FileDlg : MonoBehaviour
	{
		[SerializeField] GameObject m_preFebListItem;
		[SerializeField] GameObject m_btnOk;
		[SerializeField] GameObject m_btnCancel;
		[SerializeField] GameObject m_edtFilePath;
		[SerializeField] GameObject m_fileListView;

		//public delegate void cbdg_string();
		public delegate void dgcb_string(string val);

		public Subject<string> m_OnSelectOK;// = new Subject<string> ();
		public Subject<string> m_OnCancel;// = new Subject<string> ();

		GameObject m_SelectItem;

		private bool m_reUse = true;

		void refresh()
		{

			com_gunpower_ui.fileinfoItem[] items =  m_fileListView.GetComponentsInChildren<com_gunpower_ui.fileinfoItem> ();

			for (int i = 0; i < items.Length; i++) {

				GameObject node = items [i].gameObject;
				node.transform.localPosition = new Vector2 ( 
					0,0 - ((i) * node.GetComponent<RectTransform>().sizeDelta.y)
				);

			}
		}

		public void addItem(string strName,int nSize) {
			
			Transform node = GameObject.Instantiate(m_preFebListItem,m_fileListView.transform).transform;
			//node.FindChild("Text").GetComponent<Text>().text = "test";

			node.GetComponent<com_gunpower_ui.fileinfoItem> ().init (strName, nSize);
			node.GetComponent<com_gunpower_ui.fileinfoItem> ().m_OnSelect.Subscribe (_ => {
				m_SelectItem = node.gameObject;
				Debug.Log("select : " +  m_SelectItem.GetComponent<com_gunpower_ui.fileinfoItem> ().m_fileinfo_strName);
				m_edtFilePath.GetComponent<InputField>().text = m_SelectItem.GetComponent<com_gunpower_ui.fileinfoItem> ().m_fileinfo_strName;
			}).AddTo(this);

			refresh ();

			m_fileListView.GetComponent<RectTransform>().sizeDelta = 
				new Vector2(m_fileListView.GetComponent<RectTransform>().sizeDelta.x,
					( node.GetComponent<RectTransform>().sizeDelta.y * m_fileListView.transform.childCount) );


		}

		void clearAllListItem() {

			com_gunpower_ui.fileinfoItem[] items = m_fileListView.transform.GetComponentsInChildren<com_gunpower_ui.fileinfoItem> ();
			m_fileListView.transform.DetachChildren ();

			foreach (com_gunpower_ui.fileinfoItem item in items) {
				item.remove ();
			}
		}

		public void show(JsonData jsnDat,bool reUse=true,Subject<string> OnSelect=null, Subject<string> OnCencel=null)
		{
			if (OnSelect != null) {
				m_OnSelectOK = OnSelect;
			}

			if (OnCencel != null ) {
				m_OnCancel = OnCencel;
			}

			m_edtFilePath.GetComponent<InputField> ().text = "";
			clearAllListItem ();
			m_SelectItem = null;

			foreach (string key in jsnDat.Keys) {

				//Debug.Log (jsnDat [key]);
				addItem (key,   int.Parse( jsnDat[key].ToString() ));
			}
			gameObject.SetActive (true);
		}


		public void close()
		{
			m_OnSelectOK.Dispose ();
			m_OnCancel.Dispose ();



			gameObject.SetActive(false);
			if (!m_reUse) {
				Destroy (gameObject);
			}
		}



		// Use this for initialization
		void Start ()
		{

			m_btnOk.GetComponent<Button> ().OnClickAsObservable ().Subscribe (_ => {

				if(m_edtFilePath.GetComponent<InputField>().text.Length > 0) {
					m_OnSelectOK.OnNext(
						//m_SelectItem.GetComponent<com_gunpower_ui.fileinfoItem>().m_fileinfo_strName
						m_edtFilePath.GetComponent<InputField>().text
					);
					close();
				}
			});

			m_btnCancel.GetComponent<Button> ().OnClickAsObservable ().Subscribe (_ => {
				//gameObject.SetActive(false);
//				Debug.Log("click");
				if(m_OnCancel != null) {
					m_OnCancel.OnNext("");
				}
				close();

			});
		
		}
	
		// Update is called once per frame
		void Update ()
		{
		
		}
	}

}
using UnityEngine;

using System;
using System.IO;
using System.Text;
using System.Net;
using System.Net.Sockets;

using System.Collections;
using System.Collections.Generic;


using UniRx;
using UniRx.Triggers;

using UnityEngine.UI;

using LitJson;

namespace com_advexam_system_fileio4
{
	
	public class main : MonoBehaviour
	{
		[SerializeField] Text m_textLog;
		[SerializeField] InputField m_inputName;

		// Use this for initialization
		void Start ()
		{
			transform.FindChild ("Button_getlist_file").GetComponent<Button> ().OnClickAsObservable ()
				.Subscribe (_ => {
					DirectoryInfo dir = new DirectoryInfo ( com_gunpower_system.myFileUtils.pathForDocumentsFile ("./"));
					FileInfo[] info = dir.GetFiles ("*.*");

					m_textLog.text = "";

					foreach (FileInfo f in info) {
						Debug.Log (f.Name + "," + f.Length + "," + f.DirectoryName + "," + f.FullName);
						m_textLog.text += f.Name + "\n";

						//file_list [f.Name] = f.Length;
					}
			});

			transform.FindChild ("Button_getlist_dir").GetComponent<Button> ().OnClickAsObservable ()
				.Subscribe (_ => {
					DirectoryInfo dir = new DirectoryInfo ( com_gunpower_system.myFileUtils.pathForDocumentsFile ("./"));
					DirectoryInfo[] info = dir.GetDirectories ();

					m_textLog.text = "";
					foreach (DirectoryInfo d in info) {
						Debug.Log (d.Name + "," + d.FullName);
						m_textLog.text += d.Name + "\n";
						//file_list [f.Name] = f.Length;
					}
					
			});

			transform.FindChild ("Button_create_dir").GetComponent<Button> ().OnClickAsObservable ()
				.Subscribe (_ => {
					Directory.CreateDirectory ( com_gunpower_system.myFileUtils.pathForDocumentsFile (m_inputName.GetComponent<InputField>().text));
					
			});

			transform.FindChild ("Button_del_dir").GetComponent<Button> ().OnClickAsObservable ()
				.Subscribe (_ => {
					Directory.Delete( com_gunpower_system.myFileUtils.pathForDocumentsFile (m_inputName.GetComponent<InputField>().text) );

				});

		
		}
	
		// Update is called once per frame
		void Update ()
		{
		
		}
	}

}
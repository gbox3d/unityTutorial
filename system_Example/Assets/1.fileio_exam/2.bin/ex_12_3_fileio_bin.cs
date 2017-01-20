using UnityEngine;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

using System.IO;

using UniRx;
using UniRx.Triggers;

using UnityEngine.UI;

using LitJson;

public class ex_12_3_fileio_bin : MonoBehaviour
{

	// Use this for initialization
	void Start()
	{

		transform.FindChild("Button_1").GetComponent<Button>().OnClickAsObservable()
				 .Subscribe(_ =>
				 {
					 FileStream file = new FileStream("test.bin", FileMode.Create, FileAccess.Write);

					 byte[] buffer = { 104, 101, 108, 108, 111, 0 };

					 file.Write(buffer, 0, 6);

					 file.Close();


					 FileStream file_out = new FileStream("test.bin", FileMode.Open, FileAccess.Read);
					 buffer = new byte[10];
					 file_out.Position = 1; // file position
					 file_out.Read(buffer,
						 0, 3 // buffer array position
					 );

					 int count = 0;
					 foreach (byte data in buffer)
					 {
						 Debug.Log(count + " : " + data);
						 count++;
					 }

					 file.Close();

				 });

		transform.FindChild("Button_2").GetComponent<Button>().OnClickAsObservable()
				 .Subscribe(_ =>
				 {
					 Debug.Log(Application.dataPath);
					 Debug.Log(Application.persistentDataPath);
					 Debug.Log(Application.streamingAssetsPath);

					 transform.FindChild("Text_data_path").GetComponent<Text>().text = Application.dataPath;
					 transform.FindChild("Text_persist_Path").GetComponent<Text>().text = Application.persistentDataPath;
					 transform.FindChild("Text_streaming_path").GetComponent<Text>().text = Application.streamingAssetsPath;

				 });

	}

	// Update is called once per frame
	void Update()
	{

	}
}

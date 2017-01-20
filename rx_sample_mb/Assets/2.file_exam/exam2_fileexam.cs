using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

using UniRx;
using UniRx.Triggers;

using System;
using System.IO;

//using LitJson;

public class exam2_fileexam : MonoBehaviour
{

	[SerializeField]
	Button m_btnTest1;

	[SerializeField]
	InputField m_infLog;


	public void writeStringToFile(string str, string filename)
	{
#if !WEB_BUILD
		string path = pathForDocumentsFile(filename);
		FileStream file = new FileStream(path, FileMode.Create, FileAccess.Write);

		StreamWriter sw = new StreamWriter(file);
		sw.WriteLine(str);

		sw.Close();
		file.Close();
#endif
	}


	public string readStringFromFile(string filename)//, int lineIndex )
	{
#if !WEB_BUILD
		string path = pathForDocumentsFile(filename);

		if (File.Exists(path))
		{
			FileStream file = new FileStream(path, FileMode.Open, FileAccess.Read);
			StreamReader sr = new StreamReader(file);


			string str = null;
			//str = sr.ReadLine ();
			str = sr.ReadToEnd();

			sr.Close();
			file.Close();

			return str;
		}

		else
		{
			return null;
		}
#else
		return null;
#endif
	}

	// 파일쓰고 읽는넘보다 이놈이 핵심이죠
	public string pathForDocumentsFile(string filename)
	{
		if (Application.platform == RuntimePlatform.IPhonePlayer)
		{
			string path = Application.dataPath.Substring(0, Application.dataPath.Length - 5);
			path = path.Substring(0, path.LastIndexOf('/'));
			return Path.Combine(Path.Combine(path, "Documents"), filename);
		}

		else if (Application.platform == RuntimePlatform.Android)
		{
			string path = Application.persistentDataPath;
			path = path.Substring(0, path.LastIndexOf('/'));
			return Path.Combine(path, filename);
		}

		else
		{
			string path = Application.dataPath;
			path = path.Substring(0, path.LastIndexOf('/'));
			return Path.Combine(path, filename);
		}
	}

	// Use this for initialization
	void Start()
	{
		writeStringToFile("hello", "test1234.txt");

		m_btnTest1.OnClickAsObservable().Subscribe((obj) =>
		{
			m_infLog.text = pathForDocumentsFile("test1234.txt");

		});


	}

	// Update is called once per frame
	void Update()
	{

	}
}

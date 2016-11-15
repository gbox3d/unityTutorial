using UnityEngine;
using System.Collections;

using System;
using System.IO;

using LitJson;

public class ex12_2_fileio_1 : MonoBehaviour {

	//http://blog.naver.com/nameisljk/110157303742

	public void writeStringToFile( string str, string filename )
	{
		#if !WEB_BUILD
		string path = pathForDocumentsFile( filename );
		FileStream file = new FileStream (path, FileMode.Create, FileAccess.Write);

		StreamWriter sw = new StreamWriter( file );
		sw.WriteLine( str );

		sw.Close();
		file.Close();
		#endif 
	}


	public string readStringFromFile( string filename)//, int lineIndex )
	{
		#if !WEB_BUILD
		string path = pathForDocumentsFile( filename );

		if (File.Exists(path))
		{
			FileStream file = new FileStream (path, FileMode.Open, FileAccess.Read);
			StreamReader sr = new StreamReader( file );


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
	public string pathForDocumentsFile( string filename ) 
	{ 
		if (Application.platform == RuntimePlatform.IPhonePlayer)
		{
			string path = Application.dataPath.Substring( 0, Application.dataPath.Length - 5 );
			path = path.Substring( 0, path.LastIndexOf( '/' ) );
			return Path.Combine( Path.Combine( path, "Documents" ), filename );
		}

		else if(Application.platform == RuntimePlatform.Android)
		{
			string path = Application.persistentDataPath; 
			path = path.Substring(0, path.LastIndexOf( '/' ) ); 
			return Path.Combine (path, filename);
		} 

		else 
		{
			string path = Application.dataPath; 
			path = path.Substring(0, path.LastIndexOf( '/' ) );
			return Path.Combine (path, filename);
		}
	}

	// Use this for initialization
	void Start () {

		writeStringToFile ("hello","test1234.txt");
		Debug.Log ("test");

		string temp = readStringFromFile ("test1234.txt");

		Debug.Log (temp);

		JsonData test_json = new JsonData ();
		test_json ["test_int"] = 1;
		test_json ["test_str"] = "hello json";
		test_json["test_array"] =  JsonMapper.ToObject("[1,2,3]");

		//Debug.Log (test_json.ToJson());
		//json save
		writeStringToFile (test_json.ToJson(),"hello.json");

		//json load
		temp = readStringFromFile ("hello.json");
		test_json = JsonMapper.ToObject (temp);
		Debug.Log (test_json.ToJson());

	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

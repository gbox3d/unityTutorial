using UnityEngine;
using System.Collections;

using System;
using System.IO;

using LitJson;
public class ex_12_3_fileio_bin : MonoBehaviour {

	// Use this for initialization
	void Start () {

		FileStream file = new FileStream ("test.bin", FileMode.Create, FileAccess.Write);

		byte[] buffer =  {104,101,108,108,111,0};

		file.Write (buffer,0,6);

		file.Close ();


		FileStream file_out = new FileStream ("test.bin", FileMode.Open, FileAccess.Read); 
		buffer = new byte[10];
		file_out.Position = 1; // file position
		file_out.Read (buffer, 
			0, 3 // buffer array position
		);

		int count = 0;
		foreach (byte data in buffer) {
			Debug.Log (count  + " : " + data);
			count++;
		}

		file.Close ();

	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

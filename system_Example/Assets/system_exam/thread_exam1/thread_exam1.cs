using UnityEngine;
using System.Collections;

using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

using UniRx;
using UniRx.Triggers;
using UnityEngine.UI;

public class thread_exam1 : MonoBehaviour {

	// receiving Thread
	Thread receiveThread;

	// Use this for initialization
	void Start () {

		Debug.Log("start udp Thread");
		receiveThread = new Thread(
			new ThreadStart(ReceiveData));
		receiveThread.IsBackground = true;
		receiveThread.Start();
		
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	// receive thread
	private  void ReceiveData()
	{
		//client = new UdpClient(portLocal);
		while (true)
		{

			try
			{
				Thread.Sleep(1000);
				Debug.Log("tick :");

			}
			catch (Exception err)
			{
				print(err.ToString());
			}
		}
	}

}

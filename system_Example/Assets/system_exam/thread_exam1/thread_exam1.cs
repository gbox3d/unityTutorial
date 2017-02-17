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
	bool m_isRun;

	[SerializeField] Button m_btnEndThread;

	// receive thread
	private  void ReceiveData()
	{
		//client = new UdpClient(portLocal);
		int nCount = 1;
		while (m_isRun)
		{

			try
			{
				Thread.Sleep(1000);
				Debug.Log("tick :" + nCount++);

			}
			catch (Exception err)
			{
				print(err.ToString());
			}
		}

		Debug.Log ("thread end");

	}

	// Use this for initialization
	void Start () {

		m_isRun = true;

		Debug.Log("start udp Thread");
		receiveThread = new Thread(
			new ThreadStart(ReceiveData));
		receiveThread.IsBackground = true;
		receiveThread.Start();

		m_btnEndThread.OnClickAsObservable ()
			.Subscribe (_ => {
				m_isRun = false;
		});

		Observable.OnceApplicationQuit ()
			.Subscribe (_ => {
				Debug.Log("OnceApplicationQuit");
				m_isRun = false;
			}).AddTo(this);
	}


}

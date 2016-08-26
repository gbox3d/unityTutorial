using UnityEngine;
using System.Collections;

using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

using UniRx;
using UnityEngine.UI;

public class udpex1_3_main : MonoBehaviour {

	private static int localPort;

	// prefs
	private string IP;  // define in init
	public int port;  // define in init

	// "connection" things
	IPEndPoint remoteEndPoint;
	UdpClient client;

	// gui
	//string strMessage="";

	[SerializeField] private Button BtnTest;

	// Use this for initialization
	void Start () {

		init ();
		BtnTest.onClick.AsObservable ()
			.Subscribe (
				_=> {
					sendString("hello unity udp");
				}
			);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void init()
	{
		// Endpunkt definieren, von dem die Nachrichten gesendet werden.
		print("UDPSend.init()");

		// define
		IP="127.0.0.1";
		port=33333;

		// ----------------------------
		// Senden
		// ----------------------------
		remoteEndPoint = new IPEndPoint(IPAddress.Parse(IP), port);
		client = new UdpClient();

		// status
		print("Sending to "+IP+" : "+port);
		print("Testing: nc -lu "+IP+" : "+port);

	}

	// sendData
	private void sendString(string message)
	{
		try
		{
			//if (message != "")
			//{

			// Daten mit der UTF8-Kodierung in das Binärformat kodieren.
			byte[] data = Encoding.UTF8.GetBytes(message);

			// Den message zum Remote-Client senden.
			client.Send(data, data.Length, remoteEndPoint);
			//}
		}
		catch (Exception err)
		{
			print(err.ToString());
		}
	}



}

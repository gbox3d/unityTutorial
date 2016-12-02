using UnityEngine;
using System.Collections;

using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

public class udpex1_2_main : MonoBehaviour {

	// receiving Thread
	Thread receiveThread;

	// public
	// public string IP = "127.0.0.1"; default local
	public int port; // define > init

	// infos
	//public string lastReceivedUDPPacket="";
	//public string allReceivedUDPPackets=""; // clean up this from time to time!

	// Use this for initialization
	void Start () {

		// define port
		//port = 33334;
		Debug.Log("start udp Thread");
		receiveThread = new Thread(
			new ThreadStart(ReceiveData));
		receiveThread.IsBackground = true;
		receiveThread.Start();

	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// udpclient object
	UdpClient client;

	// receive thread
	private  void ReceiveData()
	{
		client = new UdpClient(port);
		while (true)
		{

			try
			{
				// Bytes empfangen.
				IPEndPoint anyIP = new IPEndPoint(IPAddress.Any, 0);
				byte[] data = client.Receive(ref anyIP);

				// Bytes mit der UTF8-Kodierung in das Textformat kodieren.
				string text = Encoding.UTF8.GetString(data);

				// Den abgerufenen Text anzeigen.
				print(">> " + text);

				// latest UDPpacket
				//lastReceivedUDPPacket=text;
				// ....
				//allReceivedUDPPackets=allReceivedUDPPackets+text;
				//allReceivedUDPPackets

			}
			catch (Exception err)
			{
				print(err.ToString());
			}
		}
	}

	void OnDestroy() {
		Debug.Log("Script was destroyed");
		receiveThread.Abort ();
	}

}

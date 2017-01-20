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


public class udpex2_main : MonoBehaviour {

	[SerializeField] private Button BtnSend;
	[SerializeField] private InputField InputSendData;
	[SerializeField] private Text textResultOut;

	[SerializeField] private int portRemote;
	[SerializeField] private int portLocal;

	// receiving Thread
	Thread receiveThread;
	// udpclient object
	UdpClient client;
	IPEndPoint remoteEndPoint;


	public string allReceivedUDPPackets=""; // clean up this from time to time!

	void clearBuffer() {
		lock(allReceivedUDPPackets) {
			allReceivedUDPPackets = "";
		}
	}

	// Use this for initialization
	void Start () {

		Debug.Log("start udp Thread");
		receiveThread = new Thread(
			new ThreadStart(ReceiveData));
		receiveThread.IsBackground = true;
		receiveThread.Start();

		remoteEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), portRemote);

		gameObject.AddComponent<ObservableUpdateTrigger> ()
			.UpdateAsObservable ()
			.Select(x=>allReceivedUDPPackets)
			.DistinctUntilChanged()
			.Where(x=> x.Length >0 )
			.Subscribe (
				x=> {
					textResultOut.text += x;
					clearBuffer();

					Debug.Log("change");

				}
			).AddTo(gameObject);

		BtnSend.onClick.AsObservable ()
			.Subscribe (_=>{
				Debug.Log(InputSendData.text);
				sendString(InputSendData.text);

			});
	
	}


	// receive thread
	private  void ReceiveData()
	{
		client = new UdpClient(portLocal);
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

				//textResultOut.text += text;

				// latest UDPpacket
				//lastReceivedUDPPacket=text;
				// ....
				allReceivedUDPPackets = allReceivedUDPPackets+text;


				//textResultOut.text = allReceivedUDPPackets;

			}
			catch (Exception err)
			{
				print(err.ToString());
			}
		}
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

	void OnDestroy() {
		Debug.Log("Script was destroyed");
		client.Close ();
		receiveThread.Abort ();


	}
}

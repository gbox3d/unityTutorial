using UnityEngine;

using System;
using System.Text;
using System.Net;
using System.Net.Sockets;

using UniRx;
using UniRx.Triggers;

using UnityEngine.UI;

using LitJson;

public class udpex3_main : MonoBehaviour {

	UdpClient udp_client;

	// Use this for initialization
	void Start () {

		Button btn_send = GameObject.Find ("Button_send").GetComponent<Button> ();
		Text text_displog = GameObject.Find ("Text_displog").GetComponent<Text> ();
		InputField input_packet = GameObject.Find ("Canvas/Panel/InputField").GetComponent<InputField> ();

		udp_client = new UdpClient(8086);
		IObservable<JsonData> heavyMethod = Observable.Start(() =>
			{
				try
				{
					// Bytes empfangen.
					IPEndPoint anyIP = new IPEndPoint(IPAddress.Any, 0);
					byte[] data = udp_client.Receive(ref anyIP);
					// Bytes mit der UTF8-Kodierung in das Textformat kodieren.
					string text = Encoding.UTF8.GetString(data);

					JsonData jsonObj = JsonMapper.ToObject(text);
					//get remote ip,port 
					//http://stackoverflow.com/questions/1314671/how-do-i-find-the-port-number-assigned-to-a-udp-client-in-net-c
					jsonObj["ip"] = anyIP.Address.ToString();
					jsonObj["port"] = anyIP.Port;

					return jsonObj;

				}
				catch (Exception err)
				{
					print(err.ToString());
				}

				return null;
			});

		// Join and await two other thread values
		Observable.ObserveOnMainThread (heavyMethod) // return to main thread
			.Repeat ()
			.TakeUntilDestroy (this)
			.Subscribe (xs => 
				{
					Debug.Log(xs["ip"] + ":" + xs["port"] );

					text_displog.text = xs.ToJson();

				}).AddTo (this.gameObject);


		//send 
		btn_send.OnClickAsObservable ()
			.Subscribe (_=> 
				{
					try {
						IPEndPoint remoteEndPoint;
						remoteEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8086); //to self

						JsonData packet = new JsonData();

						packet["cmd"] = "echo";
						packet["data"] = input_packet.text;

						string message = packet.ToJson();
						Debug.Log("send : " + message);
						byte[] data = Encoding.UTF8.GetBytes(message);
						udp_client.Send(data, data.Length, remoteEndPoint);
					}
					catch (Exception err)
					{
						print(err.ToString());
					}



					
				}
			);

	
	}
	
	// Update is called once per frame
	void Update () {
	
	}



}

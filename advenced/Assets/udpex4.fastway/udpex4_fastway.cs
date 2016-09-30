using UnityEngine;
using System.Collections;

using UniRx;
//using UdpReceiverUniRx;

using System.Net;
using System.Net.Sockets;

using System.Threading;

//http://qiita.com/Napier_271828_/items/0d489c7d833047241079

public class UdpState : System.IEquatable<UdpState>
{
	//UDP通信の情報を収める。送受信ともに使える
	public IPEndPoint EndPoint {get; set;}
	public string UdpMsg {get; set;}

	public UdpState(IPEndPoint ep, string udpMsg)
	{
		this.EndPoint = ep;
		this.UdpMsg = udpMsg;
	}
	public override int GetHashCode() {
		return EndPoint.Address.GetHashCode();
	}

	public bool Equals(UdpState s)
	{
		if ( s == null ) {
			return false;
		}
		return EndPoint.Address.Equals(s.EndPoint.Address);
	}
}


public class udpex4_fastway : MonoBehaviour {

	//public  UdpReceiverRx  _udpReceiverRx; 
	//private  IObservable < UdpState >  _udpSequence ; 

	private int listenPort = 8086;
	private static UdpClient myClient;
	private bool isAppQuitting;
	public IObservable<UdpState> _udpSequence;

	// Use this for initialization
	void  Start ()  { 

		isAppQuitting = false;

		_udpSequence  =  Observable.Create < UdpState > ( observer  => 
			{ 
				Debug . Log ( string.Format ( "_udpSequence thread : {0}" ,  Thread.CurrentThread.ManagedThreadId )); 
				try 
				{ 
					myClient  =  new  UdpClient ( listenPort ); 
				} 
				catch  ( SocketException  ex ) 
				{ 
					observer . OnError ( ex ); 
				} 
				IPEndPoint  remoteEP  =  null ; 
				myClient . EnableBroadcast  =  true ; 
				//myClient . Client . ReceiveTimeout  =  5000 ; 
				while  (! isAppQuitting ) 
				{ 
					try 
					{ 
						remoteEP  =  null ; 
						var  receivedMsg  =  System . Text . Encoding . ASCII . GetString ( myClient . Receive ( ref  remoteEP )) ; 
						observer . OnNext ( new  UdpState ( remoteEP ,  receivedMsg )); 
					} 
					catch  ( SocketException ) 
					{ 
						Debug . Log ( "UDP :: Receive timeout" ); 
					} 
				} 
				observer . OnCompleted (); 
				return  null ; 
			}) 
			. SubscribeOn ( Scheduler . ThreadPool ) 
			. Publish () 
			. RefCount (); 


		//myUdpSequence  =  _udpReceiverRx . _udpSequence ; 


		_udpSequence 
			. ObserveOnMainThread () 
			. Subscribe ( x  => { 
				print ( x . UdpMsg ); 
			}) 
			. AddTo ( this ); 

	} 

	// Update is called once per frame
	void Update () {
	
	}

	void OnApplicationQuit()
	{
		isAppQuitting = true;
		myClient.Client.Blocking = false;
	}


}

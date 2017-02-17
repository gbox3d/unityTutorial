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

using LitJson;


namespace thread_exam_2
{

	public class main : MonoBehaviour
	{
		bool m_isAppQuitting;
		[SerializeField] Button m_BtnEnd;

		public System.IDisposable _udpSequence;

		// Use this for initialization
		void Start ()
		{
			m_isAppQuitting = false;
			_udpSequence = Observable.Create < JsonData > ( observer  => 
				{ 
					int nCount=1;
					
					while  (! m_isAppQuitting ) 
					{ 
						Thread.Sleep(1000);
						Debug.Log("tick ");
						JsonData test_json = new JsonData();
						test_json["count"] = nCount++;
						observer . OnNext (test_json);
					} 
					Debug.Log("thread finish");
					observer . OnCompleted (); 
					return  null ; 
				}) 
				. SubscribeOn ( Scheduler . ThreadPool ) 
				. Publish () 
				. RefCount () 
				. ObserveOnMainThread () 
				. Subscribe ( x  => { 
					Debug.Log ( x.ToJson() );
				}) 
				. AddTo ( this ); 

			m_BtnEnd.onClick.AsObservable().Subscribe (_ => {
				Debug.Log("dispose thread");
				_udpSequence.Dispose ();

			});


			Observable.OnceApplicationQuit ().Subscribe (_ => {

				Debug.Log("app quit");
				_udpSequence.Dispose ();
				
			}).AddTo(this);



		
		}
	
	}

}

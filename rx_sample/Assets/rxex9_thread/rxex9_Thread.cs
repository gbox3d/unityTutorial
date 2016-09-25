using UnityEngine;
using System;

using UniRx;
using UniRx.Triggers;

public class rxex9_Thread : MonoBehaviour {

	class TestCls {
		public string m_strName;
		public int m_nCount;

		public TestCls() {
			m_strName = "";
			m_nCount = 0;
			
		}

	}

	// Use this for initialization
	void Start () {

		int count = 0;
		IObservable<int> heavyMethod = Observable.Start(() =>
			{
				// heavy method...
				System.Threading.Thread.Sleep(TimeSpan.FromSeconds(2.3));
				count++;
				return count;
			});

		Observable
			.ObserveOnMainThread (heavyMethod)
			.Repeat ()
			.TakeUntilDestroy (this)
			.Subscribe (xs => 
				{
					Debug.Log("count : " + xs);
				}
		).AddTo (this.gameObject);

		TestCls tempCls = new TestCls ();
		tempCls.m_strName = "Thready";
		IObservable<TestCls> heavyMethod2 = Observable.Start(() =>
			{
				// heavy method...
				System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1.7));
				//count++;
				//return count;
				tempCls.m_nCount++;
				return tempCls;
			});

		Observable
			.ObserveOnMainThread (heavyMethod2)
			.Repeat ()
			.TakeUntilDestroy (this)
			.Subscribe (xs => 
				{
					Debug.Log( xs.m_strName + ", count : " + xs.m_nCount);
				}
			).AddTo (this.gameObject);
		
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

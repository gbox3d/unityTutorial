using UnityEngine;

using System;
using System.Text;
using System.Net;
using System.Net.Sockets;

using System.Linq;

using UniRx;
using UniRx.Triggers;

using UnityEngine.UI;

using LitJson;


//http://answers.unity3d.com/questions/484792/sorting-an-array-using-linq-and-orderby.html

public class ex2_container_sort : MonoBehaviour {

	// Use this for initialization
	void Start () {
		ex2_container_sort_childobj[] temp =  gameObject.GetComponentsInChildren<ex2_container_sort_childobj> ();

		temp [0].m_hp = 100;
		temp [1].m_hp = 40;
		temp [2].m_hp = 90;
		temp [3].m_hp = 70;
		temp [4].m_hp = 50;

		//sort
		temp = temp.OrderBy (o => o.m_hp).ToArray ();

		for (int i = 0; i < temp.Length; i++) {
			//Debug.Log (temp [i].m_hp);
			//change child list index pos
			temp [i].gameObject.transform.SetSiblingIndex (i);
		}
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

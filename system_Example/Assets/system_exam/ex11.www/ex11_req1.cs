using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ex11_req1 : MonoBehaviour {

	//public string url = "http://images.earthcam.com/ec_metros/ourcams/fridays.jpg";
	private string url = "http://localhost:8080";

	public UnityEngine.UI.Text m_texOut;

	IEnumerator Req() {

		UnityEngine.UI.Text objText = transform.Find ("Text").GetComponent<UnityEngine.UI.Text> ();

		string strTemp = objText.text;
		objText.text = "wait";

		WWW www = new WWW(url);
		yield return www;

		Debug.Log(www.text);

		m_texOut.text = www.text;

		objText.text = strTemp;

	}


	public void StartReq() {
	

		StartCoroutine (Req ());

	}
}

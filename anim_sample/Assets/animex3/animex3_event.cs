using UnityEngine;
using System.Collections;

public class animex3_event : MonoBehaviour {

	public void setRed() {

		gameObject.GetComponent<Renderer> ().material.color = Color.red;
	}

	public void setWhite() {
		gameObject.GetComponent<Renderer> ().material.color = Color.white;
	}

}

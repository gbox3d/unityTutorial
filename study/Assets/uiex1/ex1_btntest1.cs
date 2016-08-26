using UnityEngine;
using System.Collections;

public class ex1_btntest1 : MonoBehaviour {

	public void HideCube()
	{
		gameObject.SetActive (false);
	}

	public void ShowCube()
	{
		gameObject.SetActive (true);
	}

}

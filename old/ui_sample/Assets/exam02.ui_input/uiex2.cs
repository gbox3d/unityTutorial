using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class uiex2 : MonoBehaviour {

	public UnityEngine.UI.InputField mInput;

	public void Start() {
		mInput = GameObject.Find ("test_inpfield").GetComponent<UnityEngine.UI.InputField> ();
	}

	public void update_input()
	{
		GetComponent<UnityEngine.UI.Text> ().text = mInput.text;
		
	}

}

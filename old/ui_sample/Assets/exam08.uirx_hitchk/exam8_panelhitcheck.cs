using UnityEngine;
using System.Collections;

using UniRx;
using UniRx.Triggers;

using UnityEngine.UI;

public class exam8_panelhitcheck : MonoBehaviour {

	[SerializeField] private RectTransform hitTest;
	//[SerializeField] private GameObject hitTestObj;
	//private GameObject testCube;

	public void setBox_Red(string name) {
		GameObject.Find(name).GetComponent<Renderer> ().material.color = Color.red;
	}
	public void setBox_White(string name) {
		GameObject.Find(name).GetComponent<Renderer> ().material.color = Color.white;
	}

	// Use this for initialization
	void Start () {


		hitTest.OnMouseDownAsObservable()
			.Subscribe(_=>
				{
					Debug.Log("hit");
					
				}
			);

		gameObject.OnMouseDownAsObservable ()
			.Subscribe (_=>
				{
					Debug.Log("hit");
					gameObject.GetComponent<Animator>().SetTrigger("hit1");
				
				}
			);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

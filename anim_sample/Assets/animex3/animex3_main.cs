using UnityEngine;
using System.Collections;
using UniRx;
using UniRx.Triggers;

public class animex3_main : MonoBehaviour {

	[SerializeField] private GameObject movingObject;

	// Use this for initialization
	void Start () {

		Animator anim = movingObject.GetComponent<Animator> ();
		int goNext_Hash = Animator.StringToHash("goNext");

		//var obUpdateTrigger = movingObject.AddComponent<ObservableUpdateTrigger> ();
		//obUpdateTrigger.UpdateAsObservable ()
		gameObject.UpdateAsObservable()
			.Select (_ => Input.GetButtonDown ("Fire1"))
			.Where (x => x)
			.Subscribe (
				(x)=> {
					//anim.SetTrigger("goNext");
					anim.SetTrigger(goNext_Hash);
					
				}
			);


	
	}

}

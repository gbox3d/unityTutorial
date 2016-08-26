using UnityEngine;
using System.Collections;
using UniRx;
using UniRx.Triggers;

public class animex3_main : MonoBehaviour {

	[SerializeField] private GameObject movingObject;

	// Use this for initialization
	void Start () {

		Animator anim = movingObject.GetComponent<Animator> ();
		var obUpdateTrigger = movingObject.AddComponent<ObservableUpdateTrigger> ();
		int goNext_Hash = Animator.StringToHash("goNext");

		obUpdateTrigger.UpdateAsObservable ()
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

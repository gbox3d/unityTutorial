using UnityEngine;
using System.Collections;

using UniRx;
using UniRx.Triggers;

public class sound_ex2_main : MonoBehaviour {

	// Use this for initialization
	void Start () {

		GameObject pf_Gunfire1;

		pf_Gunfire1 = Resources.Load ("prefebs/pf_gunfire_1", typeof(GameObject)) as GameObject;

		this.UpdateAsObservable ()
			.Where (_ => Input.GetButtonDown ("Fire1"))
			.Subscribe (_ => {
				GameObject obj = (GameObject)Instantiate(pf_Gunfire1,new Vector3(Random.Range(-5,5),0,0), new Quaternion() );
				Destroy(obj,2.5f);
		});


	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

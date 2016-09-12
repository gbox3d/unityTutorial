using UnityEngine;
using System.Collections;

public class ex5_eraser : MonoBehaviour {


	public float mfEraseTime;

	// Use this for initialization
	void Start () {
		if(mfEraseTime == 0) {
			mfEraseTime = GetComponent<ParticleSystem>().duration + GetComponent<ParticleSystem>().startLifetime;
		}
		Destroy( gameObject,mfEraseTime);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

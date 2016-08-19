using UnityEngine;
using System.Collections;

public class ex5_controller : MonoBehaviour {

	public GameObject mpfBullet;


	// Use this for initialization
	void Start () {

		//mpfBullet = (GameObject)Resources.Load ("prefabs/scene_5_pf_bullet", typeof(GameObject));
	
	}
	
	// Update is called once per frame
	void Update () {

		float tiltY = Input.GetAxis( "Horizontal") * 45.0f * Time.deltaTime;

		transform.Rotate( new Vector3( 0,tiltY,0 ) );

		if( Input.GetButtonDown ("Fire1") ) {
			Instantiate( mpfBullet, transform.position, transform.rotation);
		}
	
	}
}

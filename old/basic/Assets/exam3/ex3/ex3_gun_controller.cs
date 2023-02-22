using UnityEngine;
using System.Collections;

public class ex3_gun_controller : MonoBehaviour {

	public float mfSpeed;
	public GameObject pf_Bullet;
	public float mfTiltAngle;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		float tiltY = Input.GetAxis( "Horizontal") * mfTiltAngle * Time.deltaTime;
		float tiltX = Input.GetAxis( "Vertical") * mfTiltAngle * Time.deltaTime;

		//var target = Quaternion.Euler( tiltX, tiltY,0 );

		transform.Rotate( new Vector3( tiltX,tiltY,0 ) );

		if( Input.GetButtonDown ("Fire1") ) {
			Instantiate( pf_Bullet, 
				transform.position + transform.TransformDirection( Vector3.forward * mfSpeed) , 
				transform.rotation);
		}
	
	}
}

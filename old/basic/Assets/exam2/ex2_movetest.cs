using UnityEngine;
using System.Collections;

public class ex2_movetest : MonoBehaviour {

	public float mov_speed;
	public float rot_speed;

	private  Vector3 rot_vec;

	// Use this for initialization
	void Start () {

		rot_vec = new Vector3 (0, 0, 0);
	
	}

	// Update is called once per frame
	void Update () {

		float forwd = Input.GetAxis ("Vertical");
		transform.Translate (Vector3.forward * forwd * mov_speed * Time.deltaTime);

		float turn = Input.GetAxis ("Horizontal");
		rot_vec.y = turn * rot_speed * Time.deltaTime;
		transform.Rotate( rot_vec );
		//transform.Rotate( new Vector3(0,turn * rot_speed * Time.deltaTime) );
	
	}
}

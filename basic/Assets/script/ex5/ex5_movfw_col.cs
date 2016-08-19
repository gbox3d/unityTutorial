using UnityEngine;
using System.Collections;

public class ex5_movfw_col : MonoBehaviour {

	public GameObject mpfBoom;
	public float mfRange;
	private float mfTotaldist;

	// Use this for initialization
	void Start () {

		mfTotaldist = 0;
	
	}
	
	// Update is called once per frame
	void Update () {
		float diff_dist =  Time.deltaTime * 5.0f;

		mfTotaldist += diff_dist;

		if( mfTotaldist < mfRange ) {

			transform.Translate( Vector3.forward * diff_dist );
		}
		else {
			Debug.Log( "total_dist");
			Destroy( gameObject);
		}
	
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "target") {
			Debug.Log( "on collision :" + other.tag);
			Destroy(other.gameObject);
			Destroy( gameObject);
			//create particle
			Instantiate( mpfBoom, gameObject.transform.position, Quaternion.identity );
		} 
	}


}

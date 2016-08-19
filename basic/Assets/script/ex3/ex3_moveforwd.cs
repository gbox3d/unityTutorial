using UnityEngine;
using System.Collections;

public class ex3_moveforwd : MonoBehaviour {

	private float mfTotalDist;
	public float mfRange;

	// Use this for initialization
	void Start () {

		mfTotalDist = 0;
	
	}
	
	// Update is called once per frame
	void Update () {
		float diff_dist =  (float)(Time.deltaTime * 5.0);

		mfTotalDist += diff_dist;

		if( mfTotalDist < mfRange ) {

			transform.Translate( Vector3.forward * diff_dist );
		}
		else {
			//Debug.Log( total_dist);
			Destroy( gameObject );
		}
	
	}
}

using UnityEngine;
using System.Collections;

public class ex3_moveforwd_co : MonoBehaviour {

	//private float mfTotalDist;
	public float mfRange;
	public float mfSpeed;

	IEnumerator WaitDist(float dist_limit,float speed) {
		float total_dist = 0;
		bool loop = true;
		while(loop) {
			total_dist += Time.deltaTime * speed;
			if(total_dist > dist_limit) {
				loop = false;
			}
			yield return null;
		}

	}

	// Use this for initialization
	IEnumerator Start () {

		Debug.Log("start :" + this.GetInstanceID() );

		yield return StartCoroutine (WaitDist(mfRange,mfSpeed));

		Debug.Log("continue success destroy object :" + this.GetInstanceID() );
		Destroy( gameObject);
	
	}

	// Update is called once per frame
	void Update () {

		transform.Translate (Vector3.forward * Time.deltaTime * 5);
	
	}
}

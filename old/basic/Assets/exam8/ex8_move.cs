using UnityEngine;
using System.Collections;

public class ex8_move : MonoBehaviour {
	
	public float speed;
	public GameObject targetObj;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Vector3.MoveTowards(
			transform.position,
			targetObj.transform.position, 
			Time.deltaTime * speed);
	
	}

	void OnTriggerEnter( Collider coll)
	{
		if(coll.gameObject.tag == "target")
		{
			Destroy(coll.gameObject);
			Debug.Log(Time.time);
		}
	}
}

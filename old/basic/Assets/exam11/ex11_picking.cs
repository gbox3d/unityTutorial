using UnityEngine;
using System.Collections;

public class ex11_picking : MonoBehaviour {

	private GameObject mObjCache;

	// Use this for initialization
	void Start () {

		mObjCache = null;
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetButtonDown ("Fire1")) {
			Ray pickRay = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;

			if (Physics.Raycast (pickRay.origin, pickRay.direction, out hit, 100)) {

				if (mObjCache != hit.collider.gameObject) {
					if (mObjCache) {
						mObjCache.GetComponent<Renderer> ().material.color = Color.white;
					}
					mObjCache = hit.collider.gameObject;
					hit.collider.gameObject.GetComponent<Renderer> ().material.color = Color.red;
				}


			}
		}

	
	}
}

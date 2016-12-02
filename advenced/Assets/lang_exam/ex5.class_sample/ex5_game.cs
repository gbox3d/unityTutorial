using UnityEngine;
using System.Collections;

public class ex5_game : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Player player = new Player ();
		player.Experience = 5000;

		Debug.Log (player.Experience);
		Debug.Log (player.Level);

		player.Health = 100;

		Debug.Log (player.Health);
	
	
	}
	
	// Update is called once per frame
	void Update () {


	
	}
}

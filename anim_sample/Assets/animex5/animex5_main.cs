using UnityEngine;
using System.Collections;
using UniRx;
using UniRx.Triggers;

using UnityEngine.UI;


public class animex5_main : MonoBehaviour
{
	
	// Use this for initialization
	void Start ()
	{
		Animator animator = transform.FindChild ("Text").GetComponent<Animator>();

		transform.FindChild ("Button_start").GetComponent<Button> ().onClick.AsObservable ().Subscribe ((_) => {

			animator.Play("clip1"); //상태이름을 인자로 넣어준다.
		});

		transform.FindChild ("Button_change").GetComponent<Button> ().onClick.AsObservable ().Subscribe ((_) => {

			animator.Play("clip2");
		});

		transform.FindChild ("Button_loop").GetComponent<Button> ().onClick.AsObservable ().Subscribe ((_) => {

			animator.Rebind(); //스톱상태에서 다시 시작하려면 Rebind 
			animator.Play("clip3");
		});
		transform.FindChild("Button_stop").GetComponent<Button>().onClick.AsObservable().Subscribe((_) =>
		{
			animator.Stop();
		});


		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
}

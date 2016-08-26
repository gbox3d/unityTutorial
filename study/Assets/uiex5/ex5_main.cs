using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UniRx;

public class ex5_main : MonoBehaviour {

	[SerializeField] private Slider myslider ;
	[SerializeField] private Dropdown myDropDown;
	[SerializeField] private Toggle myToggle;

	[SerializeField] private Text mySliderValueText;
	[SerializeField] private Text myToggleText;
	[SerializeField] private Text myDropdownText;

	// Use this for initialization
	void Start () {

		mySliderValueText.text = myslider.value.ToString();
		myslider.onValueChanged.AsObservable ()
			.Subscribe (
				(val) => {
					mySliderValueText.text = val.ToString();
				}
			);

		myToggleText.text = myToggle.isOn.ToString();
		myToggle.onValueChanged.AsObservable()
			.Subscribe(
				(val)=> {
					myToggleText.text = val.ToString();
				}
			);

		myDropdownText.text = myDropDown.value.ToString ();
		myDropDown.onValueChanged.AsObservable ()
			.Subscribe (
				(val) => {
					myDropdownText.text = val.ToString();
				}
			);

	
	}


}

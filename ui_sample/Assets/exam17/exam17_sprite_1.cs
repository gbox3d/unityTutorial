using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

using UnityEngine.UI;

public class exam17_sprite_1 : MonoBehaviour {

	//[SerializeField] Sprite m_sprite_1;
	//[SerializeField] Sprite m_sprite_2;
	///[SerializeField] Button m_Btn_change;

	// Use this for initialization
	void Start () {
		
		Image imgobj = gameObject.GetComponent<Image> ();
		int nIndex = 0;
		//대표이름으로 전체 배열에 로딩하기 
		Sprite[] spriteAll = Resources.LoadAll<Sprite>("advnt_full");
		GameObject.Find("Canvas/Button").GetComponent<Button>().onClick.AsObservable ()
			.Subscribe(_ => {
				//imgobj.sprite = m_sprite_2;
				//nIndex
				if(spriteAll.Length <= nIndex) {
					nIndex = 0;
				}
				imgobj.sprite = spriteAll[nIndex]; //이미지 교체
				nIndex++;
			});
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

using UnityEngine;
using System.Collections;

using UnityEngine.UI;

using UniRx;
using UniRx.Triggers;

namespace ui_scroll_exam1
{
	public class main : MonoBehaviour
	{
		[SerializeField] RectTransform m_ScrollRect;
		[SerializeField] Text m_TextTest;

		// Use this for initialization
		void Start ()
		{
			int nCount = 0;

			//view size
			float nHeight = transform.FindChild("Scroll View").GetComponent<RectTransform> ().sizeDelta.y; 
			float nWidth = transform.FindChild ("Scroll View").GetComponent<RectTransform> ().sizeDelta.x;

			transform.FindChild ("Button_add").GetComponent<Button> ().OnClickAsObservable ()
				.Subscribe (_ => {

					m_TextTest.text += "hello "+ nCount +" \n";
					nCount++;

					if( (14 * nCount) > nHeight ) {

						m_TextTest.GetComponent<RectTransform>().sizeDelta = new Vector2(
							nWidth,
							14 * nCount
						);

						m_ScrollRect.sizeDelta =  new Vector2(
							0,
							14 * nCount
						);

						//move scroll
						m_ScrollRect.localPosition = new Vector2(0,(14 * nCount) - nHeight );
						
					}

			});

			transform.FindChild ("Button_move").GetComponent<Button> ().OnClickAsObservable () 
				.Subscribe (_ => {
					m_ScrollRect.localPosition = new Vector2(0,0);
			});


			
		
		}
	
		// Update is called once per frame
		void Update ()
		{
		
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class mainMenu : MonoBehaviour
{

    // Start is called before the first frame update
    TMP_InputField m_InputNameField;
    TMP_Text  m_outMsg;

    void Awake()
    {
        //m_nCount = 0;
        m_InputNameField = GameObject.Find("inputName").GetComponent<TMP_InputField>();
        m_outMsg = GameObject.Find("msgText").GetComponent<TMP_Text>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    int m_nCount;
    public void onClickTest1()
    {
        //TMP_InputField _inputNameField = GameObject.Find("inputName").GetComponent<TMP_InputField>();

        Debug.Log("test1");

        m_nCount++;
        m_outMsg.text = m_InputNameField.text + "clicked : " + m_nCount;
        

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ex02CanvasMng : MonoBehaviour
{
    public TMP_InputField m_inputMsg;
    public TMP_Text m_outMsg;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onClickBtn()
    {
        m_outMsg.text = m_inputMsg.text;

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

using TMPro;
using UnityEngine.UI;
using System;
using System.Text;
public class exam3 : MonoBehaviour
{
    [SerializeField]
    Button btnChat;

    [SerializeField]
    TMP_InputField txtChat;

    [SerializeField]
    TMP_Text txtChatLog;

    private const string API_URL = "http://localhost/jb14/qa";


    // Start is called before the first frame update
    void Start()
    {


        btnChat.onClick.AddListener(() =>
        {
            string chat = txtChat.text;
            Debug.Log("Chat button clicked : " + chat);
            txtChatLog.text += "User: " + chat + "\n";
            StartCoroutine(SendChatToAPI(chat));
        });

        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator SendChatToAPI(string message)
        {

            UnityWebRequest request = new UnityWebRequest(API_URL, "POST");
            byte[] bodyRaw = Encoding.UTF8.GetBytes(message);
            request.uploadHandler = new UploadHandlerRaw(bodyRaw);
            request.downloadHandler = new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "text/plain");

            yield return request.SendWebRequest();

            if (request.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Error: " + request.error);
                txtChatLog.text += "Error: " + request.error + "\n";
            }
            else
            {
                string response = request.downloadHandler.text;
                Debug.Log("Response: " + response);
                txtChatLog.text += "AI: " + response + "\n";
            }

            request.Dispose();
        }


    // Custom certificate handler to bypass certificate validation
    public class BypassCertificate : CertificateHandler
    {
        protected override bool ValidateCertificate(byte[] certificateData)
        {
            // Return true to indicate all certificates are valid
            return true;
        }
    }


}

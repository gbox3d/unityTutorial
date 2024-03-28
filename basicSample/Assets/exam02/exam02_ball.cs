using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exam02_ball : MonoBehaviour
{
    Rigidbody rb;
    exam02 scoreManager;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();

        scoreManager = FindAnyObjectByType<exam02>();

        // scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(rb.IsSleeping())
        {
            rb.WakeUp();
        }
        
    }

    void OnCollisionEnter(Collision collision)
    {
        string myTag = this.gameObject.tag;

        if (collision.gameObject.tag == "redBoard")
        {
            //get my tag
            

            if(myTag == "redBall")
            {
                
                scoreManager.AddScore(1);

            }
            else if(myTag == "blueBall")
            {
                
                scoreManager.AddScore(1);
            }

            Destroy(this.gameObject);
           
        }
        else if (collision.gameObject.tag == "blueBoard")
        {
            if(myTag == "redBall")
            {
                scoreManager.AddScore(-1);
            }
            else if(myTag == "blueBall")
            {
                scoreManager.AddScore(1);
            }
            

            Destroy(this.gameObject);
        }

        

        // scoreManager.RemoveSphere(this.gameObject);
    }
}

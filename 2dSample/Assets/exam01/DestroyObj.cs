using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObj : MonoBehaviour
{
    // Start is called before the first frame update
    public float lifeTime = 3.0f;

    public List<String> collisionTags = new List<string>();


    void Start()
    {
        Destroy(gameObject, lifeTime);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collisionTags.Contains(collision.gameObject.tag))
        {
            Destroy(gameObject);
        }
    }
}

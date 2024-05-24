using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class exam04_bomb : MonoBehaviour
{
    //tag list for collision
    public string[] tagList = { "block" };

    


    public GameObject prefab_Explord;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //check collision with tag list
        foreach (string tag in tagList)
        {
            if (collision.gameObject.tag == tag)
            {
                Destroy(gameObject);
                Instantiate(prefab_Explord, transform.position, Quaternion.identity);
            }
        }
    }


}

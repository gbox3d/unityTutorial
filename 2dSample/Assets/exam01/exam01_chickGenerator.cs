using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exam01_chickGenerator : MonoBehaviour
{
    public GameObject chickPrefab;
    public float interval = 3.0f;

    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(GenerateChick());
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Coroutine to generate chicks at intervals
    IEnumerator GenerateChick()
    {
        while (true)
        {
            Instantiate(chickPrefab, transform.position, transform.rotation);
            yield return new WaitForSeconds(interval);
        }
    }
}

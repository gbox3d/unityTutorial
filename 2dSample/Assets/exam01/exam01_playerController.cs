using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exam01_playerController : MonoBehaviour
{
    public float speed = 8.0f;
    public float moveableRange = 5.5f;

    public float power = 1000.0f;

    public GameObject cannonBallPrefab;
    public Transform spawnPoint;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * Input.GetAxis("Horizontal") * Time.deltaTime, 0, 0);

        // Moveable Range
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, -moveableRange, moveableRange);
        transform.position = pos;

        //fire cannon
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject newBullet = Instantiate(cannonBallPrefab, spawnPoint.position, Quaternion.identity);
            newBullet.GetComponent<Rigidbody2D>().AddForce( Vector2.up * power);
        }
        
    }
}

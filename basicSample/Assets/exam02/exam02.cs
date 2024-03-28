using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exam02 : MonoBehaviour
{
    //prefeb을 저장할 변수
    [SerializeField] GameObject redBall;
    [SerializeField] GameObject blueBall;


    int nScore=0;
    [SerializeField] TMPro.TMP_Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        // 코루틴 시작
        StartCoroutine(SpawnBalls());

    }

    public void AddScore(int n)
    {
        nScore += n;
        scoreText.text = "Score : " + nScore;
    }


    IEnumerator SpawnBalls()
    {
        // 무한 루프 안에서 실행
        while (true)
        {
            GameObject ball;
            // 2초 기다림
            yield return new WaitForSeconds(2f);

            // 랜덤하게 공을 생성
            int random = Random.Range(0, 2);
            if (random == 0)
            {
                ball = Instantiate(redBall, new Vector3(Random.Range(-0.5f, 0.5f), 10, 0), Quaternion.identity);
            }
            else
            {
                ball = Instantiate(blueBall, new Vector3(Random.Range(-0.5f, 0.5f), 10, 0), Quaternion.identity);
            }
            float addGravity = 2.0f;

            ball.GetComponent<Rigidbody>().AddForce(Vector3.down * addGravity, ForceMode.Impulse);
        }
    }


}

using UnityEngine;
using System.Collections;
//********** 開始 **********//
using UnityEngine.UI;
//********** 終了 **********//

public class PointController : MonoBehaviour
{

    public GameObject player;
    //********** 開始 **********//
    public Text scoreText; //Text用変数
    private int score = 0; //スコア計算用変数
                           //********** 終了 **********//
    private Transform playerTrans;

    void Start()
    {
        playerTrans = player.GetComponent<Transform>();
        //********** 開始 **********//
        scoreText.text = "Score: 0"; //初期スコアを代入して画面に表示
                                     //********** 終了 **********//
    }

    void OnCollisionEnter(Collision collision)
    {
        string yourTag = collision.gameObject.tag;

        if (yourTag == "SmallStarTag")
        {
            score += 50;
        }
        else if (yourTag == "LargeStarTag")
        {
            score += 100;
        }
        else if (yourTag == "SmallCloudTag")
        {
            score += 50;
        }
        else if (yourTag == "LargeCloudTag")
        {
            score += 100;
        }

        SetScore();
    }

    void SetScore()
    {
        scoreText.text = string.Format("Score:{0}", score);
    }

    void Update()
    {
        float playerHeight = playerTrans.position.y;
        float currentCameraHeight = transform.position.y;
        float newHeight = Mathf.Lerp(currentCameraHeight, playerHeight, 0.5f);
        this.scoreText.GetComponent<Text>().text = "Game Over";
        if (playerHeight > currentCameraHeight)
        {
            transform.position = new Vector3(transform.position.x, newHeight, transform.position.z);
        }
    }
}

using UnityEngine;

//担当者；石川天馬

public class Goal : MonoBehaviour
{
    public GameObject goalText;
    public GameObject blackPanel;

    public ResultManager resultmanager;

    public Timer timer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // プレイヤーがゴールに触れたら
        if (collision.CompareTag("RBC"))
        {
            // タイマー停止
            timer.isStop = true;

            // 黒幕表示
            blackPanel.SetActive(true);

            //テキストを表示
            goalText.SetActive(true);

            // リザルト表示
            resultmanager.ShowGoalResult();
        }

        // プレイヤーを停止
        PlayerMove playerMove = collision.GetComponent<PlayerMove>();
        if (playerMove != null)
        {
            playerMove.StartGoalMove();
        }
    }
}
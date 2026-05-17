using UnityEngine;

public class Goal : MonoBehaviour
{
    public GameObject goalText;
    public GameObject blackPanel;

    public ResultManager resultManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // プレイヤーがゴールに触れたら
        if (collision.CompareTag("RBC"))
        {
            // 黒幕表示
            blackPanel.SetActive(true);

            //テキストを表示
            goalText.SetActive(true);

            // リザルト表示
            resultManager.ShowResult();
        }

        // プレイヤーを停止
        PlayerMove playerMove = collision.GetComponent<PlayerMove>();
        if (playerMove != null)
        {
            playerMove.StartGoalMove();
        }
    }
}
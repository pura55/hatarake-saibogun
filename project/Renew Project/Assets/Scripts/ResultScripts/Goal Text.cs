using UnityEngine;

//担当者；石川天馬

public class Goal : MonoBehaviour
{
    public GameObject goalText;
    public GameObject blackPanel;

    public ResultManager resultmanager;

    public Timer timer;

    public GameObject effectPrefab;  // ゴールエフェクトのプレハブ
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        // プレイヤーがゴールに触れたら
        if (collision.CompareTag("RBC"))
        {
            // エフェクトを再生
            PlayGoalEffect();

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

    // ゴール時のエフェクトを実行する関数
    private void PlayGoalEffect()
    {
        Vector3 effectPosition = transform.position;
        // エフェクトのz座標を0に設定
        if (effectPosition.z != 0f)
        {
            effectPosition.z = 0f;
        }

        // ゴールの座標（transform.position）にエフェクトを生成
        Instantiate(effectPrefab, effectPosition, Quaternion.identity);
    }
}
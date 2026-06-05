using UnityEngine;
using TMPro;
//担当　千葉結加
public class Timer : MonoBehaviour
{
    public StatusSkill status;

    public float timeRemaining;

    public TextMeshProUGUI timerText;

    public bool isStop = false;

    void Start()
    {
        timeRemaining = status.stageTime;
    }

    void Update()
    {
        // タイマー停止中なら何もしない
        if (isStop)
        {
            return;
        }

        if (timeRemaining > 1)
        {
            // 時間を減らす
            timeRemaining -= Time.deltaTime;

            // 分と秒に変換
            int minutes = Mathf.FloorToInt(timeRemaining / 60);
            int seconds = Mathf.FloorToInt(timeRemaining % 60);

            // 表示更新
            timerText.text = string.Format("{1:0}", minutes, seconds);
        }
        else
        {
            timeRemaining = 0;
        }
    }

    //タイマーの時間が残っているかどうかを返す
    public bool GetLeftTime() 
    { 
        if(timeRemaining > 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
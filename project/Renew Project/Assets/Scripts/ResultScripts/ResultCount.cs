using UnityEngine;
using TMPro;
using System.Collections;

//担当者；石川天馬

public class ResultManager : MonoBehaviour
//public class ResultCount : MonoBehaviour
{
    public GameObject goalResultPanel;
    public GameObject timeResultPanel;
    public TextMeshProUGUI goalOxygenValueText;
    public TextMeshProUGUI timeOxygenValueText;
    public TextMeshProUGUI currentOxygenValueText;

    private void UpdateOxygenText()
    {
        // 0～99999に制限
        int oxygen = Mathf.Clamp(OxygenCounter.totalOxygen, 0, 99999);
        Debug.Log(oxygen);

        // 数字表示
        goalOxygenValueText.text = oxygen.ToString();
        timeOxygenValueText.text = oxygen.ToString();


    }

    private IEnumerator CountOxygenAnimation(int gained, int totalBefore)
    {
        // 演出スタートまでの秒数
        yield return new WaitForSeconds(1.0f);

        //gainedが0になるまで繰り返す
        while (gained > 0)
        {
            //獲得数を減らし、合計数を増加させる
            gained--;
            totalBefore++;

            //Textの更新
            currentOxygenValueText.text = gained.ToString();
            goalOxygenValueText.text = totalBefore.ToString();

            //更新秒数
            yield return new WaitForSeconds(0.1f);
        }
    }

    public void ShowGoalResult()
    {
        // リザルト表示
        goalResultPanel.SetActive(true);

        // アニメーション用に保存
        int gained = OxygenCounter.CurrentOxygen;
        int beforeTotal = OxygenCounter.totalOxygen;

        // 保存した値で最初の表示
        currentOxygenValueText.text = gained.ToString();
        goalOxygenValueText.text = beforeTotal.ToString();

        // 合計を更新する
        OxygenCounter.OxygenTotaling();

        StartCoroutine(CountOxygenAnimation(gained, beforeTotal));
    }

    public void ShowTimeResult()
    {
        // 現在所持している酸素を破棄
        OxygenCounter.DeleteCurrentOxygen();

        UpdateOxygenText();

        // リザルト表示
        timeResultPanel.SetActive(true);
    }
}
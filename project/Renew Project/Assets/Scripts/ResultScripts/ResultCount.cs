using UnityEngine;
using TMPro;

public class ResultManager : MonoBehaviour
//public class ResultCount : MonoBehaviour
{
    public GameObject goalResultPanel;
    public GameObject timeResultPanel;
    public TextMeshProUGUI goalOxygenValueText;
    public TextMeshProUGUI timeOxygenValueText;

    private void UpdateOxygenText()
    {
        // 0～99999に制限
        int oxygen = Mathf.Clamp(OxygenCounter.totalOxygen, 0, 99999);
        Debug.Log(oxygen);

        // 数字表示
        goalOxygenValueText.text = oxygen.ToString();
        timeOxygenValueText.text = oxygen.ToString();


    }

    public void ShowGoalResult()
    {
        UpdateOxygenText();

        // リザルト表示
        goalResultPanel.SetActive(true);
    }

    public void ShowTimeResult()
    {
        Debug.Log("ShowTimeResultが呼ばれています");
        UpdateOxygenText();

        // リザルト表示
        timeResultPanel.SetActive(true);
    }
}
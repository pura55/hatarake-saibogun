using UnityEngine;
using TMPro;

public class ResultManager : MonoBehaviour
//public class ResultCount : MonoBehaviour
{
    public GameObject resultPanel;
    public TextMeshProUGUI oxygenValueText;

    public void ShowResult()
    {
        // 0～99999に制限
        int oxygen = Mathf.Clamp(OxygenCounter.totalOxygen, 0, 99999);

        // 数字表示
        oxygenValueText.text = oxygen.ToString();

        // リザルト表示
        resultPanel.SetActive(true);
    }
}
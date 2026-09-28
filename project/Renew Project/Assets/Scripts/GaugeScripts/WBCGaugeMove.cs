using UnityEngine;
using UnityEngine.UI;
//担当　千葉結加

public class WBCGaugeMove : MonoBehaviour
{
    public StatusSkill status;

    public Image wbcGauge;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // Update is called once per frame
    void Update()
    {
        // 白血球（最大45）
        wbcGauge.fillAmount =
            (float)status.wbcAmount / 45f;
    }
}

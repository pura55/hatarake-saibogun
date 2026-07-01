using UnityEngine;
using UnityEngine.UI;
//担当　千葉結加

public class GaugeMove : MonoBehaviour
{
    public StatusSkill status;

    public Image rbcGauge;
    public Image wbcGauge;
    public Image pltGauge;

    void Update()
    {
        // 赤血球（最大10）
        rbcGauge.fillAmount =
            (float)status.rbcAmount / 10f;

        // 白血球（最大45）
        wbcGauge.fillAmount =
            (float)status.wbcAmount / 45f;

        // 血小板（最大60）
        pltGauge.fillAmount =
            (float)status.pltAmount / 60f;
    }
}
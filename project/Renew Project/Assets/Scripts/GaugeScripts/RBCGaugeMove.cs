using UnityEngine;
using UnityEngine.UI;
//担当　千葉結加

public class RBCGaugeMove : MonoBehaviour
{
    public StatusSkill status;

    public Image rbcGauge;

    void Update()
    {
        // 赤血球（最大10）
        rbcGauge.fillAmount =
            (float)status.rbcAmount / 10f;

    }
}
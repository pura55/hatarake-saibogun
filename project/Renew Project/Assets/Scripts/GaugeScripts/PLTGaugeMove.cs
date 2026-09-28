using UnityEngine;
using UnityEngine.UI;
//担当　千葉結加
public class PLTGaugeMove : MonoBehaviour
{
    public StatusSkill status;

    public Image pltGauge;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // Update is called once per frame
    void Update()
    {
        // 血小板（最大60）
        pltGauge.fillAmount =
            (float)status.pltAmount / 60f;
    }
}

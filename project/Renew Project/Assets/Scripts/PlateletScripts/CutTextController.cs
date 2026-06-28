using UnityEngine;
using TMPro;

public class CutTextController : MonoBehaviour
{
    [SerializeField] private TMP_Text needPlateletText;  // 必要な酸素数を表示するテキスト
    private RepairCut repairCut;
    private int needPlateletNum = 0; // 必要な酸素
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        repairCut = GetComponent<RepairCut>();
        // 最大値を代入
        needPlateletNum = repairCut.GetMaxPlatelet();
        // テキストを更新
        UpdateText();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateText();
    }

    public void CalculatePlateletNum()
    {
        // 血小板の計算
        needPlateletNum = needPlateletNum - repairCut.GetCurrentPlatelet();
        // 0未満になった場合0に固定
        if(needPlateletNum < 0)
        {
            needPlateletNum = 0;
        }
    }
    // テキストを更新する関数
    private void UpdateText()
    {
        needPlateletText.text = needPlateletNum.ToString();
    }
}

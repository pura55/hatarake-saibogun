using UnityEngine;
using TMPro;

public class CutTextController : MonoBehaviour
{
    [SerializeField] private TMP_Text needPlateletText;  // 必要な血小板数を表示するテキスト
    private RepairCut repairCut;
    private int needPlateletNum = 0; // 必要な血小板(最大値）
    private int currentPlateleteNum = 0; // 現在必要な血小板
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        repairCut = GetComponent<RepairCut>();

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
        // 最大値　-  現在の数　＝　現在必要な数
        currentPlateleteNum = needPlateletNum - repairCut.GetCurrentPlatelet();

        // 0未満になった場合0に固定
        if(currentPlateleteNum < 0)
        {
            currentPlateleteNum = 0;
        }
    }
    // テキストを更新する関数
    private void UpdateText()
    {
        needPlateletText.text = currentPlateleteNum.ToString();
    }

    public void SetPlateletNum(int plateletNum)
    {   
        needPlateletNum = plateletNum;
        currentPlateleteNum = needPlateletNum;
    }
}

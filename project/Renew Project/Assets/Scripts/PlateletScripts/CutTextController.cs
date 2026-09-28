using UnityEngine;
using TMPro;

/// <summary>
/// 担当：石﨑福人
/// 
/// 必要な血小板の数を表示するクラス
/// </summary>
public class CutTextController : MonoBehaviour
{
    [SerializeField] private TMP_Text needPlateletText;  // 必要な血小板数を表示するテキスト
    private RepairCut repairCut; // 傷スクリプト
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

    /// @brief 血小板の数を計算する関数
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

    /// @brief テキストを更新する関数
    private void UpdateText()
    {
        needPlateletText.text = currentPlateleteNum.ToString();
    }

    /// @brief 血小板の数を設定する関数
    public void SetPlateletNum(int plateletNum)
    {   
        needPlateletNum = plateletNum;
        currentPlateleteNum = needPlateletNum;
    }
}

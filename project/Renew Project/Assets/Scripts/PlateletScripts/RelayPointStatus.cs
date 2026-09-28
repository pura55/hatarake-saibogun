using UnityEngine;

/// <summary>
/// 担当：石﨑福人
/// 
/// 中継地点のステータス保持クラス
/// </summary>
public class RelayPointStatus : MonoBehaviour
{
    #region State
    private bool isPass = false; // 通過したかどうかのフラグ
    #endregion
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    #region Function
    public bool GetIsPass(){ return isPass; } /// @brief 通過フラグを返す関数
    public void SetIsPass(bool pass) { isPass = pass; } /// @brief 通過フラグを設定する関数
    #endregion
    // Update is called once per frame
    void Update()
    {
        
    }
}

using UnityEngine;

/// <summary>
/// _‘f‚²‚Æ‚Ì_‘fó‘Ô‚ğŠÇ—‚·‚éƒNƒ‰ƒX
/// </summary>
public class RbcStatus : MonoBehaviour
{
    #region Config
    public int oxygenCount = 0;
    public int oxygenMaxCount = 1;
    #endregion

    public StatusSkill status;

    /// @brief _‘f‚ÌƒJƒEƒ“ƒg‚ğ•Ô‚·ŠÖ”
    public int GetOneOxygenCount(){ return oxygenCount; }

    /// @brief _‘f‚ÌÅ‘åƒJƒEƒ“ƒg‚ğ•Ô‚·ŠÖ”
    public int GetOxygenMaxCount() { return oxygenMaxCount; }
    void Start()
    {
        oxygenMaxCount = status.rbcHave;
    }

    /// @brief _‘f‚ğ‰ÁZ‚·‚éŠÖ”
    public void AddOxygen()
    {
        if (oxygenCount >= oxygenMaxCount)
        {
            return;
        }
        oxygenCount++;
        Debug.Log($"{name} ‚Ì_‘f”: {oxygenCount}");
    }

    /// @brief Œ»İŠ‚µ‚Ä‚¢‚é_‘f‚ğŒ¸­‚³‚¹‚éŠÖ”
    public void ReductionOxygenCount()
    {
        oxygenCount--;
        if(oxygenCount < 0)
        {
            oxygenCount = 0;
        }
    }

}

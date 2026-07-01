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

    public int GetOneOxygenCount(){ return oxygenCount; }
    public int GetOxygenMaxCount() { return oxygenMaxCount; }
    void Start()
    {
        oxygenMaxCount = status.rbcHave;
    }
    // _‘f‚ğ‰ÁZ‚·‚éŠÖ”
    public void AddOxygen()
    {
        if (oxygenCount >= oxygenMaxCount)
        {
            return;
        }
        oxygenCount++;
        Debug.Log($"{name} ‚Ì_‘f”: {oxygenCount}");
    }

    // Œ»İŠ‚µ‚Ä‚¢‚é_‘f‚ğŒ¸­‚³‚¹‚éŠÖ”
    public void ReductionOxygenCount()
    {
        oxygenCount--;
        if(oxygenCount < 0)
        {
            oxygenCount = 0;
        }
    }

}

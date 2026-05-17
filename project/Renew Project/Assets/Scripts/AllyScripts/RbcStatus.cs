using UnityEngine;

public class RbcStatus : MonoBehaviour
{
    #region Config
    public int oxygenCount = 0;
    public int oxygenMaxCount = 5;
    #endregion

    public int GetOneOxygenCount(){ return oxygenCount; }
    public int GetOxygenMaxCount() { return oxygenMaxCount; }

    public void AddOxygen()
    {
        if(oxygenCount > oxygenMaxCount)
        {
            return;
        }
        oxygenCount++;
        Debug.Log($"{name} ‚Ì_‘f”: {oxygenCount}");
    }
}

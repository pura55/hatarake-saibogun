using UnityEngine;

public class RbcStatus : MonoBehaviour
{
    #region Config
    public int oxygenCount = 0;
    #endregion

    public void AddOxygen()
    {
        oxygenCount++;
        Debug.Log($"{name} ÇÃé_ëfêî: {oxygenCount}");
    }
}

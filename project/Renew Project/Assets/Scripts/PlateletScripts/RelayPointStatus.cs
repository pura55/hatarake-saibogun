using UnityEngine;

public class RelayPointStatus : MonoBehaviour
{
    #region State
    private bool isPass = false;
    #endregion
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    #region Function
    public bool GetIsPass(){ return isPass; }
    public void SetIsPass(bool pass) { isPass = pass; }
    #endregion
    // Update is called once per frame
    void Update()
    {
        
    }
}

using UnityEngine;

public class RbcDetector : MonoBehaviour
{
    #region Config 
    private bool isDetectingRBC = false;
    #endregion

    #region Public Methods
    public bool GetIsDetectingRBC() { return isDetectingRBC; }
    #endregion

    void OnTriggerEnter2D(Collider2D col)
    {
        //if (isDetectingRBC)
        //{
        //    return; //‚·‚Å‚ÉÔŒŒ‹…‚ğ’T’m‚µ‚Ä‚¢‚éê‡AÄ’T’m‚Ís‚í‚È‚¢
        //}

        Debug.Log("Trigger “ü‚Á‚½: " + col.name);
        if (col.gameObject.CompareTag("Oxygen"))
        {
            isDetectingRBC = true;
            Debug.Log("_‘f‚ğ’T’m‚µ‚½I");
        }
    }
}

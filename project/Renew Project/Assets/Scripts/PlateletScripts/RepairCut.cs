using System.Collections.Generic;
using UnityEngine;

public class RepairCut : MonoBehaviour
{
    #region Config
    private int maxPlatelet = 3;   //ŒŒ¬”Â‚ÌÅ‘å’l
    public float maxTime = 2.0f;   //C•œ‚³‚ê‚é‚Ü‚Å‚ÌŠÔ
    #endregion

    #region State
    private int currentPlatelet = 0;        //Œ»İ‚ÌŒŒ¬”Â‚ÌŒÂ”
    private float currentTime = 0.0f;       //Œ»İ‚ÌC•œŠÔ
    private Stack<Transform> plateletStack;
    #endregion

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        plateletStack = new Stack<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentPlatelet >= maxPlatelet)
            AddCurrentTime(); //ŠÔ‚ğ‰ÁZ
        
        if (currentTime >= maxTime)
            CompleteRepair(); //C•œŠ®—¹Œã‚Ìˆ—
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.gameObject.CompareTag("Platelet")) return;

        //ŒŒ¬”Â‚Ìi“ü‚Ìˆ—‚ğÀs
        HandlePlateletEnter(col.transform);
    }

    private void HandlePlateletEnter(Transform platelet)
    {
        AddPlatelet();                //ŒŒ¬”Â‚ÌŒÂ”‚ğ‰ÁZ‚·‚é
        RegisterPlatelet(platelet);  //ŒŒ¬”Â‚ğƒXƒ^ƒbƒN‚É“o˜^‚·‚é

        Debug.Log($"Œ»İ‚ÌŒŒ¬”Â‚ÌŒÂ”F{currentPlatelet}");
    }

    //ŒŒ¬”Â‚ğ“o˜^‚µ‚Ü‚·
    public void RegisterPlatelet(Transform platelet)
    {
        plateletStack.Push(platelet);
    }
    //‚ÌC•œ‚ªŠ®—¹‚µ‚½Œã‚Ìˆ—‚ğs‚¢‚Ü‚·
    private void CompleteRepair()
    {
        //ŒŒ¬”Â‚Æ‚ğíœ
        DestroyPlatelets();
        Destroy(gameObject);
    }
    //ŒŒ¬”Â‚Ìíœ‚ğs‚¢‚Ü‚·
    private void DestroyPlatelets()
    {
        while (plateletStack.Count > 0)
        {
            Destroy(plateletStack.Peek().gameObject);
            plateletStack.Pop();
        }
    }
    //C•œ‚É‚©‚©‚éŠÔ‚Ì‰ÁZ‚ğs‚¢‚Ü‚·
    private void AddCurrentTime()
    {
        currentTime += Time.deltaTime;
    }
    //ŒŒ¬”Â‚ÌŒÂ”‚ğ‰ÁZ‚µ‚Ü‚·
    private void AddPlatelet()
    {
        currentPlatelet++;
    }
   
}

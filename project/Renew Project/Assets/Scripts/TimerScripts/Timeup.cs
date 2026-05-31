using UnityEngine;
//担当　千葉結加
public class Timeup : MonoBehaviour
{
    public Timer timer;
    bool log = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (timer.timeRemaining <= 0)
        {
            if (log)
            {
                Debug.Log("タイムアップ！");
                log = false;
                return;
            }
            
        }
    }
}

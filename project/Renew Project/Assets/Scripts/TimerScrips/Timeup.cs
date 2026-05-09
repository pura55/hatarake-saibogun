using UnityEngine;

public class Timeup : MonoBehaviour
{
    public Timer timer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer.timeRemaining <= 0)
        {
            Debug.Log("タイムアップ！");
        }
    }
}

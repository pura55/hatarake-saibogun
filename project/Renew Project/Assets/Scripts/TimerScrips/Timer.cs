using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public float timeRemaining = 60f;

    public TextMeshProUGUI timerText;

    void Update()
    {
        if (timeRemaining > 1)
        {
            // ŠÔ‚ğŒ¸‚ç‚·
            timeRemaining -= Time.deltaTime;

            // •ª‚Æ•b‚É•ÏŠ·
            int minutes = Mathf.FloorToInt(timeRemaining / 60);
            int seconds = Mathf.FloorToInt(timeRemaining % 60);

            // •\¦XV
            timerText.text = string.Format("{1:0}", minutes, seconds);
        }
        else
        {
            timeRemaining = 0;
        }
    }
}
using UnityEngine;


public class Goal : MonoBehaviour
{
    public GameObject goalText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // プレイヤーがゴールに触れたら
        if (collision.CompareTag("Player"))
        {
            //テキストを表示
            goalText.SetActive(true);
        }
    }
}
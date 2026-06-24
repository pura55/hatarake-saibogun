using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//担当者：石川天馬

public class slide : MonoBehaviour
{
    [SerializeField] private Image tutorialImage;
    [SerializeField] private Sprite[] slideSprites;

    [SerializeField] private GameObject prevButton; // 戻るボタン
    [SerializeField] private GameObject nextButton; // 次へボタン
    [SerializeField] private GameObject startButton; //スタートボタン

    private enum SlideState 
    {
        first,     // 一枚目のスライド
        second,　　// 二枚目のスライド
        third,     // 三枚目のスライド
        fourth,    // 四枚目のスライド
        fifth,     // 五枚目のスライド
        sixth,     // 六枚目のスライド
        seventh,   // 七枚目のスライド
        eighth     // 八枚目のスライド
    }

    // スライド用の列挙型変数
    private SlideState state;

    void Start()
    {
        state = SlideState.first;
        UpdateSlide();
    }

    // 次へボタン
    public void NextSlide()
    {
        if ((int)state < System.Enum.GetValues(typeof(SlideState)).Length - 1)
        {
            state++;
            UpdateSlide();
        }
    }

    // 戻るボタン
    public void PrevSlide()
    {
        if ((int)state > 0)
        {
            state--;
            UpdateSlide();
        }
    }

    //スタートボタンを押すとPlaySceneへ遷移する
    public void TStartGame()
    {
        SceneManager.LoadScene("PlayScene");
    }

    //画像更新処理
    private void UpdateSlide()
    {
        tutorialImage.sprite = slideSprites[(int)state];

        int maxIndex = System.Enum.GetValues(typeof(SlideState)).Length - 1;

        // 戻るボタン
        prevButton.SetActive((int)state > 0);

        // 次へボタン
        nextButton.SetActive((int)state < maxIndex);

        // スタートボタン
        startButton.SetActive((int)state == maxIndex);
    }
}

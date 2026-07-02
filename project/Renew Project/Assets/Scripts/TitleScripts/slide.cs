using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;


//担当者：石川天馬

public class slide : MonoBehaviour
{
    [SerializeField] private Image tutorialImage;
    [SerializeField] private Sprite[] slideSprites;

    [SerializeField] private GameObject prevButton; // 戻るボタン
    [SerializeField] private GameObject nextButton; // 次へボタン
    [SerializeField] private GameObject startButton; //スタートボタン

    [Header("Button SE")]
    [SerializeField] private AudioSource seAudioSource;
    [SerializeField] private AudioClip buttonSE;

    // ランダムで遷移するシーン一覧
    private string[] stageScene =
    {
        "map1",
        "map2",
        "map3",
        "map4",
        "map5"
    };

    private IEnumerator LoadSceneAfterSE(string sceneName)
    {
        // ボタンSEが鳴り終わるまで待つ
        yield return new WaitForSeconds(buttonSE.length);

        SceneManager.LoadScene(sceneName);
    }

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

    private void PlayButtonSE()
    {
        seAudioSource.PlayOneShot(buttonSE);
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
        PlayButtonSE();

        int randomIndex = Random.Range(0, stageScene.Length);

        StartCoroutine(LoadSceneAfterSE(stageScene[randomIndex]));
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

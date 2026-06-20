using UnityEngine;
using UnityEngine.UI;

public class slide : MonoBehaviour
{
    [SerializeField] private Image tutorialImage;
    [SerializeField] private Sprite[] slideSprites;

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

    //画像更新処理
    private void UpdateSlide()
    {
        tutorialImage.sprite = slideSprites[(int)state];
    }

    void Update()
    {
        // このスイッチ文の中に処理を書く（各スライドの処理を関数化した方が見やすいかも）
        switch (state)
        {
            case SlideState.first: // 一枚目のスライドの処理
                //　例　FirstSlideProcess();
                break;

            case SlideState.second: // 二枚目のスライドの処理
                break;

            case SlideState.third: // 三枚目のスライドの処理
                break;

            case SlideState.fourth: // 四枚目のスライドの処理
                break;

            case SlideState.fifth: // 五枚目のスライドの処理
                break;

            case SlideState.sixth: // 六枚目のスライドの処理
                break;

            case SlideState.seventh: // 七枚目のスライドの処理
                break;

            case SlideState.eighth: // 八枚目のスライドの処理
                break;
        }
    }
}

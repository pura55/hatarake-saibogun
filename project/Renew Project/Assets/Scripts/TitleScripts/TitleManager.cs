using UnityEngine;
using UnityEngine.SceneManagement;

//担当者；石川天馬

#if UNITY_EDITOR
using UnityEditor;
#endif

public class TitleManager : MonoBehaviour
{
    [SerializeField] GameObject quitPanel;

    [SerializeField] GameObject settingsPanel;

    [SerializeField] GameObject tutorialPnael;

    [Header("Button SE")]
    [SerializeField] private AudioSource seAudioSource;
    [SerializeField] private AudioClip buttonSE;

    // ランダムで遷移するシーン一覧
    private string[] maps =
    {
        "map1",
        "map2",
        "map3",
        "map4",
        "map5"
    };

    private void PlayButtonSE()
    {
        seAudioSource.PlayOneShot(buttonSE);
    }

    //スタートボタンを押したらプレイシーンへ移行
    public void StartGame()
    {
        PlayButtonSE();

        int randomIndex = Random.Range(0, maps.Length);

        SceneManager.LoadScene(maps[randomIndex]);
    }

    //チュートリアルボタンを押したらチュートリアル画像を表示
    public void OpenTutorial()
    {
        PlayButtonSE();

        tutorialPnael.SetActive(true);
    }

    //クローズボタンを押したら、チュートリアルパネルを閉じる
    public void CloseTutorial()
    {
        PlayButtonSE();

        tutorialPnael.SetActive(false);
    }

    //終了ボタンを押したら修了確認
    public void OpenQuitPanel()
    {
        PlayButtonSE();

        quitPanel.SetActive(true);
    }

    // 「はい」ゲームを終了
    public void QuitGame()
    {
        PlayButtonSE();

#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    // 「いいえ」タイトルに戻る
    public void CloseQuitPanel()
    {
        PlayButtonSE();

        quitPanel.SetActive(false);
    }

    //セッティングボタンを押したらセッティングを表示
    public void OpenSettings()
    {
        PlayButtonSE();

        settingsPanel.SetActive(true);
    }

    //クローズボタンを押したら、セッティングパネルを閉じる
    public void CloseSettings()
    {
        PlayButtonSE();

        settingsPanel.SetActive(false);
    }
}
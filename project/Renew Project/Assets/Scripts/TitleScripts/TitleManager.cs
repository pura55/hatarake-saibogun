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

    //スタートボタンを押したらプレイシーンへ移行
    public void StartGame()
    {
        SceneManager.LoadScene("PlayScene");
    }

    //チュートリアルボタンを押したらチュートリアル画像を表示
    public void OpenTutorial()
    {
        tutorialPnael.SetActive(true);
    }

    //クローズボタンを押したら、チュートリアルパネルを閉じる
    public void CloseTutorial()
    {
        tutorialPnael.SetActive(false);
    }

    //終了ボタンを押したら修了確認
    public void OpenQuitPanel()
    {
        quitPanel.SetActive(true);
    }

    // 「はい」ゲームを終了
    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    // 「いいえ」タイトルに戻る
    public void CloseQuitPanel()
    {
        quitPanel.SetActive(false);
    }

    //セッティングボタンを押したらセッティングを表示
    public void OpenSettings()
    {
        settingsPanel.SetActive(true);
    }

    //クローズボタンを押したら、セッティングパネルを閉じる
    public void CloseSettings()
    {
        settingsPanel.SetActive(false);
    }
}
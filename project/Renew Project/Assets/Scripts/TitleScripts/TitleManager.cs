using UnityEngine;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class TitleManager : MonoBehaviour
{
    [SerializeField] GameObject quitPanel;

    [SerializeField] GameObject settingsPanel;

    //スタートボタンを押したらプレイシーンへ移行
    public void StartGame()
    {
        SceneManager.LoadScene("PlayScene");
    }

    //終了ボタンを押したら修了確認
    public void ShowQuitPanel()
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
    public void HideQuitPanel()
    {
        quitPanel.SetActive(false);
    }

    //
    public void OpenSettings()
    {
        settingsPanel.SetActive(true);
    }

    public void CloseSettings()
    {
        settingsPanel.SetActive(false);
    }
}
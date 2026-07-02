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

    // ランダムで遷移するシーン一覧
    private string[] maps =
    {
        "map1",
        "map2",
        "map3",
        "map4",
        "map5"
    };

    //スタートボタンを押したらプレイシーンへ移行
    public void StartGame()
    {
        int randomIndex = Random.Range(0, maps.Length);

        SceneManager.LoadScene(maps[randomIndex]);
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
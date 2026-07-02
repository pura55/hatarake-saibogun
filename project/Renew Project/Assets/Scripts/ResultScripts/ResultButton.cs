using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

//担当者；石川天馬

public class ResultButton : MonoBehaviour
{
    [Header("Button SE")]
    [SerializeField] private AudioSource seAudioSource;
    [SerializeField] private AudioClip buttonSE;

    // ランダムで遷移するシーン一覧
    private string[] stageScenes =
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

    private int lastIndex = -1;

    private void PlayButtonSE()
    {
        seAudioSource.PlayOneShot(buttonSE);
    }

    //SkillTreeボタンを押したらSkillSceneへ移行
    public void  OpenSkill()
    {
        PlayButtonSE();

        StartCoroutine(LoadSceneAfterSE("SkillScene"));
    }

    //Continueボタンを押すと、ゲームを最初から再開する
    public void ContinueGame()
    {
        PlayButtonSE();

        int randomIndex;

        do
        {
            randomIndex = Random.Range(0, stageScenes.Length);
        }
        while (randomIndex == lastIndex);

        lastIndex = randomIndex;

        StartCoroutine(LoadSceneAfterSE(stageScenes[randomIndex]));
    }

    //Continueボタンを押すと、ゲームを最初から再開する
    public void ReturnTitle()
    {
        PlayButtonSE();

        StartCoroutine(LoadSceneAfterSE("TitleScene"));
    }
}

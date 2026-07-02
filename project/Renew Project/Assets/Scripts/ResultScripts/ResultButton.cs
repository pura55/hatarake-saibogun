using UnityEngine;
using UnityEngine.SceneManagement;

//担当者；石川天馬

public class ResultButton : MonoBehaviour
{
    // ランダムで遷移するシーン一覧
    private string[] stageScenes =
    {
        "map1",
        "map2",
        "map3",
        "map4",
        "map5"
    };

    private int lastIndex = -1;

    //SkillTreeボタンを押したらSkillSceneへ移行
    public void  OpenSkill()
    {
        SceneManager.LoadScene("SkillScene");
    }

    //Continueボタンを押すと、ゲームを最初から再開する
    public void ContinueGame()
    {
        int randomIndex;

        do
        {
            randomIndex = Random.Range(0, stageScenes.Length);
        }
        while (randomIndex == lastIndex);

        lastIndex = randomIndex;

        SceneManager.LoadScene(stageScenes[randomIndex]);
    }

    //Continueボタンを押すと、ゲームを最初から再開する
    public void ReturnTitle()
    {
        SceneManager.LoadScene("TitleScene");
    }
}

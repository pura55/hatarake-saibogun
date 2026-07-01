using UnityEngine;
using UnityEngine.SceneManagement;

//担当者；石川天馬

public class ResultButton : MonoBehaviour
{
    //SkillTreeボタンを押したらSkillSceneへ移行
    public void  OpenSkill()
    {
        SceneManager.LoadScene("SkillScene");
    }

    //Continueボタンを押すと、ゲームを最初から再開する
    public void ContinueGame()
    {
        SceneManager.LoadScene("PlayScene");
    }

    //Continueボタンを押すと、ゲームを最初から再開する
    public void ReturnTitle()
    {
        SceneManager.LoadScene("TitleScene");
    }
}

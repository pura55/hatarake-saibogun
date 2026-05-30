using UnityEngine;
using UnityEngine.SceneManagement;

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
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class PayGameButton : MonoBehaviour
{
    //PlayGameButton‚ğ‰Ÿ‚µ‚½‚çAPlayScene‚Ö‘JˆÚ
    public void PlayGame()
    {
        SceneManager.LoadScene("PlayScene");
    }
}

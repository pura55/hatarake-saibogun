using UnityEngine;
using UnityEngine.SceneManagement;

//’S“–ÒGÎì“V”n

public class PrayGameButton : MonoBehaviour
{
    //PlayGameButton‚ğ‰Ÿ‚µ‚½‚çAPlayScene‚Ö‘JˆÚ
    public void PlayGame()
    {
        SceneManager.LoadScene("PlayScene");
    }
}

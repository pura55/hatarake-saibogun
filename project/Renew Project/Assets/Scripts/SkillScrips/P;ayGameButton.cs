using UnityEngine;
using UnityEngine.SceneManagement;

//’S“–ÒGÎì“V”n

public class PrayGameButton : MonoBehaviour
{

    private string[] map =
   {
        "map1",
        "map2",
        "map3",
        "map4",
        "map5"
    };

    //PlayGameButton‚ğ‰Ÿ‚µ‚½‚çAPlayScene‚Ö‘JˆÚ
    public void PlayGame()
    {
        int randomIndex = Random.Range(0, map.Length);

        SceneManager.LoadScene(map[randomIndex]);
    }
}

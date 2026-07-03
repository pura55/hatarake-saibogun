using UnityEngine;

//担当者；石川天馬

public class Goal : MonoBehaviour
{
    public GameObject goalText;
    public GameObject clearText;  //クリアーテキスト
    public GameObject blackPanel;

    public ResultManager resultmanager;
    public StatusSkill statusSkill;
    public Timer timer;

    [SerializeField] private GameObject effectPrefab;  // ゴールエフェクトのプレハブ

    [SerializeField] private AudioSource audioSource;  // オーディオソース

    [SerializeField] private AudioClip goalJingle; // ゴールジングル

    private bool isGoal = false;

    private float goalEnableDelay = 0.2f;
    private float timerCount = 0f;

    private void Start()
    {
        isGoal = false;
        timerCount = 0f;
    }

    private void Update()
    {
        timerCount += Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (timerCount < goalEnableDelay) return;

        if (isGoal) return;

        // プレイヤーがゴールに触れたら
        if (!collision.CompareTag("RBC")) return;

        isGoal = true;

        // ゴールSEを再生
        PlayGoalJingle();

        // エフェクトを再生
        PlayGoalEffect();

        // タイマー停止
        timer.isStop = true;

        // 黒幕表示
        blackPanel.SetActive(true);

        //テキストを表示
        if (statusSkill.isSkillMax)
        {
            clearText.SetActive(true);
        }
        else
        {
            goalText.SetActive(true);
        }

        // リザルト表示
        resultmanager.ShowGoalResult();

        // プレイヤーを停止
        PlayerMove[] players = FindObjectsByType<PlayerMove>(FindObjectsSortMode.None);
        foreach (PlayerMove player in players)
        {
            player.StartGoalMove();
        }

        EnemyDetection[] enemies =
    FindObjectsByType<EnemyDetection>(FindObjectsSortMode.None);

        foreach (EnemyDetection enemy in enemies)
        {
            enemy.StopEnemy();
        }
    }

    // ゴール時のエフェクトを実行する関数
    private void PlayGoalEffect()
    {
        Vector3 effectPosition = transform.position;
        // エフェクトのz座標を0に設定
        if (effectPosition.z != 0f)
        {
            effectPosition.z = 0f;
        }

        // ゴールの座標（transform.position）にエフェクトを生成
        Instantiate(effectPrefab, effectPosition, Quaternion.identity);
    }

    private void PlayGoalJingle()
    {
        audioSource.PlayOneShot(goalJingle);
    }
}
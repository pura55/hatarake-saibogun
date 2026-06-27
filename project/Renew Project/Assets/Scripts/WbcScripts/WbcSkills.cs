using UnityEngine;

public class WbcSkills : MonoBehaviour
{
#region State
    //スキルを使用したかどうかのフラッグ(true:使用済み, false:未使用)
    private bool isUsedSkill = false;
    //敵と接触しているかどうかのフラッグ(true:既接触, false:未接触)
    private bool isHitEnemy = false;
    public WbcDetection wbcDetection;
    private Transform targetEnemy;
    public StatusSkill status;
    [SerializeField] private AudioSource restrainAudioSource; // 抑制SE用のオーディオソース
    [SerializeField] private AudioClip restrainSE; // 抑制SE
    private bool canPlaySE = true;  　　// プレイが出来るかどうかのフラグ
    private bool isApplyPlaySE = false; // SEプレイの許可があるかどうかのフラグ
    private float playingTimeOfSE = 0.0f;
    #endregion
    public bool GetUsedSkill() { return isUsedSkill; }
    public void SetUsedSkill(bool isUsed) { isUsedSkill = isUsed; }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isHitEnemy)
        {
            //EnemyDetectionの参照を取得
            EnemyDetection enemyDetection = targetEnemy.GetComponent<EnemyDetection>();
            //スキルの効果を反映する
            enemyDetection.SetIsEffectWbc(true);
            //スキルを使用済みに変更
            SetUsedSkill(true);
            //白血球を硬直させる
            wbcDetection.SetIsFreez(true);
            // SE再生の許可をだす
            isApplyPlaySE = true;
            //接触判定をリセット
            isHitEnemy = false;
        }

        if (isApplyPlaySE)
        {
            PlayRestrainSE();
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (!isUsedSkill)
        {
            Debug.Log("ぶつかった相手: " + col.gameObject.name);
            if (col.gameObject.CompareTag("Enemy"))
            {
                Debug.Log("敵に接触した！");
                //敵の参照を取得
                targetEnemy = col.transform;
                isHitEnemy = true;
            }
        }
    }

    // 抑制SEを再生する関数
    private void PlayRestrainSE()
    {
        if (canPlaySE)
        {
            // 再生する前に一度止める
            if (restrainAudioSource.isPlaying)
            {
                restrainAudioSource.Stop();
            }
            restrainAudioSource.PlayOneShot(restrainSE);
            canPlaySE = false;
        }

        // 再生時間を加算
        playingTimeOfSE += Time.deltaTime;

        // SEを再生しきったら再びcanPlaySEをtrue
        if (playingTimeOfSE >= 1.122f)
        {
            canPlaySE = true;
            playingTimeOfSE = 0.0f;
        }
    }
}

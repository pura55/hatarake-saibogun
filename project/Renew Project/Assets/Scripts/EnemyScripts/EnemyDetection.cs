using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    #region Config
    public float followSpeed = 3f; // 追従速度
    public float detectRange = 1f; // 検知範囲
    public const float freezingTime = 1f; //硬直時間
    public /*const*/ float effectedTime = 3f; //白血球の効果時間
    #endregion

    #region State
    private Transform targetRbc;            //赤血球の参照
    public  EnemySkills enemySkills;        //EnemySkillsの参照
    private bool isAttached = false;        //敵を赤血球に近づけるフラグ
    private bool isFreez = false;           //硬直中のフラグ
    private bool isEffect = false;          //白血球の効果を受けているかどうかのフラグ
    private float currentFreezTime = 0f;    //硬直経過時間
    private float currentEffectedTime = 0f; //効果継続時間
    public StatusSkill status;
    #endregion

    public void SetIsFreez(bool freez) { isFreez = freez; }
    public void SetIsEffectWbc(bool effect) { isEffect= effect; }
    public Transform GetTargetRbc() { return targetRbc; }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        effectedTime = status.wbcTime;
    }

    private bool isGoal = false;

    public void StopEnemy()
    {
        isGoal = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isGoal)
        {
            return;
        }

        //目標とする対象が存在しないとき探索してreturn
        if (targetRbc == null)
        {
            targetRbc = FindClosestRbcWithinRange(detectRange);
            return;
        }
        else
        { 
            //検知範囲にターゲットが存在しないときターゲットをnull
            if (FindClosestRbcWithinRange(detectRange) == null)
            {
                targetRbc = null;
                return;
            }

        }

        if(isEffect)
        {
            isEffected();
            return;
        }
        //硬直中
        if(isFreez)
        {
            isFreezing();
            return;
        }

        if (!isAttached)
        {
            transform.position = Vector3.Lerp(
                transform.position,
                targetRbc.position,
                followSpeed * Time.deltaTime
            );
        }
    }

    Transform FindClosestRbcWithinRange(float range)
    {
        //赤血球のオブジェクトの参照を取得
        GameObject[] rbcs = GameObject.FindGameObjectsWithTag("RBC");
        Transform closest = null;
        float minDist = Mathf.Infinity;　

        //Wallのレイヤーを取得
        int wallLayerMask = LayerMask.GetMask("Wall");

        foreach (GameObject r in rbcs)
        {
            float dist = Vector2.Distance(transform.position, r.transform.position);
            if (dist < minDist && dist < range)
            {

                // Enemyと赤血球の直線上の間にWallのレイヤーオブジェクトがあるかをチェック
                RaycastHit2D hit = Physics2D.Linecast(transform.position, r.transform.position, wallLayerMask);

                // もし壁に遮られていたら、この赤血球は無視して次の赤血球の検知へ移る
                if (hit.collider != null)
                {
                    continue;
                }

                minDist = dist;
                closest = r.transform;
            }
        }

        return closest;
    }

    //硬直中のタイムカウント
    private void isFreezing()
    {
        if(currentFreezTime < freezingTime)
        {
            currentFreezTime += Time.deltaTime;
            enemySkills.SetUsedSkill(true);
        }
        else
        {
            currentFreezTime = 0f;
            enemySkills.SetUsedSkill(false);
            isFreez = false;
        }
    }

    private void isEffected()
    {
        if (currentEffectedTime < effectedTime)
        {
            currentEffectedTime += Time.deltaTime;
            enemySkills.SetUsedSkill(true);
        }
        else
        {
            currentEffectedTime = 0f;
            enemySkills.SetUsedSkill(false);
            isEffect = false;
        }
    }
}

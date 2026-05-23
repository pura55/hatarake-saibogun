using UnityEngine;

public class WbcDetection : MonoBehaviour
{
    #region Config
    public float followSpeed = 3f; // 追従速度
    public float detectRange = 2f; // 検知範囲
    public const float freezingTime = 3f; //硬直時間
    #endregion

    #region State
    private Transform targetEnemy;    //敵の座標の参照
    public WbcSkills wbcSkills;       //白血球のスキルScriptの参照
    private bool isAttached = false;  //白血球を敵に近づけるフラグ
    private bool isFreez = false;     //硬直のフラグ
    private bool isFound = false;
    private float currentFreezTime = 0f; //硬直経過時間
    #endregion

    public void SetIsFreez(bool freez) { isFreez = freez; }
    public bool GetIsFound() { return isFound; }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //目標とする対象が存在しないとき探索してreturn
        if (targetEnemy == null)
        {
            targetEnemy = FindClosestEnemyWithinRange(detectRange);
            return;
        }
        else
        {
            isFound = true;
            ////検知範囲にターゲットが存在しないときターゲットをnull
            //if (FindClosestEnemyWithinRange(detectRange) == null)
            //{
            //    targetEnemy = null;
            //    isFound = false;
            //    return;
            //}
        }

        //硬直中
        if (isFreez)
        {
            isFreezing();
            return;
        }

        if (!isAttached)
        {
            transform.position = Vector3.Lerp(
                transform.position,
                targetEnemy.position,
                followSpeed * Time.deltaTime
            );
        }
    }

    Transform FindClosestEnemyWithinRange(float range)
    {
        GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");
        Transform closest = null;
        float minDist = Mathf.Infinity;

        //Wallのレイヤーを取得
        int wallLayerMask = LayerMask.GetMask("Wall");

        foreach (GameObject r in enemys)
        {
            float dist = Vector2.Distance(transform.position, r.transform.position);
            if (dist < minDist && dist < range)
            {

                // 白血球とEnemyの直線上の間にWallのレイヤーオブジェクトがあるかをチェック
                RaycastHit2D hit = Physics2D.Linecast(transform.position, r.transform.position, wallLayerMask);

                // もし壁に遮られていたら、このEnemyは無視して次のEnemyの検知へ移る
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

    void isFreezing()
    {
        if (currentFreezTime < freezingTime)
        {
            currentFreezTime += Time.deltaTime;
        }
        else
        {
            currentFreezTime = 0f;
            isFreez = false;           
            Destroy(gameObject);
        }
    }
}

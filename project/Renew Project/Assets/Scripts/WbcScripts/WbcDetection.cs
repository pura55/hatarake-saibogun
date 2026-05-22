using UnityEngine;

public class WbcDetection : MonoBehaviour
{
    #region Config
    public float followSpeed = 3f; // 追従速度
    public float detectRange = 1f; // 検知範囲
    public const float freezingTime = 1f; //硬直時間
    #endregion

    #region State
    private Transform targetEnemy;
    public WbcSkills wbcSkills;
    private bool isAttached = false;
    private bool isFreez = false;
    private float currentFreezTime = 0f;
    #endregion

    public void SetIsFreez(bool freez) { isFreez = freez; }
    public Transform GetTargetEnemy() { return targetEnemy; }
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
            //検知範囲にターゲットが存在しないときターゲットをnull
            if (FindClosestEnemyWithinRange(detectRange) == null)
            {
                targetEnemy = null;
                return;
            }
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

        foreach (GameObject r in enemys)
        {
            float dist = Vector2.Distance(transform.position, r.transform.position);
            if (dist < minDist && dist < range)
            {
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
            Destroy(gameObject);
            //wbcSkills.SetUsedSkill(false);
            isFreez = false;
        }
    }
}

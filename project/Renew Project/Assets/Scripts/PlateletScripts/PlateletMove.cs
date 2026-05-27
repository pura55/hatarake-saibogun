using UnityEngine;

public class PlateletMove : MonoBehaviour
{
    #region Config
    public float followSpeed = 3f; // 追従速度
    public float detectRange = 2f; // 検知範囲
    #endregion

    #region State
    private Transform targetCrack;    //亀裂の座標の参照
    private Transform relayPoint;     //中継地点の座標の参照
    private bool isAttached = false;  //血小板を中継地点に近づけるフラグ
    private int relayCount = 0;
    #endregion

    public void ResetRelayPoint() { isAttached = true; }
    public int GetrelayCount () { return relayCount; }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //目標とする対象が存在しないとき探索してreturn
        if(relayCount == 0)
        {
            if (relayPoint == null)
            {
                relayPoint = FindClosestRelayPoint1WithinRange(detectRange);
                return;
            }
            else
            {
                if (isAttached)
                {
                    Debug.Log("中継地点1をリセット");
                    detectRange = 2f;
                    relayPoint = null;
                    isAttached = false;
                    detectRange = 100f;
                    relayCount += 1;
                    return;
                }
            }
        }
        else if(relayCount == 1)
        {
            if (relayPoint == null)
            {
                Debug.Log("二つ目の中継地点を検索中");
                relayPoint = FindClosestRelayPoint2WithinRange(detectRange);
                return;
            }
            else
            {
                if (isAttached)
                {
                    Debug.Log("中継地点2をリセット");
                    detectRange = 2f;
                    relayPoint = null;
                    isAttached = false;
                    detectRange = 100f;
                    relayCount += 1;
                    return;
                }
            }
        }
        else if (relayCount == 2)
        {
            if (relayPoint == null)
            {
                Debug.Log("3つ目の中継地点を検索中");
                relayPoint = FindClosestRelayPoint3WithinRange(detectRange);
                return;
            }
            else
            {
                if (isAttached)
                {
                    Debug.Log("中継地点3をリセット");
                    detectRange = 2f;
                    relayPoint = null;
                    isAttached = false;
                    detectRange = 100f;
                    relayCount += 1;
                    return;
                }
            }
        }


        if (!isAttached)
        {
            if (relayCount == 1)
            {
                Debug.Log("中継地点２に接近中");
            }
            else if (relayCount == 2)
            {
                Debug.Log("中継地点3に接近中");
            }

            transform.position = Vector3.Lerp(
            transform.position,
            relayPoint.position,
            followSpeed * Time.deltaTime
            );
        }
    }

    Transform FindClosestRelayPoint1WithinRange(float range)
    {
        GameObject[] relayPoints = GameObject.FindGameObjectsWithTag("RelayPoint1");
        Transform closest = null;
        float minDist = Mathf.Infinity;

        //Wallのレイヤーを取得
        int wallLayerMask = LayerMask.GetMask("Wall");

        foreach (GameObject r in relayPoints)
        {
            float dist = Vector2.Distance(transform.position, r.transform.position);
            if (dist < minDist && dist < range)
            {

                // 白血球とEnemyの直線上の間にWallのレイヤーオブジェクトがあるかをチェック
                RaycastHit2D hit = Physics2D.Linecast(transform.position, r.transform.position, wallLayerMask);

                // もし壁に遮られていたら、このRelayPointは無視して次のRelayPointの検知へ移る
                if (hit.collider != null)
                {
                    continue;
                }
                Debug.Log("発見");
                minDist = dist;
                closest = r.transform;
            }
        }

        return closest;
    }

    Transform FindClosestRelayPoint2WithinRange(float range)
    {
        GameObject[] relayPoints = GameObject.FindGameObjectsWithTag("RelayPoint2");
        Transform closest = null;
        float minDist = Mathf.Infinity;

        //Wallのレイヤーを取得
        int wallLayerMask = LayerMask.GetMask("Wall");

        foreach (GameObject r in relayPoints)
        {
            float dist = Vector2.Distance(transform.position, r.transform.position);
            if (dist < minDist && dist < range)
            {

                // 白血球とEnemyの直線上の間にWallのレイヤーオブジェクトがあるかをチェック
                RaycastHit2D hit = Physics2D.Linecast(transform.position, r.transform.position, wallLayerMask);

                // もし壁に遮られていたら、このRelayPointは無視して次のRelayPointの検知へ移る
                if (hit.collider != null)
                {
                    Debug.Log("継続中");
                    continue;
                }
                Debug.Log("発見");
                minDist = dist;
                closest = r.transform;
            }
        }

        return closest;
    }

    Transform FindClosestRelayPoint3WithinRange(float range)
    {
        GameObject[] relayPoints = GameObject.FindGameObjectsWithTag("RelayPoint3");
        Transform closest = null;
        float minDist = Mathf.Infinity;

        //Wallのレイヤーを取得
        int wallLayerMask = LayerMask.GetMask("Wall");

        foreach (GameObject r in relayPoints)
        {
            float dist = Vector2.Distance(transform.position, r.transform.position);
            if (dist < minDist && dist < range)
            {

                // 白血球とEnemyの直線上の間にWallのレイヤーオブジェクトがあるかをチェック
                RaycastHit2D hit = Physics2D.Linecast(transform.position, r.transform.position, wallLayerMask);

                // もし壁に遮られていたら、このRelayPointは無視して次のRelayPointの検知へ移る
                if (hit.collider != null)
                {
                    Debug.Log("継続中");
                    continue;
                }
                Debug.Log("発見");
                minDist = dist;
                closest = r.transform;
            }
        }

        return closest;
    }
}

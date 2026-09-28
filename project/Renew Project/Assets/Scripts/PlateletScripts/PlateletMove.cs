using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 担当：石﨑福人
/// 
/// 血小板の移動
/// </summary>

public class PlateletMove : MonoBehaviour
{
    //通過した目標のスタック
    public enum passTarget
    {
        init,
        relayPoint1,
        relayPoint2,
        relayPoint3,
        cut
    }

    #region Config
    public float followSpeed = 3f; // 追従速度
    public float detectRange = 2f; // 検知範囲
    #endregion

    #region State
    private Transform targetCut = null;      //傷の座標の参照
    private Transform relayPoint = null;     //中継地点の座標の参照
    private Transform currentTarget = null;  //現在の目標
    private RepairCut repairCut;             //RepairCutの型を保持

    private bool isAttached = false;         //血小板を中継地点に近づけるフラグ
    private bool requestWait = false;        //血小板の待機を求めるフラグ
    private int relayCount = 0;

    private Stack<passTarget> targetStack;   //ターゲットのスタック
    #endregion



    public int GetrelayCount() { return relayCount; }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        targetStack = new Stack<passTarget>();
        //スタックに初期化用のデータを登録
        targetStack.Push(passTarget.init);
    }

    // Update is called once per frame
    void Update()
    {
        // 待機リクエストがtrueになったら動きを止める
        if (requestWait) return;

        switch (relayCount)
        {
            case 0:
                Debug.Log("１フェーズ");
                // １つ目のリレーフェーズ処理
                HandleRelayPhase1();
                break;

            case 1:
                Debug.Log("２フェーズ");
                // ２つ目のリレーフェーズ処理
                HandleRelayPhase2();
                break;

            case 2:
                Debug.Log("３フェーズ");
                // ３つ目のリレーフェーズ処理
                HandleRelayPhase3();
                break;
            case 3:
                CheckArrivalAtCut();   //傷へ到着したか確認
                break;
        }

        
        MoveTowardTarget();　　//ターゲットへ移動
        
        
    }

    private void HandleRelayPhase1()
    {
        //目標とする対象が存在しないとき探索してreturn
        if (currentTarget == null)
        {
            targetCut = FindClosestCutWithinRange(detectRange);
            relayPoint = FindClosestRelayPoint1WithinRange(detectRange);

            if (targetCut != null)
            {
                currentTarget = targetCut;
                relayCount = 3;
                //targetStack.Push(passTarget.cut);
            }
            else
            {
                currentTarget = relayPoint;
            }
            return;
        }

        CheckArrivalAtRP();

        if (isAttached)
        {
            //中継地点1をスタックに登録
            targetStack.Push(passTarget.relayPoint1);

            ResetTargets();
            relayCount += 1;
        }
    }

    private void HandleRelayPhase2()
    {
        if (currentTarget == null)
        {
            targetCut = FindClosestCutWithinRange(detectRange);
            relayPoint = FindClosestRelayPoint2WithinRange(detectRange);

            if (targetCut != null)
            {
                currentTarget = targetCut;
                relayCount = 3;
                //targetStack.Push(passTarget.cut);
            }
            else
            {
                currentTarget = relayPoint;
            }
            return;
        }

        CheckArrivalAtRP();

        if (isAttached)
        {
            //中継地点2をスタックに登録
            targetStack.Push(passTarget.relayPoint2);

            ResetTargets();
            relayCount++;
        }
    }
    private void HandleRelayPhase3()
    {
        if (currentTarget == null)
        {
            targetCut = FindClosestCutWithinRange(detectRange);
            relayPoint = FindClosestRelayPoint3WithinRange(detectRange);

            if (targetCut != null)
            {
                currentTarget = targetCut;
                relayCount = 3;
                //targetStack.Push(passTarget.cut);
            }
            else
            {
                currentTarget = relayPoint;
            }
            return;
        }

        CheckArrivalAtRP();

        if (isAttached)
        {
            //中継地点3をスタックに登録
            targetStack.Push(passTarget.relayPoint3);

            ResetTargets();
            relayCount++;
        }
    }

    private void ResetTargets()
    {
        Debug.Log("中継地点をリセット");
        currentTarget = null;
        relayPoint = null;
        targetCut = null;

        isAttached = false;
        detectRange = 100f;
    }
    private void MoveTowardTarget()
    {
        if (currentTarget == null || isAttached) return;

        transform.position = Vector3.Lerp(
            transform.position,
            currentTarget.position,
            followSpeed * Time.deltaTime
        );
    }

    private  void CheckArrivalAtRP()
    {
        if (Vector2.Distance(transform.position, currentTarget.position) < 0.1f)
        {
            isAttached = true;
        }
    }
    private void CheckArrivalAtCut()
    {
        if (Vector2.Distance(transform.position, currentTarget.position) < 0.1f)
        {
            Debug.Log("傷に到着");
            //RepairCutの参照を取得
            repairCut = currentTarget.GetComponent<RepairCut>();
            requestWait = true;
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

    Transform FindClosestCutWithinRange(float range)
    {
        GameObject[] relayPoints = GameObject.FindGameObjectsWithTag("Cut");
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

    public void ResetRelayPoint()
    {
        if (relayCount == 0 && targetStack.Peek() != passTarget.relayPoint1)
        {
            isAttached = true;
        }
        else if (relayCount == 1 && targetStack.Peek() != passTarget.relayPoint2)
        {
            isAttached = true;
        }
        else if (relayCount == 2 && targetStack.Peek() != passTarget.relayPoint3)
        {
            isAttached = true;
        }
    }
}

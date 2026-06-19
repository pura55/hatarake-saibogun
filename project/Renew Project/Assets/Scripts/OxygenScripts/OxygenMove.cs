using UnityEngine;

public class OxygenMove : MonoBehaviour
{
    // 酸素の状態
    enum OxygenState
    {
        idle,      // idle
        attaching, // 接近
        rotating,  // 回転
        leaving    // 離脱
    }

    #region Config
    public float followSpeed = 3f; // 追従速度
    public float detectRange = 1f; // 検知範囲
    public float orbitRadius = 0.25f; // RBC 内部の回転半径
    public float orbitSpeed = 180f;   // 回転速度（度/秒）
    // 変更
    private int randomSignIndexX = 0;
    private int randomSignIndexY = 0;
    private Vector3 leaveVelocity = new Vector3(0f, 0f, 0f);
    private float leaveVelocityX = 0f;
    private float leaveVelocityY = 0f;
    #endregion

    #region State
    private Transform targetRbc;
    private OxygenState state = OxygenState.idle;
    private bool isAttached = false;
    private float angleOffset; // 複数酸素用の角度ずらし
    private bool isLeaving = false;
    #endregion

    void Start()
    {
        // ランダムな角度からスタート（複数酸素が重ならない）
        angleOffset = Random.Range(0f, 360f);
    }

    void Update()
    {
        switch (state)
        {
            case OxygenState.idle:

                if (targetRbc == null)
                {
                    targetRbc = FindClosestRbcWithinRange(detectRange);
                    break;
                }

                // 状態を接近に設定
                state = OxygenState.attaching;
                break;
            case OxygenState.attaching:

                //ターゲットのRBCが規定量の酸素を持っていた場合ターゲットを消去し処理を抜ける
                if (targetRbc.GetComponent<RbcStatus>().GetOneOxygenCount() == targetRbc.GetComponent<RbcStatus>().GetOxygenMaxCount())
                {
                    // ターゲットをリセット
                    targetRbc = null;
                    // 状態をidleに設定
                    state = OxygenState.idle;
                    break;
                }

                // 接近処理を実行
                AttachProcess();

                // 十分近づいたら回転モードへ
        　　　　if (Vector2.Distance(transform.position, targetRbc.position) < 0.1f)
                {
                    // 総獲得酸素数を増やす
                    OxygenCounter.Add();

                    // RBCの所持酸素数を増やす
                    targetRbc.GetComponent<RbcStatus>().AddOxygen();
                    // 状態を回転に設定
                    state = OxygenState.rotating;
                }
                break;
            case OxygenState.rotating:

                // Rbcが敵からスキルの効果を受けている時に実行
                if (targetRbc.GetComponent<PlayerMove>().GetIsEffectedEnemy())
                {
                    // 離脱する際の準備を実行
                    PreparationForLeaving();

                    // 状態を離脱に設定
                    state = OxygenState.leaving;
                    break;
                }

                // 回転処理を実行
                RotateProcess();
                break;
            case OxygenState.leaving:
                // 赤血球から一定間隔離れていらidle状態に移行
                if (Vector2.Distance(transform.position, targetRbc.position) > 2f)
                {
                    // ターゲットをリセット
                    targetRbc = null;
                    // 状態をidleに設定
                    state = OxygenState.idle;
                    break;
                }

                // 離脱処理
                transform.position = transform.position + (leaveVelocity * Time.deltaTime);
                break;
        }
    }

    // 近くに存在するRbcを検索する関数
    Transform FindClosestRbcWithinRange(float range)
    {
        GameObject[] rbcs = GameObject.FindGameObjectsWithTag("RBC");
        Transform closest = null;
        float minDist = Mathf.Infinity;

        foreach (GameObject r in rbcs)
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

    // 接近処理を実行する関数
    private void AttachProcess()
    {
        // RBC の中心に吸着
        transform.position = Vector3.Lerp(
            transform.position,
            targetRbc.position,
            followSpeed * Time.deltaTime
        );
    }

    // 回転処理を実行する関数
    private void RotateProcess()
    {
        angleOffset += orbitSpeed * Time.deltaTime;

        float rad = angleOffset * Mathf.Deg2Rad;

        Vector3 offset = new Vector3(
            Mathf.Cos(rad) * orbitRadius,
            Mathf.Sin(rad) * orbitRadius,
            0
        );

        transform.position = targetRbc.position + offset;
    }

    // Rbcから離れる際の準備処理を実行する関数
    private void PreparationForLeaving()
    {
        // x軸, y軸のランダムな符号の指数を決める
        randomSignIndexX = Random.Range(0, 2);
        randomSignIndexY = Random.Range(0, 2);

        //　指数を基に速度を設定
        if (randomSignIndexX == 0)
        {
            leaveVelocityX = 2f;
        }
        else
        {
            leaveVelocityX = -2f;
        }

        //　指数を基に速度を設定
        if (randomSignIndexY == 0)
        {
            leaveVelocityY = 2f;
        }
        else
        {
            leaveVelocityY = -2f;
        }

        leaveVelocity = new Vector3(leaveVelocityX, leaveVelocityY, 0f);

        // 総獲得酸素数を減らす
        OxygenCounter.Reduction();
        // RBCの所持酸素数を減らす
        targetRbc.GetComponent<RbcStatus>().ReductionOxygenCount();
    }
}
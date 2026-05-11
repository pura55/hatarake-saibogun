//using UnityEngine;

//public class OxygenMove : MonoBehaviour
//{
//    public float followSpeed = 3f;
//    public float detectRange = 2f; // 検知範囲
//    private Transform targetRbc;

//    void Update()
//    {
//        // ターゲットがいないなら探す
//        if (targetRbc == null)
//        {
//            targetRbc = FindClosestRbcWithinRange();
//            if (targetRbc == null) return;
//        }

//        // RBC に向かって移動
//        transform.position = Vector3.Lerp(
//            transform.position,
//            targetRbc.position,
//            followSpeed * Time.deltaTime
//        );
//    }

//    Transform FindClosestRbcWithinRange()
//    {
//        GameObject[] rbcs = GameObject.FindGameObjectsWithTag("RBC");
//        Transform closest = null;
//        float minDist = Mathf.Infinity;

//        foreach (GameObject r in rbcs)
//        {
//            float dist = Vector2.Distance(transform.position, r.transform.position);

//            // 検知範囲外は無視
//            if (dist > detectRange) continue;

//            if (dist < minDist)
//            {
//                minDist = dist;
//                closest = r.transform;
//            }
//        }

//        return closest;
//    }
//}
/// <summary>
/// 上記のコードは、再度使用するかもしれないので、コメントアウトして残しておきます。
/// </summary>

using UnityEngine;

public class OxygenMove : MonoBehaviour
{
    #region Config
    public float followSpeed = 3f; // 追従速度
    public float detectRange = 1f; // 検知範囲
    public float orbitRadius = 0.25f; // RBC 内部の回転半径
    public float orbitSpeed = 180f;   // 回転速度（度/秒）
    #endregion

    #region State
    private Transform targetRbc;
    private bool isAttached = false;
    private float angleOffset; // 複数酸素用の角度ずらし
    #endregion

    void Start()
    {
        // ランダムな角度からスタート（複数酸素が重ならない）
        angleOffset = Random.Range(0f, 360f);
    }

    void Update()
    {
        if (targetRbc == null)
        {
            targetRbc = FindClosestRbcWithinRange(detectRange);
            return;
        }

        if (!isAttached)
        {
            // RBC の中心に吸着
            transform.position = Vector3.Lerp(
                transform.position,
                targetRbc.position,
                followSpeed * Time.deltaTime
            );

            // 十分近づいたら回転モードへ
            if (Vector2.Distance(transform.position, targetRbc.position) < 0.1f)
            {
                isAttached = true;

                // 総酸素数を増やす
                OxygenCounter.Add();

                //// RBCの酸素数を増やす
                //targetRbc.GetComponent<RbcStatus>().AddOxygen();
            }
        }
        else
        {
            // 回転モード
            angleOffset += orbitSpeed * Time.deltaTime;

            float rad = angleOffset * Mathf.Deg2Rad;

            Vector3 offset = new Vector3(
                Mathf.Cos(rad) * orbitRadius,
                Mathf.Sin(rad) * orbitRadius,
                0
            );

            transform.position = targetRbc.position + offset;
        }
    }

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
}

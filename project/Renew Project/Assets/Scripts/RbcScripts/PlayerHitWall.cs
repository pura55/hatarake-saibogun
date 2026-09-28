using UnityEngine;

/// <summary>
/// 担当：石﨑福人
/// 
/// プレイヤーの壁の当たり判定クラス
/// </summary>
public class PlayerHitWall : MonoBehaviour
{

    #region State
    [SerializeField] private bool isCollidingWithWall = false; // 当たり判定のフラグ
    #endregion

    #region Public Methods
    /// @brief 当たり判定のフラグを返す関数
    public bool GetIsCollidingWithWall() { return isCollidingWithWall; }
    #endregion
    void Start()
    {
        
    }

    private void Update()
    {
        isCollidingWithWall = false;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("ぶつかった相手: " + col.gameObject.name);
        if (col.gameObject.CompareTag("Wall"))
        {
            Debug.Log("壁にぶつかった！");
            isCollidingWithWall = true;
        }
    }
}

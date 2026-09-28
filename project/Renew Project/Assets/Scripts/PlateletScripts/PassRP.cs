using UnityEngine;

/// <summary>
/// 担当：石﨑福人
/// 
/// リレーポイントの通過処理
/// </summary>

public class PassRP : MonoBehaviour
{
    private RelayPointStatus relayPointStatus;
    private PlateletMove plateletMove;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // 同じオブジェクトから自動で持ってくる
        relayPointStatus = GetComponent<RelayPointStatus>();
    }

    // Update is called once per frame
    void Update()
    {
        if (relayPointStatus == null) return;

        // 通過した場合
        if (relayPointStatus.GetIsPass())
        {
            // plateletMoveがnullの状態で実行されないようにチェック
            if (plateletMove != null)
            {
                // 中継地点をリセット
                plateletMove.ResetRelayPoint();
            }
            // 通過フラグを設定
            relayPointStatus.SetIsPass(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Platelet"))
         {
            Debug.Log("リレーポイントを通過した");
            if (!relayPointStatus.GetIsPass())
            {
                relayPointStatus.SetIsPass(true);
                plateletMove = col.GetComponent<PlateletMove>();
            }
         }
    }
}

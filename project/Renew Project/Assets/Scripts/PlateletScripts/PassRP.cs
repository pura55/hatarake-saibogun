using UnityEngine;

/// <summary>
/// 担当：石﨑福人
/// 
/// リレーポイントの通過処理
/// </summary>

public class PassRP : MonoBehaviour
{
    public RelayPointStatus relayPointStatus;
    private Transform targetPlatelet;
    PlateletMove plateletMove;
    
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

        if (relayPointStatus.GetIsPass())
        {
            // plateletMoveがnullの状態で実行されないようにチェック
            if (plateletMove != null)
            {
                plateletMove.ResetRelayPoint();
            }
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

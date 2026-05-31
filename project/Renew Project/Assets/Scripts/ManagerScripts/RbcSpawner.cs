using UnityEngine;

/// <summary>
/// 担当：石﨑福人
/// 
/// 赤血球スポーン
/// </summary>
public class RbcSpawner : MonoBehaviour
{
    #region Config
    [SerializeField] private int currentSpawnIndex = 1;
    private int spawnCounter = 0;
    #endregion

    #region State
    public GameObject rbcToSpawn;
    public Vector3 spawnRange = new Vector3(4.1f, 4.5f, 0f);
    public Timer timer;
    #endregion

    void Start()
    {
        RbcSpawn();
    }

    public void AddRbcSpawn(int addCount)
    {
        currentSpawnIndex += addCount;
        Debug.Log($"赤血球をスポーン数:{currentSpawnIndex}");
        RbcSpawn();
    }

    //ゲーム開始時に赤血球を生成
    public void RbcSpawn()
    {
        //現在の赤血球のスポーン数を超えたら処理を抜ける
        while (spawnCounter < currentSpawnIndex)
        {
            Debug.Log("赤血球をスポーン中");
            // ランダムな位置を計算
            float randomX = Random.Range(-spawnRange.x / 2, spawnRange.x / 2);
            float randomY = Random.Range(-spawnRange.y / 2, spawnRange.y / 2);
            float randomZ = Random.Range(-spawnRange.z / 2, spawnRange.z / 2);

            //このスクリプトが付いているオブジェクトの位置を基準にする
            Vector3 spawnPosition = transform.position + new Vector3(randomX, randomY, randomZ);

            //オブジェクト生成
            GameObject spawnedPlayer = Instantiate(rbcToSpawn, spawnPosition, Quaternion.identity);

            //参照を取得
            PlayerMove playerScript = spawnedPlayer.GetComponent<PlayerMove>();

            //赤血球にタイマーのオブジェクトの参照を渡す
            if (playerScript != null)
            {
                playerScript.Init(timer);
            }
            //カウンターを増やす
            spawnCounter += 1;
        }
    }
    // 開発画面（Scene）に生成範囲を視覚的に表示する機能
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, spawnRange);
    }
}

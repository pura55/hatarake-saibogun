using UnityEngine;

/// <summary>
/// 担当：石﨑福人
/// 
/// 白血球スポーン
/// </summary>
public class WbcSpawner : MonoBehaviour
{
    #region Config
    [SerializeField] private int currentSpawnIndex = 1;
    private int spawnCounter = 0;
    #endregion

    #region State
    public GameObject wbcToSpawn;
    public Vector3 spawnRange = new Vector3(4.1f, 4.5f, 0f);
    public StatusSkill status;
    #endregion
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentSpawnIndex = status.wbcAmount;
        WbcSpawn();
    }
    public void AddWbcSpawn(int addCount)
    {
        currentSpawnIndex += addCount;
        Debug.Log($"白血球をスポーン数:{currentSpawnIndex}");
        WbcSpawn();
    }
    void WbcSpawn()
    {
        //現在の白血球のスポーン数を超えたら処理を抜ける
        while (spawnCounter < currentSpawnIndex)
        {
            Debug.Log("白血球をスポーン中");
            // ランダムな位置を計算
            float randomX = Random.Range(-spawnRange.x / 2, spawnRange.x / 2);
            float randomY = Random.Range(-spawnRange.y / 2, spawnRange.y / 2);
            float randomZ = Random.Range(-spawnRange.z / 2, spawnRange.z / 2);

            //このスクリプトが付いているオブジェクトの位置を基準にする
            Vector3 spawnPosition = transform.position + new Vector3(randomX, randomY, randomZ);

            //オブジェクト生成
            GameObject spawnedWbc = Instantiate(wbcToSpawn, spawnPosition, Quaternion.identity);

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

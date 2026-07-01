using UnityEngine;

public class PlateletSpawner : MonoBehaviour
{
    #region Config
    private int currentSpawnIndex = 0; // 現在のスポーンする回数
    private int spawnCounter = 0;      // スポーンを数える変数
    private const float spawnZ = 1f;   // z軸のスポーン座標
    #endregion

    #region State
    public GameObject plateletToSpawn;                       // スポーンさせる対象オブジェクト
    public Vector3 spawnRange = new Vector3(4.1f, 4.5f, 0f); // スポーン範囲
    public StatusSkill status;
    #endregion
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentSpawnIndex = status.pltAmount;

        // 血小板の生成処理を実行
        PlateletSpawn();
    }

    // ゲーム開始時に血小板を生成します
    private void PlateletSpawn()
    {
        //現在の血小板のスポーン数を超えたら処理を抜ける
        while (spawnCounter < currentSpawnIndex)
        {
            Debug.Log("敵をスポーン中");
            // ランダムな位置を計算
            float randomX = Random.Range(-spawnRange.x / 2, spawnRange.x / 2);
            float randomY = Random.Range(-spawnRange.y / 2, spawnRange.y / 2);

            // このスクリプトが付いているオブジェクトの位置を基準にする
            Vector3 spawnPosition = transform.position + new Vector3(randomX, randomY, spawnZ);

            //オブジェクト生成
            GameObject spawnedPlt = Instantiate(plateletToSpawn, spawnPosition, Quaternion.identity);

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

using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    
    
    
    #region Config
    private int currentSpawnIndex = 1;   // 現在のスポーンする回数
    private int spawnCounter = 0;        // スポーンを数える変数
    private float checkRadius = 0.5f;    // 判定の範囲（球体の半径）
    private const float spawnZ = 0f;     // z軸のスポーン座標
    #endregion

    #region State
    public GameObject enemyToSpawn;                          // スポーンさせる対象オブジェクト
    public Vector3 spawnRange = new Vector3(4.1f, 4.5f, 0f); // スポーン範囲
    public string targetTagWall = "Wall";                    // 検知したいタグ(壁)
    public string targetTagCut = "Cut";                      // 検知したいタグ(傷)
    #endregion
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // 病原菌の生成処理を実行
        EnemySpawn();
    }

    // ゲーム開始時に敵を生成します
    private void EnemySpawn()
    {
        //現在の病原菌のスポーン数を超えたら処理を抜ける
        while (spawnCounter < currentSpawnIndex)
        {
            Debug.Log("敵のスポーン処理中");

            // ランダムな位置を計算
            float randomX = Random.Range(-spawnRange.x / 2, spawnRange.x / 2);
            float randomY = Random.Range(-spawnRange.y / 2, spawnRange.y / 2);

            // このスクリプトが付いているオブジェクトの位置を基準にする
            Vector3 spawnPosition = transform.position + new Vector3(randomX, randomY, spawnZ);

            // 確認範囲内にあるコライダーを格納
            Collider2D[] hitColliders = Physics2D.OverlapCircleAll(spawnPosition, checkRadius);

            // 障害物が見つかったかどうかのフラグ
            bool foundTheObstacle = false;

            // 見つかったコライダーを1つずつループで確認
            foreach (var hitCollider in hitColliders)
            {
                // インスペクターで設定されたタグが一致するかチェック
                if (hitCollider.CompareTag(targetTagWall) || hitCollider.CompareTag(targetTagCut))
                {
                    foundTheObstacle = true;
                    Debug.Log(" 2D座標で障害物を検知: " + hitCollider.gameObject.name);
                    Debug.Log(" 生成座標を移動させます");
                }
            }

            // 障害物がある場合処理をスキップします
            if (foundTheObstacle) continue;

            //オブジェクト生成
            GameObject spawnedEnemy = Instantiate(enemyToSpawn, spawnPosition, Quaternion.identity);

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

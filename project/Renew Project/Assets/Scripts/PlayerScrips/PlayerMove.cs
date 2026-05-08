using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    //レギオンを使用することで、コードを整理できる

    // Configはゲームの設定値(例:速度、体力など)をまとめるためのセクション
    #region Config 
    //移動速度
    [SerializeField] public float speed = 3f;//[SerializeField]をつけると、Unityエディタ上でこの変数を編集できるようになる
    #endregion

    // Stateはゲームの状態を管理するためのセクション
    #region State
    //目標座標
    private Vector3 targetPos;
    #endregion

    #region Unity Lifecycle

    void Start()
    {
       
    }
    void Update()
    {
        // 毎フレーム、マウス位置をターゲットにする
        Vector3 mousePos = Mouse.current.position.ReadValue();
        mousePos.z = 10f; // カメラからの距離
        targetPos = Camera.main.ScreenToWorldPoint(mousePos);

        //毎フレーム、壁に衝突しているかどうかを判定
        PlayerHitWall hitWall = GetComponent<PlayerHitWall>();
        if (hitWall.GetIsCollidingWithWall())
        {
            speed = 0f; //壁に衝突している場合は移動速度を0に設定
        }
        else
        {
            speed = 3f;
        }

        // プレイヤーをマウス位置へ移動
        transform.position = Vector3.MoveTowards(
            transform.position,
            targetPos,
            speed * Time.deltaTime
        );
    }
    #endregion
}


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
    //目標があるかどうか
    private bool hasTarget = false;
    #endregion


    // Unity LifecycleはUnityの特定のイベント(例: Start, Updateなど)に関連するコードをまとめるためのセクション
    #region Unity Lifecycle
    void Start()
    {

    }
    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Vector3 mousePos = Mouse.current.position.ReadValue();
            mousePos.z = 10f;//カメラからの距離を設定

            targetPos = Camera.main.ScreenToWorldPoint(mousePos);
            hasTarget = true;
        }


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

        //目標がある場合、プレイヤーを目標に向かって移動させる
        if (hasTarget)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

            //プレイヤーが目標に到着
            if (Vector3.Distance(transform.position, targetPos) < 0.1f)
            {
                hasTarget = false; //目標をリセット
            }
        }
    }
    #endregion
}


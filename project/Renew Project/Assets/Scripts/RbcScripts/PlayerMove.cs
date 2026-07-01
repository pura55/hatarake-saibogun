using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using static UnityEngine.GraphicsBuffer;

public class PlayerMove : MonoBehaviour
{
    //レギオンを使用することで、コードを整理できる

    // Configはゲームの設定値(例:速度、体力など)をまとめるためのセクション
    #region Config 
    //[SerializeField]をつけると、Unityエディタ上でこの変数を編集できるようになる

    [SerializeField] private float speed = 5f;//移動速度
    [SerializeField] public float effectedTime = 2f;//効果を受ける時間
    #endregion

    // Stateはゲームの状態を管理するためのセクション
    #region State
    private Timer timer;                 //タイマーの参照 
    private Vector3 targetPos;           //目標座標
    private bool hasTarget = false;      //目標があるかどうか
    public bool IsFreez = true;          //フリーズのフラッグ(true:フリーズ中, false:行動中)
    private bool isEffectedEnemy = false;//敵からの効果のフラッグ(true:効果を受けている, false:効果を受けていない)
    private bool isGoal = false;         //ゴールしたかどうか
    private float currentEffectedTime = 0f; //現在の効果時間
    public StatusSkill status;
    #endregion

    // 敵からの効果を判定するフラグを設定する関数
    public void SetIsEffectedEnemy(bool isEffected) { isEffectedEnemy = isEffected; }

    // 敵からの効果を判定するフラグを返す関数
    public bool GetIsEffectedEnemy() { return isEffectedEnemy; }
    // Unity LifecycleはUnityの特定のイベント(例: Start, Updateなど)に関連するコードをまとめるためのセクション
    #region Unity Lifecycle
    void Start()
    {
        speed = status.rbcSpeed;
    }
    void Update()
    {
        if (IsFreez)
        {
            if (timer.GetLeftTime())
            {
                return;
            }
        }
        //ゴールしたら
        if (isGoal)
        {
            if (SceneManager.GetActiveScene().name == "PlayScene")
            {
                // PlaySceneは上へ
                transform.position += Vector3.up * 5f * Time.deltaTime;
            }
            else
            {
                // map1～map5は右へ
                transform.position += Vector3.right * 5f * Time.deltaTime;
            }

            return;
        }

        if(isEffectedEnemy)
        {
            EffectedTimeCounter();
            return;
        }


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
            // 速度が存在する場合ターゲットをfalseにする
            if(speed > 0f)
            {
                hasTarget = false;
            }
            speed = 0f; //壁に衝突している場合は移動速度を0に設定
            return;
        }
        else
        {
            speed = status.rbcSpeed;
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

    public void Init(Timer times)
    {
        timer = times;
    }
    //ゴールしたら動く
    public void StartGoalMove()
    {
        isGoal = true;
    }

    public void EffectedTimeCounter()
    {
        if (currentEffectedTime< effectedTime)
        {
            currentEffectedTime += Time.deltaTime;
        }
        else
        {
            currentEffectedTime = 0f;
            SetIsEffectedEnemy(false);
        }
    }
}


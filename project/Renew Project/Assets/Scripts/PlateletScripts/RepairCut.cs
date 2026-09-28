using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 担当：石﨑福人
/// 
/// 傷の修復
/// </summary>

public class RepairCut : MonoBehaviour
{
    #region Config
    private int maxPlatelet = 10;   //血小板の最大値
    public int cutLevel = 1;
    public float maxRepairTime = 2.0f;   //修復されるまでの時間
    #endregion

    #region State
    private int currentPlatelet = 0;        // 現在の血小板の個数
    private float currentTime = 0.0f;       // 現在の修復時間
    private Stack<Transform> plateletStack; // 血小板のスタック
    public StatusSkill status;
    public GameObject effectPrefab;　// 修復エフェクトのプレハブ
    private GameObject effectInstans; // 修復エフェクトのインスタンス
    private bool isSpawned = false;  // スポーンのフラグ（true:スポーンした　false:スポーンしてない)
    [SerializeField] private AudioSource repairAudioSource; // 傷修復SE用のオーディオソース
    [SerializeField] private AudioClip repairSE; // 傷修復SE
    private bool canPlaySE = true;  // SEを再生できるかどうかのフラグ
    private float playingTimeOfSE = 0.0f;  // SEの再生時間
    private CutTextController cutTextController; // 血小板をの個数を表示するテキスト
    #endregion

    public int GetMaxPlatelet() { return maxPlatelet; } // 血小板の最大値を返す関数
    public int GetCurrentPlatelet() { return currentPlatelet; } // 血小板の現在値を返す関数

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        maxRepairTime = status.pltCure;
        plateletStack = new Stack<Transform>();

        // 傷のレベルによって必要な血小板の最大値を変更
        switch(cutLevel)
        {
            case 1: // level1
                maxPlatelet = 10;
                break;
            case 2: // level2
                maxPlatelet = 18;
                break;
            case 3: // level3
                maxPlatelet = 25;
                break;
        }

        // 参照を取得
        cutTextController = GetComponent<CutTextController>();
        // 必要な血小板の個数を設定
        cutTextController.SetPlateletNum(maxPlatelet);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentPlatelet >= maxPlatelet)
        {
            PlayRepairSE(); //修復用SEを再生
            AddCurrentTime(); //時間を加算
        }
        
        if (currentTime >= maxRepairTime)
            CompleteRepair(); //修復完了後の処理
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.gameObject.CompareTag("Platelet")) return;

        //血小板の進入時の処理を実行
        HandlePlateletEnter(col.transform);

        // テキストの計算処理を実行
        cutTextController.CalculatePlateletNum();

        if (plateletStack.Count >= maxPlatelet　&& !isSpawned)
            PlayRepairEffect();
    }

    // 血小板が入った時の処理を行う関数
    private void HandlePlateletEnter(Transform platelet)
    {
        AddPlatelet();                //血小板の個数を加算する
        RegisterPlatelet(platelet);  //血小板をスタックに登録する

        Debug.Log($"現在の血小板の個数：{currentPlatelet}");
    }

    //血小板を登録する関数
    public void RegisterPlatelet(Transform platelet)
    {
        plateletStack.Push(platelet);
    }
    //傷の修復が完了した後の処理を行う関数
    private void CompleteRepair()
    {
        //血小板と傷を削除
        DestroyPlatelets();
        Destroy(gameObject);
    }
    //血小板の削除を行う関数
    private void DestroyPlatelets()
    {
        while (plateletStack.Count > 0)
        {
            Destroy(plateletStack.Peek().gameObject);
            plateletStack.Pop();
        }
        // SEを止める
        repairAudioSource.Stop();

        // エフェクトを削除
        Destroy(effectInstans);
    }
    //修復にかかる時間の加算を行う関数
    private void AddCurrentTime()
    {
        currentTime += Time.deltaTime;
    }
    //血小板の個数を加算する関数
    private void AddPlatelet()
    {
        currentPlatelet++;
    }
    // 傷を修復するエフェクトを実行する関数
    private void PlayRepairEffect()
    {
        Vector3 effectPosition = transform.position;
        // エフェクトのz座標を0に設定
        if (effectPosition.z != 1f)
        {
            effectPosition.z = 1f;
        }

        // ゴールの座標（transform.position）にエフェクトを生成
        effectInstans = Instantiate(effectPrefab, effectPosition, Quaternion.identity);

        // スポーン済みにする
        isSpawned = true;
    }

    // 傷修復SEを再生する関数
    private void PlayRepairSE()
    {
        if (canPlaySE)
        {
            // 再生する前に一度止める
            if (repairAudioSource.isPlaying)
            {
                repairAudioSource.Stop();
            }
            repairAudioSource.PlayOneShot(repairSE);
            canPlaySE = false;
        }

        // 再生時間を加算
        playingTimeOfSE += Time.deltaTime;

        // SEを再生しきったら再びcanPlaySEをtrue
        if (playingTimeOfSE >= 1.3f)
        {
            canPlaySE = true;
            playingTimeOfSE = 0.0f;
        }
    }

}

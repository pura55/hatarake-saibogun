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
    public int maxPlatelet = 10;   //血小板の最大値
    public float maxRepairTime = 2.0f;   //修復されるまでの時間
    #endregion

    #region State
    private int currentPlatelet = 0;        // 現在の血小板の個数
    private float currentTime = 0.0f;       // 現在の修復時間
    private Stack<Transform> plateletStack; // 血小板のスタック
    public StatusSkill status;
    public GameObject effectPrefab;　// 修復エフェクトのプレハブ
    private GameObject effectInstans;
    #endregion

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        maxRepairTime = status.pltCure;
        plateletStack = new Stack<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentPlatelet >= maxPlatelet)
            AddCurrentTime(); //時間を加算
        
        if (currentTime >= maxRepairTime)
            CompleteRepair(); //修復完了後の処理
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.gameObject.CompareTag("Platelet")) return;

        //血小板の進入時の処理を実行
        HandlePlateletEnter(col.transform);

        if (plateletStack.Count >= maxPlatelet)
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
    }
   
}

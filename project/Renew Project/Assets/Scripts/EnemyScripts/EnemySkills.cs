using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class EnemySkills : MonoBehaviour
{
    #region State
    //スキルを使用したかどうかのフラッグ(true:使用済み, false:未使用)
    private bool isUsedSkill = false;
    //赤血球と接触しているかどうかのフラッグ(true:既接触, false:未接触)
    private bool isHitRbc = false;
    public EnemyDetection enemyDetection;
    private Transform targetRbc;
    #endregion
    public bool GetUsedSkill() { return isUsedSkill; }
    public void SetUsedSkill(bool isUsed) { isUsedSkill = isUsed; }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isHitRbc)
        {
            //PlayerMoveの参照を取得
            PlayerMove playerScript = targetRbc.GetComponent<PlayerMove>();
            //スキルの効果を反映する
            playerScript.SetIsEffectedEnemy(true);
            //スキルを使用済みに変更
            SetUsedSkill(true);
            //Enemyを硬直指せる
            enemyDetection.SetIsFreez(true);
            //接触判定をリセット
            isHitRbc = false;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (!isUsedSkill)
        {
            Debug.Log("ぶつかった相手: " + col.gameObject.name);
            if (col.gameObject.CompareTag("RBC"))
            {
                Debug.Log("赤血球に接触した！");
                //赤血球の参照を取得
                targetRbc = col.transform;
                isHitRbc = true;
                //Destroy(col.gameObject);
            }
        }
    }
}

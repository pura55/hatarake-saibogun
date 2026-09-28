using System.Security.Cryptography;
using UnityEngine;

/// <summary>
/// 担当：石﨑福人
/// 
/// 酸素のエフェクトを移動させるクラス
/// </summary>
public class GetOxygenEffectMove : MonoBehaviour
{
    private Transform RBC; // 赤血球の参照
    private Vector3 constantPosition = new Vector3(0f, 0f, -2f); // Z軸の固定座標
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 赤血球の座標をこのエフェクトの座標とする
        transform.position = RBC.position + constantPosition;
    }

    /// @brief 赤血球の参照の受け取る関数
    public void SetRbcReference(Transform rbc)
    {
        // 赤血球の参照を受け取る
        RBC = rbc;
    }
}

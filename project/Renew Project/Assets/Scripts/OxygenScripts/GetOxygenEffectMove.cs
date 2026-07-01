using System.Security.Cryptography;
using UnityEngine;

public class GetOxygenEffectMove : MonoBehaviour
{
    private Transform RBC; // 赤血球の参照
    private Vector3 constantPosition = new Vector3(0f, 0f, -2f);
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

    // 赤血球の参照の受け取る関数
    public void SetRbcReference(Transform rbc)
    {
        // 赤血球の参照を受け取る
        RBC = rbc;
    }
}

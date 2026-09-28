using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClearText : MonoBehaviour
{
    private Vector3  maxMovementAmount = new Vector3(2000.0f, 0f, 0f);
    private Vector3 startPosition;
    [SerializeField] private float duration = 0.5f; // 移動にかける時間（秒）

    private RectTransform rectTransform;

    private void Awake()
    {
        // UI（TMP）の位置を制御するRectTransformを取得
        rectTransform = GetComponent<RectTransform>();
        // 最初に出現した時の初期位置を記憶
        startPosition = rectTransform.localPosition;
    }

    private void OnEnable()
    {
        Debug.Log("クリアがアクティブになりました");
        // 位置を毎回初期位置に戻す（これがないと毎回ずれていく）
        rectTransform.localPosition = startPosition;

        // 移動処理（コルーチン）を開始
        StartCoroutine(MoveTextCoroutine());
    }

    private IEnumerator MoveTextCoroutine()
    {
        Vector3 targetPosition = startPosition + maxMovementAmount;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            // イージング（滑らかな動き）をさせたい場合はLerpを使う
            rectTransform.localPosition = Vector3.Lerp(startPosition, targetPosition, elapsedTime / duration);
            yield return null; // 1フレーム待つ
        }

        rectTransform.localPosition = targetPosition; // 最後に目標位置に完全に合わせる
    }
}

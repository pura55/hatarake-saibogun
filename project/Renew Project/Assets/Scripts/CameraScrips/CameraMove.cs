using UnityEngine;
using UnityEngine.InputSystem;
//担当　千葉結加

public class CameraMove : MonoBehaviour
{
    private Vector3 lastMousePos;

    float minX = 15f;
    float maxX = 40f;
    float minY = 10f;
    float maxY = 28f;

    void Update()
    {
        Vector3 pos = transform.position;

        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        transform.position = pos;
        // 左クリックした瞬間
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            lastMousePos = Mouse.current.position.ReadValue();
        }

        // 左クリック中
        if (Mouse.current.leftButton.isPressed)
        {
            Vector3 currentMousePos = Mouse.current.position.ReadValue();

            Vector3 delta = currentMousePos - lastMousePos;

            // マウス移動と逆方向にカメラを動かす
            transform.position -= new Vector3(delta.x, delta.y, 0) * 0.02f;

            lastMousePos = currentMousePos;
        }
    }
}
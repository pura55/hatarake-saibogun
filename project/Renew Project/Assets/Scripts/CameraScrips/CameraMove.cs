using UnityEngine;
using UnityEngine.InputSystem;
//íSìñÅ@êÁótåãâ¡

public class CameraMove : MonoBehaviour
{   
    #region Config 
    public float moveSpeed = 5f;
    #endregion

    #region State
    private Vector3 targetPos;
    #endregion
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        targetPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {

            Vector2 mousePos = Mouse.current.position.ReadValue();

            Vector3 worldPos =Camera.main.ScreenToWorldPoint(mousePos);

            worldPos.z = transform.position.z;

            transform.position = worldPos;
        }
        //transform.position =Vector3.Lerp(transform.position, targetPos, moveSpeed * Time.deltaTime);
    }
}
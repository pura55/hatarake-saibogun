using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;


//íSìñÅ@êÁótåãâ¡

public class SkillDetail : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    //private Image image;

    [SerializeField] private GameObject descriptionUI;


    void Start()
    {
        //image = GetComponent<Image>();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {//image.color = Color.white;
        //rect.position = eventData.position;

        if (descriptionUI != null)
        {
            descriptionUI.SetActive(true);

            RectTransform rect = descriptionUI.GetComponent<RectTransform>();

            Vector2 pos = eventData.position + new Vector2(70, 70);

            pos.x = Mathf.Clamp(pos.x, rect.rect.width / 2, Screen.width - rect.rect.width / 2);

            pos.y = Mathf.Clamp(pos.y, rect.rect.height / 2, Screen.height - rect.rect.height / 2);

            rect.position = pos;
            //rect.position = eventData.position + new Vector2(100, 100);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //image.color = Color.gray7;
        if (descriptionUI != null)
        {
            descriptionUI.SetActive(false);
        }
    }
}
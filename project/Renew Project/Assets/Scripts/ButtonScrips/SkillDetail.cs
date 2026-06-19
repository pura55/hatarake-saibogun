using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
//’S“–@ç—tŒ‹‰Á

public class SkillDetail : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Image image;

    void Start()
    {
        image = GetComponent<Image>();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        image.color = Color.white;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        image.color = Color.gray7;
    }
}
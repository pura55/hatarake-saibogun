using UnityEngine;
using UnityEngine.UI;

public class Buttonbright : MonoBehaviour
{
    //Button button;
    Image image;

    bool isOn = false;

    void Start()
    {
        //button = GetComponent<Button>();
        image = GetComponent<Image>();

        //button.onClick.AddListener(ChangeColor);
    }
    public void LightUp()
    {
        if (!isOn)
        {
            //ëOÇÃLvÇâï˙ÇµÇ»Ç¢Ç∆âüÇπÇ»Ç¢ÅAåıÇÁÇ»Ç¢ÇÊÇ§Ç…Ç∑ÇÈ
            Color c = image.color;

            c.r = Mathf.Clamp01(c.r + 0.5f);
            c.g = Mathf.Clamp01(c.g + 0.5f);
            c.b = Mathf.Clamp01(c.b + 0.5f);

            image.color = c;
            isOn = true;
        }
    }
    //    void ChangeColor()
    //    {
    //
    //
    //
    //{
    //    image.color = Color.white;
    //}
    //    }
}
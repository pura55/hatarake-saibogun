using UnityEngine;
using TMPro;
//íSìñÅ@êÁótåãâ¡

public class SkillSceneOx : MonoBehaviour
{
    public TMP_Text UIText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UIText.text = OxygenCounter.totalOxygen.ToString();
        //gameObject.GetComponent<Text>().text = OxygenCounter.totalOxygen;
    }
}

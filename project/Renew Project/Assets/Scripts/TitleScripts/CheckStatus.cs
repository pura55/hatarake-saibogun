using UnityEngine;
//’S“–@ç—tŒ‹‰Á
public class NewMonoBehaviourScript : MonoBehaviour
{
    public StatusSkill statusSkill;
    private int RBCNum;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        RBCNum = statusSkill.rbcAmount;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
using UnityEngine;

//ScriptableObjectƒeƒXƒg

[CreateAssetMenu(fileName = "StatusSkill", menuName = "Game/StatusSkill")]
public class StatusSkill : ScriptableObject
{
    public float rbcSpeed = 5f;
    public int rbcAmount = 1;
    public int rbcHave = 1;

    public float wbcTime = 2f;
    public float wbcRange = 1f;
    public int wbcAmount = 0;

    public float pltCure = 1f;
    public int pltAmount = 0;

    public int stageTime = 10;
    public int stageOx = 30;
}
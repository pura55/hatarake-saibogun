using UnityEngine;
//’S“–@ç—tŒ‹‰Á

public static class SkillMax
{
    private static bool isSkillMax = false;
    private static int skillMaxNum;

    public static void CheckSkillMax()
    {
        if (skillMaxNum >= 10)
        {
            isSkillMax = true;
            Debug.Log(skillMaxNum);
        }
    }

    public static void AddSkillMax()
    {
        skillMaxNum++;
        Debug.Log(skillMaxNum);
    }

    public static bool GetIsSkillMax() { return isSkillMax; }
}

using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
//íSìñÅ@êÁótåãâ¡
public class Buttonbright : MonoBehaviour
{
    public enum SkillType
    {
        RBCSpeed,
        RBCAmount,
        RBCHave,
        WBCTime,
        WBCRange,
        WBCAmount,
        PLTCure,
        PLTAmount,
        StageTime,
        StageOx
    }
    public SkillType skillType;

    public int myLevel;

    public Image image;
    

    void Start()
    {
        image = GetComponent<Image>();
        RefreshButton();
    }
    public void RefreshButton()
    {
        int currentLevel = GetCurrentLevel();
        void OnPointerEnter(PointerEventData eventData)
        {
            if (currentLevel > myLevel)
            {
                image.color = Color.white;
            }
        }
        void OnPointerExit(PointerEventData eventData)
        {
            image.color = Color.gray7;
        }
            //else
            //{
            //    image.color = Color.gray;
            //}
        }
    public void Bright()
    {
        int currentLevel = GetCurrentLevel();
        if (currentLevel != myLevel)
        {
            Debug.Log("èáî‘Ç™à·Ç§");
            return;
        }

        //AddLevel();
        //RefreshButton();
    }
    int GetCurrentLevel()
    {
        switch (skillType)
        {
            case SkillType.RBCSpeed:
                return SkillUnlock.rbcSpeedLevel;

            case SkillType.RBCAmount:
                return SkillUnlock.rbcAmountLevel;

            case SkillType.RBCHave:
                return SkillUnlock.rbcHaveLevel;

            case SkillType.WBCTime:
                return SkillUnlock.wbcTimeLevel;

            case SkillType.WBCRange:
                return SkillUnlock.wbcRangeLevel;

            case SkillType.WBCAmount:
                return SkillUnlock.wbcAmountLevel;

            case SkillType.PLTCure:
                return SkillUnlock.pltCureLevel;

            case SkillType.PLTAmount:
                return SkillUnlock.pltAmountLevel;

            case SkillType.StageTime:
                return SkillUnlock.stageTimeLevel;

            case SkillType.StageOx:
                return SkillUnlock.stageOxLevel;
        }

        return 0;
    }

    public void AddLevel()
    {
        switch (skillType)
        {
            case SkillType.RBCSpeed:
                SkillUnlock.rbcSpeedLevel++;
                break;

            case SkillType.RBCAmount:
                SkillUnlock.rbcAmountLevel++;
                break;

            case SkillType.RBCHave:
                SkillUnlock.rbcHaveLevel++;
                break;

            case SkillType.WBCTime:
                SkillUnlock.wbcTimeLevel++;
                break;

            case SkillType.WBCRange:
                SkillUnlock.wbcRangeLevel++;
                break;

            case SkillType.WBCAmount:
                SkillUnlock.wbcAmountLevel++;
                break;

            case SkillType.PLTCure:
                SkillUnlock.pltCureLevel++;
                break;

            case SkillType.PLTAmount:
                SkillUnlock.pltAmountLevel++;
                break;

            case SkillType.StageTime:
                SkillUnlock.stageTimeLevel++;
                break;

            case SkillType.StageOx:
                SkillUnlock.stageOxLevel++;
                break;
        }
    }
}
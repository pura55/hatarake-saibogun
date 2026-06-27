using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UnityEngine.Rendering.VolumeComponent;
//íSìñÅ@êÁótåãâ¡
public class Buttonbright :MonoBehaviour//,IPointerEnterHandler,IPointerExitHandler
{
    public enum SkillType
    {
        SkillButton,
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
    public StatusSkill status;
    public int myLevel;
    public int needOxygen;
    public Image image;

    void Start()
    {
        image = GetComponent<Image>();
        RefreshButton();
        //Bright();
    }
    //public void OnPointerEnter(PointerEventData eventData)
    //{
    //    int currentLevel = GetCurrentLevel();

    //    if (currentLevel > myLevel)
    //    {
    //        image.color = Color.white;
    //    }
    //}

    //public void OnPointerExit(PointerEventData eventData)
    //{
    //    image.color = Color.gray7;
    //}
    //else
    //{
    //    image.color = Color.gray;
    //}

    public void RefreshButton()
    {
        int currentLevel = GetCurrentLevel();

        // âï˙çœÇ›
        if (currentLevel >= myLevel)
        {
            image.color = Color.white;
        }
        // éüÇ…âï˙Ç≈Ç´ÇÈ
        else if (CanUnlock())
        {
            image.color = Color.yellow;
        }
        // Ç‹Çæâï˙Ç≈Ç´Ç»Ç¢
        else
        {
            image.color = Color.gray7;
        }

        
    }

    bool CanUnlock()
    {
        int currentLevel = GetCurrentLevel();

        switch (skillType)
        {
            case SkillType.RBCSpeed:
                return currentLevel + 1 == myLevel && OxygenCounter.totalOxygen >= needOxygen && SkillUnlock.rbcAmountLevel >= 1;

            case SkillType.RBCHave:
                return currentLevel + 1 == myLevel && OxygenCounter.totalOxygen >= needOxygen && SkillUnlock.rbcAmountLevel >= 1;

            case SkillType.WBCTime:
                return currentLevel + 1 == myLevel && OxygenCounter.totalOxygen >= needOxygen && SkillUnlock.wbcAmountLevel >= 1;

            case SkillType.WBCRange:
                return currentLevel + 1 == myLevel && OxygenCounter.totalOxygen >= needOxygen && SkillUnlock.wbcAmountLevel >= 1;

            default:
                return currentLevel + 1 == myLevel && OxygenCounter.totalOxygen >= needOxygen;
        }
    }

    public void Bright()
    {
        if (!CanUnlock())
        {
            Debug.Log("èåèÇñûÇΩÇµÇƒÇ¢Ç‹ÇπÇÒ");
            return;
        }

        AddLevel();

        Buttonbright[] buttons =
            FindObjectsByType<Buttonbright>(FindObjectsSortMode.None);

        foreach (Buttonbright button in buttons)
        {
            button.RefreshButton();
        }
    }
    int GetCurrentLevel()
    {
        switch (skillType)
        {
            case SkillType.SkillButton:
                return SkillUnlock.skillButtonLevel;

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
            //case SkillType.SkillButton:
            //    SkillUnlock.skillButtonLevel++;
            //    break;

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
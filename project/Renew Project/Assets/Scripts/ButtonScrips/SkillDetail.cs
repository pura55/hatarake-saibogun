using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using static Buttonbright;
//íSìñÅ@êÁótåãâ¡

public class SkillDetail : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    //private Image image;

    [SerializeField] private GameObject descriptionUI;
    public Text skillText;
    public SkillType skillType;
    public StatusSkill status;
    public Buttonbright buttonbright;

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

    void Start()
    {
        //image = GetComponent<Image>();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (descriptionUI != null)
        {
            descriptionUI.SetActive(true);

            RectTransform rect = descriptionUI.GetComponent<RectTransform>();
            rect.anchoredPosition = new Vector2(-135, -170);

            if (UnlockCheck())
            {
                skillText.color = Color.black;
            }
            else
            {
                skillText.color = Color.red;
            }

            
        }
    }
    public bool UnlockCheck()
    {
        int currentLevel = GetCurrentLevel();
        bool LvelLock = currentLevel + 1 == buttonbright.myLevel || OxygenCounter.totalOxygen >= buttonbright.needOxygen;
        switch (skillType)
        {
            //case SkillType.SkillButton:
            //    return SkillUnlock.skillButtonLevel;
            case SkillType.RBCSpeed:
                return LvelLock && SkillUnlock.rbcAmountLevel >= 1;

            case SkillType.RBCHave:
                return LvelLock && SkillUnlock.rbcAmountLevel >= 1;

            case SkillType.WBCTime:
                return LvelLock && SkillUnlock.wbcAmountLevel >= 1;

            case SkillType.WBCRange:
                return LvelLock && SkillUnlock.wbcAmountLevel >= 1;

            case SkillType.PLTCure:
                return LvelLock && SkillUnlock.pltAmountLevel >= 1;

            case SkillType.RBCAmount:
                return LvelLock && SkillUnlock.skillButtonLevel >= 1;

            case SkillType.PLTAmount:
                return LvelLock && SkillUnlock.skillButtonLevel >= 1;

            case SkillType.WBCAmount:
                return LvelLock && SkillUnlock.skillButtonLevel >= 1;

            case SkillType.StageOx:
                return LvelLock && SkillUnlock.skillButtonLevel >= 1;

            case SkillType.StageTime:
                return LvelLock && SkillUnlock.skillButtonLevel >= 1;

            default:
                return LvelLock;
        }
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
    public void OnPointerExit(PointerEventData eventData)
    {
        //image.color = Color.gray7;
        if (descriptionUI != null)
        {
            descriptionUI.SetActive(false);
        }
    }
}
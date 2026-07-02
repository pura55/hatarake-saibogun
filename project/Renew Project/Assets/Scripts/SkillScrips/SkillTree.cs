using UnityEditor.SceneManagement;
using UnityEngine;
//íSìñÅ@êÁótåãâ¡
public class SkillTree : MonoBehaviour
{
    public StatusSkill status;
    public Timer timer;
    public SkillDetail skilldetail;
    public Buttonbright buttonBright;
    public int skillmax = 0;
    [SerializeField] private int needOxygen;
    public enum UpgradeType
    {
        SkillButton,
        RBCSpeedLv1,//ê‘ååãÖÉXÉsÅ[Éh
        RBCSpeedLv2,
        RBCSpeedLv3,
        RBCAmountLv1,//ê‘ååãÖêî
        RBCAmountLv2,
        RBCAmountLv3,
        RBCAmountLv4,
        RBCAmountLv5,
        RBCHaveLv1,//éùÇƒÇÈé_ëfêî
        RBCHaveLv2,
        RBCHaveLv3,
        WBCTimeLv1,//ó}Ç¶ÇÈéûä‘
        WBCTimeLv2,
        WBCTimeLv3,
        WBCRangeLv1,//ÉEÉCÉãÉXä¥ímîÕàÕ
        WBCRangeLv2,
        WBCRangeLv3,
        WBCAmountLv1,//îíååãÖêî
        WBCAmountLv2,
        WBCAmountLv3,
        WBCAmountLv4,
        WBCAmountLv5,
        PLTCureLv1,//âÒïúë¨ìx
        PLTCureLv2,
        PLTCureLv3,
        PLTAmountLv1,//ååè¨î¬êî
        PLTAmountLv2,
        PLTAmountLv3,
        PLTAmountLv4,
        PLTAmountLv5,
        StageOxLv1,//ÉXÉeÅ[ÉWÇÃé_ëfó 
        StageOxLv2,
        StageOxLv3,
        StageOxLv4,
        StageOxLv5,
        StageTimeLv1,//êßå¿éûä‘
        StageTimeLv2,
        StageTimeLv3,
        StageTimeLv4,
        StageTimeLv5
    }
    public void Upgrade()
    {

        switch (upgradeType)
        {
            case UpgradeType.SkillButton://É`ÉÖÅ[ÉgÉäÉAÉãópRBCHaveã≠âª
                if (status.rbcHave == 1 && OxygenCounter.totalOxygen >= needOxygen)
                {
                    OxygenCounter.totalOxygen -= needOxygen;
                    status.rbcHave = 2;
                    SkillUnlock.skillButtonLevel = 1;
                    Buttonbright[] buttons = FindObjectsByType<Buttonbright>(FindObjectsSortMode.None);
                    Debug.Log("SkillButton");
                    foreach (Buttonbright button in buttons)
                    {
                        button.RefreshButton();
                    }
                }
                else
                {
                    Debug.Log("é_ëfÇ™ë´ÇËÇ»Ç¢");
                }
                break;

            case UpgradeType.RBCSpeedLv1://ê‘ååãÖÉXÉsÅ[Éh
                if (status.rbcSpeed == 5f && OxygenCounter.totalOxygen >= needOxygen && status.rbcAmount==2 && SkillUnlock.rbcAmountLevel >= 1)
                {
                    OxygenCounter.totalOxygen -= needOxygen;     //é_ëfè¡îÔ
                    status.rbcSpeed = 5.2f;
                    SkillUnlock.rbcSpeedLevel = 1;
                    skilldetail.skillText.color = Color.black;
                    Buttonbright[] buttons = FindObjectsByType<Buttonbright>(FindObjectsSortMode.None);
                    Debug.Log("RBCSpeedLV1");
                    foreach (Buttonbright button in buttons)
                    {
                        button.RefreshButton();
                    }
                }
                else
                {
                    Debug.Log("é_ëfÇ™ë´ÇËÇ»Ç¢");
                }
                break;
            case UpgradeType.RBCSpeedLv2:
                if (status.rbcSpeed == 5.2f && OxygenCounter.totalOxygen >= needOxygen)
                {
                    OxygenCounter.totalOxygen -= needOxygen;
                    status.rbcSpeed = 5.5f;
                    SkillUnlock.rbcSpeedLevel = 2;
                    skilldetail.skillText.color = Color.black;
                    Buttonbright[] buttons = FindObjectsByType<Buttonbright>(FindObjectsSortMode.None);
                    Debug.Log("RBCSpeedLV2");
                    foreach (Buttonbright button in buttons)
                    {
                        button.RefreshButton();
                    }
                }
                else
                {
                    Debug.Log("é_ëfÇ™ë´ÇËÇ»Ç¢");
                }
                break;
            case UpgradeType.RBCSpeedLv3:
                if (status.rbcSpeed == 5.5f && OxygenCounter.totalOxygen >= needOxygen)
                {
                    OxygenCounter.totalOxygen -= needOxygen;
                    status.rbcSpeed = 5.75f;
                    SkillUnlock.rbcSpeedLevel = 3;
                    skilldetail.skillText.color = Color.black;
                    Buttonbright[] buttons = FindObjectsByType<Buttonbright>(FindObjectsSortMode.None);
                    Debug.Log("RBCSpeedLV3");
                    foreach (Buttonbright button in buttons)
                    {
                        button.RefreshButton();
                    }
                    ++skillmax;
                }
                else
                {
                    Debug.Log("é_ëfÇ™ë´ÇËÇ»Ç¢");
                }
                break;

            case UpgradeType.RBCAmountLv1://ê‘ååãÖêî
                if (status.rbcAmount == 1 && OxygenCounter.totalOxygen >= needOxygen)
                {
                    OxygenCounter.totalOxygen -= needOxygen;
                    status.rbcAmount = 2; 
                    SkillUnlock.rbcAmountLevel = 1;
                    skilldetail.skillText.color = Color.black;
                    Buttonbright[] buttons = FindObjectsByType<Buttonbright>(FindObjectsSortMode.None);
                    Debug.Log("RBCAmountLV1");
                    foreach (Buttonbright button in buttons)
                    {
                        button.RefreshButton();
                    }
                }
                else
                {
                    Debug.Log("é_ëfÇ™ë´ÇËÇ»Ç¢");
                }
                    break;
            case UpgradeType.RBCAmountLv2:
                if (status.rbcAmount == 2 && OxygenCounter.totalOxygen >= needOxygen)
                {
                    OxygenCounter.totalOxygen -= needOxygen;
                    status.rbcAmount = 3;
                    SkillUnlock.rbcAmountLevel = 2;
                    skilldetail.skillText.color = Color.black;
                    Buttonbright[] buttons = FindObjectsByType<Buttonbright>(FindObjectsSortMode.None);
                    Debug.Log("RBCAmountLV2");
                    foreach (Buttonbright button in buttons)
                    {
                        button.RefreshButton();
                    }
                }
                else
                {
                    Debug.Log("é_ëfÇ™ë´ÇËÇ»Ç¢");
                }
                break;
            case UpgradeType.RBCAmountLv3:
                if (status.rbcAmount == 3 && OxygenCounter.totalOxygen >= needOxygen)
                {
                    OxygenCounter.totalOxygen -= needOxygen;
                    status.rbcAmount = 5;
                    SkillUnlock.rbcAmountLevel = 3;
                    skilldetail.skillText.color = Color.black;
                    Buttonbright[] buttons = FindObjectsByType<Buttonbright>(FindObjectsSortMode.None);
                    Debug.Log("RBCAmountLV3");
                    foreach (Buttonbright button in buttons)
                    {
                        button.RefreshButton();
                    }
                }
                else
                {
                    Debug.Log("é_ëfÇ™ë´ÇËÇ»Ç¢");
                }
                break;
            case UpgradeType.RBCAmountLv4:
                if (status.rbcAmount == 5 && OxygenCounter.totalOxygen >= needOxygen)
                {
                    OxygenCounter.totalOxygen -= needOxygen;
                    status.rbcAmount = 7;
                    SkillUnlock.rbcAmountLevel = 4;
                    skilldetail.skillText.color = Color.black;
                    Buttonbright[] buttons = FindObjectsByType<Buttonbright>(FindObjectsSortMode.None);
                    Debug.Log("RBCAmountLV4");
                    foreach (Buttonbright button in buttons)
                    {
                        button.RefreshButton();
                    }
                }
                else
                {
                    Debug.Log("é_ëfÇ™ë´ÇËÇ»Ç¢");
                }
                break;
            case UpgradeType.RBCAmountLv5:
                if (status.rbcAmount == 7 && OxygenCounter.totalOxygen >= needOxygen)
                {
                    OxygenCounter.totalOxygen -= needOxygen;
                    status.rbcAmount = 10;
                    SkillUnlock.rbcAmountLevel = 5;
                    skilldetail.skillText.color = Color.black;
                    Buttonbright[] buttons = FindObjectsByType<Buttonbright>(FindObjectsSortMode.None);
                    Debug.Log("RBCAmountLV5");
                    foreach (Buttonbright button in buttons)
                    {
                        button.RefreshButton();
                    }
                    ++skillmax;
                }
                else
                {
                    Debug.Log("é_ëfÇ™ë´ÇËÇ»Ç¢");
                }
                break;

            case UpgradeType.RBCHaveLv1://éùÇƒÇÈé_ëfêî
                if (status.rbcHave == 2 && OxygenCounter.totalOxygen >= needOxygen && status.rbcAmount == 2 && SkillUnlock.rbcAmountLevel >= 1)
                {
                    OxygenCounter.totalOxygen -= needOxygen;
                    status.rbcHave = 3;
                    SkillUnlock.rbcHaveLevel = 1;
                    skilldetail.skillText.color = Color.black;
                    Buttonbright[] buttons = FindObjectsByType<Buttonbright>(FindObjectsSortMode.None);
                    Debug.Log("RBCHaveLV1");
                    foreach (Buttonbright button in buttons)
                    {
                        button.RefreshButton();
                    }
                }
                else
                {
                    Debug.Log("é_ëfÇ™ë´ÇËÇ»Ç¢");
                }
                break;
            case UpgradeType.RBCHaveLv2:
                if (status.rbcHave == 3 && OxygenCounter.totalOxygen >= needOxygen)
                {
                    OxygenCounter.totalOxygen -= needOxygen;
                    status.rbcHave = 4;
                    SkillUnlock.rbcHaveLevel = 2;
                    skilldetail.skillText.color = Color.black;
                    Buttonbright[] buttons = FindObjectsByType<Buttonbright>(FindObjectsSortMode.None);
                    Debug.Log("RBCHaveLV2");
                    foreach (Buttonbright button in buttons)
                    {
                        button.RefreshButton();
                    }
                }
                else
                {
                    Debug.Log("é_ëfÇ™ë´ÇËÇ»Ç¢");
                }
                break;
            case UpgradeType.RBCHaveLv3:
                if (status.rbcHave == 4 && OxygenCounter.totalOxygen >= needOxygen)
                {
                    OxygenCounter.totalOxygen -= needOxygen;
                    status.rbcHave = 5;
                    SkillUnlock.rbcHaveLevel = 3;
                    skilldetail.skillText.color = Color.black;
                    Buttonbright[] buttons = FindObjectsByType<Buttonbright>(FindObjectsSortMode.None);
                    Debug.Log("RBCHaveLV3");
                    foreach (Buttonbright button in buttons)
                    {
                        button.RefreshButton();
                    }
                    ++skillmax;
                }
                else
                {
                    Debug.Log("é_ëfÇ™ë´ÇËÇ»Ç¢");
                }
                break;

            case UpgradeType.WBCTimeLv1://ó}Ç¶ÇÈéûä‘
                if (status.wbcTime == 2.0f && OxygenCounter.totalOxygen >= needOxygen && status.wbcAmount == 3 && SkillUnlock.wbcAmountLevel >= 1)
                {
                    OxygenCounter.totalOxygen -= needOxygen;
                    status.wbcTime = 2.4f; 
                    SkillUnlock.wbcTimeLevel = 1;
                    skilldetail.skillText.color = Color.black;
                    Buttonbright[] buttons = FindObjectsByType<Buttonbright>(FindObjectsSortMode.None);
                    Debug.Log("WBCTimeLV1");
                    foreach (Buttonbright button in buttons)
                    {
                        button.RefreshButton();
                    }
                }
                else
                {
                    Debug.Log("é_ëfÇ™ë´ÇËÇ»Ç¢");
                }
                break;
            case UpgradeType.WBCTimeLv2:
                if (status.wbcTime == 2.4f && OxygenCounter.totalOxygen >= needOxygen)
                {
                    OxygenCounter.totalOxygen -= needOxygen;
                    status.wbcTime = 3.0f;
                    SkillUnlock.wbcTimeLevel = 2;
                    skilldetail.skillText.color = Color.black;
                    Buttonbright[] buttons = FindObjectsByType<Buttonbright>(FindObjectsSortMode.None);
                    Debug.Log("WBCTimeLV2");
                    foreach (Buttonbright button in buttons)
                    {
                        button.RefreshButton();
                    }
                }
                else
                {
                    Debug.Log("é_ëfÇ™ë´ÇËÇ»Ç¢");
                }
                break;
            case UpgradeType.WBCTimeLv3:
                if (status.wbcTime == 3.0f && OxygenCounter.totalOxygen >= needOxygen)
                {
                    OxygenCounter.totalOxygen -= needOxygen;
                    status.wbcTime = 4.0f;
                    SkillUnlock.wbcTimeLevel = 3;
                    skilldetail.skillText.color = Color.black;
                    Buttonbright[] buttons = FindObjectsByType<Buttonbright>(FindObjectsSortMode.None);
                    Debug.Log("WBCTimeLV3");
                    foreach (Buttonbright button in buttons)
                    {
                        button.RefreshButton();
                    }
                    ++skillmax;
                }
                else
                {
                    Debug.Log("é_ëfÇ™ë´ÇËÇ»Ç¢");
                }
                break;
                
            case UpgradeType.WBCRangeLv1://ÉEÉCÉãÉXä¥ímîÕàÕ
                if (status.wbcRange == 0.5f && OxygenCounter.totalOxygen >= needOxygen && status.wbcAmount == 3 && SkillUnlock.rbcAmountLevel >= 1)
                {
                    OxygenCounter.totalOxygen -= needOxygen;
                    status.wbcRange = 0.6f;
                    SkillUnlock.wbcRangeLevel = 1;
                    skilldetail.skillText.color = Color.black;
                    Buttonbright[] buttons = FindObjectsByType<Buttonbright>(FindObjectsSortMode.None);
                    Debug.Log("WBCRangeLV1");
                    foreach (Buttonbright button in buttons)
                    {
                        button.RefreshButton();
                    }
                }
                else
                {
                    Debug.Log("é_ëfÇ™ë´ÇËÇ»Ç¢");
                }
                break;
            case UpgradeType.WBCRangeLv2:
                if (status.wbcRange == 0.6f && OxygenCounter.totalOxygen >= needOxygen)
                {
                    OxygenCounter.totalOxygen -= needOxygen;
                    status.wbcRange = 0.65f;
                    SkillUnlock.wbcRangeLevel = 2;
                    skilldetail.skillText.color = Color.black;
                    Buttonbright[] buttons = FindObjectsByType<Buttonbright>(FindObjectsSortMode.None);
                    Debug.Log("WBCRangeLV2");
                    foreach (Buttonbright button in buttons)
                    {
                        button.RefreshButton();
                    }
                }
                else
                {
                    Debug.Log("é_ëfÇ™ë´ÇËÇ»Ç¢");
                }
        break;
            case UpgradeType.WBCRangeLv3:
                if (status.wbcRange == 0.65f && OxygenCounter.totalOxygen >= needOxygen)
                {
                    OxygenCounter.totalOxygen -= needOxygen;
                    status.wbcRange = 0.75f;
                    SkillUnlock.wbcRangeLevel = 3;
                    skilldetail.skillText.color = Color.black;
                    Buttonbright[] buttons = FindObjectsByType<Buttonbright>(FindObjectsSortMode.None);
                    Debug.Log("WBCRangeLV3");
                    foreach (Buttonbright button in buttons)
                    {
                        button.RefreshButton();
                    }
                    ++skillmax;
                }
                else
                {
                    Debug.Log("é_ëfÇ™ë´ÇËÇ»Ç¢");
                }
                break;
                
            case UpgradeType.WBCAmountLv1://îíååãÖêî
                if (status.wbcAmount == 0 && OxygenCounter.totalOxygen >= needOxygen)
                {
                    OxygenCounter.totalOxygen -= needOxygen;
                    status.wbcAmount = 3;
                    SkillUnlock.wbcAmountLevel = 1;
                    skilldetail.skillText.color = Color.black;
                    Buttonbright[] buttons = FindObjectsByType<Buttonbright>(FindObjectsSortMode.None);
                    Debug.Log("WBCAmountLV1");
                    foreach (Buttonbright button in buttons)
                    {
                        button.RefreshButton();
                    }
                }
                else
                {
                    Debug.Log("é_ëfÇ™ë´ÇËÇ»Ç¢");
                }
                break;
            case UpgradeType.WBCAmountLv2:
                if (status.wbcAmount == 3 && OxygenCounter.totalOxygen >= needOxygen)
                {
                    OxygenCounter.totalOxygen -= needOxygen;
                    status.wbcAmount = 8;
                    SkillUnlock.wbcAmountLevel = 2;
                    skilldetail.skillText.color = Color.black;
                    Buttonbright[] buttons = FindObjectsByType<Buttonbright>(FindObjectsSortMode.None);
                    Debug.Log("WBCAmountLV2");
                    foreach (Buttonbright button in buttons)
                    {
                        button.RefreshButton();
                    }
                }
                else
                {
                    Debug.Log("é_ëfÇ™ë´ÇËÇ»Ç¢");
                }
                break;
            case UpgradeType.WBCAmountLv3:
                if (status.wbcAmount == 8 && OxygenCounter.totalOxygen >= needOxygen)
                {
                    OxygenCounter.totalOxygen -= needOxygen;
                    status.wbcAmount = 15;
                    SkillUnlock.wbcAmountLevel = 3;
                    skilldetail.skillText.color = Color.black;
                    Buttonbright[] buttons = FindObjectsByType<Buttonbright>(FindObjectsSortMode.None);
                    Debug.Log("WBCAmountLV3");
                    foreach (Buttonbright button in buttons)
                    {
                        button.RefreshButton();
                    }
                }
                else
                {
                    Debug.Log("é_ëfÇ™ë´ÇËÇ»Ç¢");
                }
                break;
            case UpgradeType.WBCAmountLv4:
                if (status.wbcAmount == 15 && OxygenCounter.totalOxygen >= needOxygen)
                {
                    OxygenCounter.totalOxygen -= needOxygen;
                    status.wbcAmount = 30;
                    SkillUnlock.wbcAmountLevel = 4;
                    skilldetail.skillText.color = Color.black;
                    Buttonbright[] buttons = FindObjectsByType<Buttonbright>(FindObjectsSortMode.None);
                    Debug.Log("WBCAmountLV4");
                    foreach (Buttonbright button in buttons)
                    {
                        button.RefreshButton();
                    }
                }
                else
                {
                    Debug.Log("é_ëfÇ™ë´ÇËÇ»Ç¢");
                }
                break;
            case UpgradeType.WBCAmountLv5:
                if (status.wbcAmount == 30 && OxygenCounter.totalOxygen >= needOxygen)
                {
                    OxygenCounter.totalOxygen -= needOxygen;
                    status.wbcAmount = 45;
                    SkillUnlock.wbcAmountLevel = 5;
                    skilldetail.skillText.color = Color.black;
                    Buttonbright[] buttons = FindObjectsByType<Buttonbright>(FindObjectsSortMode.None);
                    Debug.Log("WBCAmountLV5");
                    foreach (Buttonbright button in buttons)
                    {
                        button.RefreshButton();
                    }
                    ++skillmax;
                }
                else
                {
                    Debug.Log("é_ëfÇ™ë´ÇËÇ»Ç¢");
                }
                break;

            case UpgradeType.PLTCureLv1://âÒïúë¨ìx
                if (status.pltCure == 1.0f && OxygenCounter.totalOxygen >= needOxygen && status.pltAmount ==10)
                {
                    OxygenCounter.totalOxygen -= needOxygen;
                    status.pltCure = 1.2f;
                    SkillUnlock.pltCureLevel = 1;
                    skilldetail.skillText.color = Color.black;
                    Buttonbright[] buttons = FindObjectsByType<Buttonbright>(FindObjectsSortMode.None);
                    Debug.Log("PLTCureLV1");
                    foreach (Buttonbright button in buttons)
                    {
                        button.RefreshButton();
                    }
                }
                else
                {
                    Debug.Log("é_ëfÇ™ë´ÇËÇ»Ç¢");
                }
                break;
            case UpgradeType.PLTCureLv2:
                if (status.pltCure == 1.2f && OxygenCounter.totalOxygen >= needOxygen)
                {
                    OxygenCounter.totalOxygen -= needOxygen;
                    status.pltCure = 1.5f;
                    SkillUnlock.pltCureLevel = 2;
                    skilldetail.skillText.color = Color.black;
                    Buttonbright[] buttons = FindObjectsByType<Buttonbright>(FindObjectsSortMode.None);
                    Debug.Log("PLTCureLV2");
                    foreach (Buttonbright button in buttons)
                    {
                        button.RefreshButton();
                    }
                }
                else
                {
                    Debug.Log("é_ëfÇ™ë´ÇËÇ»Ç¢");
                }
                break;
            case UpgradeType.PLTCureLv3:
                if (status.pltCure == 1.5f && OxygenCounter.totalOxygen >= needOxygen)
                {
                    OxygenCounter.totalOxygen -= needOxygen;
                    status.pltCure = 1.8f;
                    SkillUnlock.pltCureLevel = 3;
                    skilldetail.skillText.color = Color.black;
                    Buttonbright[] buttons = FindObjectsByType<Buttonbright>(FindObjectsSortMode.None);
                    Debug.Log("PLTCureLV3");
                    foreach (Buttonbright button in buttons)
                    {
                        button.RefreshButton();
                    }
                    ++skillmax;
                }
                else
                {
                    Debug.Log("é_ëfÇ™ë´ÇËÇ»Ç¢");
                }
                break;

            case UpgradeType.PLTAmountLv1://ååè¨î¬êî
                if (status.pltAmount == 0 && OxygenCounter.totalOxygen >= needOxygen)
                {
                    OxygenCounter.totalOxygen -= needOxygen;
                    status.pltAmount = 10;
                    SkillUnlock.pltAmountLevel = 1;
                    skilldetail.skillText.color = Color.black;
                    Buttonbright[] buttons = FindObjectsByType<Buttonbright>(FindObjectsSortMode.None);
                    Debug.Log("PLTAmountLV1");
                    foreach (Buttonbright button in buttons)
                    {
                        button.RefreshButton();
                    }
                }
                else
                {
                    Debug.Log("é_ëfÇ™ë´ÇËÇ»Ç¢");
                }
                break;
            case UpgradeType.PLTAmountLv2:
                if (status.pltAmount == 10 && OxygenCounter.totalOxygen >= needOxygen)
                {
                    OxygenCounter.totalOxygen -= needOxygen;
                    status.pltAmount = 18;
                    SkillUnlock.pltAmountLevel = 2;
                    skilldetail.skillText.color = Color.black;
                    Buttonbright[] buttons = FindObjectsByType<Buttonbright>(FindObjectsSortMode.None);
                    Debug.Log("PLTAmountLV2");
                    foreach (Buttonbright button in buttons)
                    {
                        button.RefreshButton();
                    }
                }
                else
                {
                    Debug.Log("é_ëfÇ™ë´ÇËÇ»Ç¢");
                }
                break;
            case UpgradeType.PLTAmountLv3:
                if (status.pltAmount == 18 && OxygenCounter.totalOxygen >= needOxygen)
                {
                    OxygenCounter.totalOxygen -= needOxygen;
                    status.pltAmount = 25;
                    SkillUnlock.pltAmountLevel = 3;
                    skilldetail.skillText.color = Color.black;
                    Buttonbright[] buttons = FindObjectsByType<Buttonbright>(FindObjectsSortMode.None);
                    Debug.Log("PLTAmountLV3");
                    foreach (Buttonbright button in buttons)
                    {
                        button.RefreshButton();
                    }
                }
                else
                {
                    Debug.Log("é_ëfÇ™ë´ÇËÇ»Ç¢");
                }
                break;
            case UpgradeType.PLTAmountLv4:
                if (status.pltAmount == 25 && OxygenCounter.totalOxygen >= needOxygen)
                {
                    OxygenCounter.totalOxygen -= needOxygen;
                    status.pltAmount = 40;
                    SkillUnlock.pltAmountLevel = 4;
                    skilldetail.skillText.color = Color.black;
                    Buttonbright[] buttons = FindObjectsByType<Buttonbright>(FindObjectsSortMode.None);
                    Debug.Log("PLTAmountLV4");
                    foreach (Buttonbright button in buttons)
                    {
                        button.RefreshButton();
                    }
                }
                else
                {
                    Debug.Log("é_ëfÇ™ë´ÇËÇ»Ç¢");
                }
                break;
            case UpgradeType.PLTAmountLv5:
                if (status.pltAmount == 40 && OxygenCounter.totalOxygen >= needOxygen)
                {
                    OxygenCounter.totalOxygen -= needOxygen;
                    status.pltAmount = 60;
                    SkillUnlock.pltAmountLevel = 5;
                    skilldetail.skillText.color = Color.black;
                    Buttonbright[] buttons = FindObjectsByType<Buttonbright>(FindObjectsSortMode.None);
                    Debug.Log("PLTAmountLV5");
                    foreach (Buttonbright button in buttons)
                    {
                        button.RefreshButton();
                    }
                    ++skillmax;
                }
                else
                {
                    Debug.Log("é_ëfÇ™ë´ÇËÇ»Ç¢");
                }
                break;
                
            case UpgradeType.StageOxLv1://ÉXÉeÅ[ÉWÇÃé_ëfó 
                if (status.stageOx == 30 && OxygenCounter.totalOxygen >= needOxygen)
                {
                    OxygenCounter.totalOxygen -= needOxygen;
                    status.stageOx = 35;
                    SkillUnlock.stageOxLevel = 1;
                    skilldetail.skillText.color = Color.black;
                    Buttonbright[] buttons = FindObjectsByType<Buttonbright>(FindObjectsSortMode.None);
                    Debug.Log("StageOxLV1");
                    foreach (Buttonbright button in buttons)
                    {
                        button.RefreshButton();
                    }
                }
                else
                {
                    Debug.Log("é_ëfÇ™ë´ÇËÇ»Ç¢");
                }
                break;
            case UpgradeType.StageOxLv2:
                if (status.stageOx == 35 && OxygenCounter.totalOxygen >= needOxygen)
                {
                    OxygenCounter.totalOxygen -= needOxygen;
                    status.stageOx = 48;
                    SkillUnlock.stageOxLevel = 2;
                    skilldetail.skillText.color = Color.black;
                    Buttonbright[] buttons = FindObjectsByType<Buttonbright>(FindObjectsSortMode.None);
                    Debug.Log("StageOxLV2");
                    foreach (Buttonbright button in buttons)
                    {
                        button.RefreshButton();
                    }
                }
                else
                {
                    Debug.Log("é_ëfÇ™ë´ÇËÇ»Ç¢");
                }
                break;
            case UpgradeType.StageOxLv3:
                if (status.stageOx == 48 && OxygenCounter.totalOxygen >= needOxygen)
                {
                    OxygenCounter.totalOxygen -= needOxygen;
                    status.stageOx = 60;
                    SkillUnlock.stageOxLevel = 3;
                    skilldetail.skillText.color = Color.black;
                    Buttonbright[] buttons = FindObjectsByType<Buttonbright>(FindObjectsSortMode.None);
                    Debug.Log("StageOxLV3");
                    foreach (Buttonbright button in buttons)
                    {
                        button.RefreshButton();
                    }
                }
                else
                {
                    Debug.Log("é_ëfÇ™ë´ÇËÇ»Ç¢");
                }
                break;
            case UpgradeType.StageOxLv4:
                if (status.stageOx == 60 && OxygenCounter.totalOxygen >= needOxygen)
                {
                    OxygenCounter.totalOxygen -= needOxygen;
                    status.stageOx = 75;
                    SkillUnlock.stageOxLevel = 4;
                    skilldetail.skillText.color = Color.black;
                    Buttonbright[] buttons = FindObjectsByType<Buttonbright>(FindObjectsSortMode.None);
                    Debug.Log("StageOxLV4");
                    foreach (Buttonbright button in buttons)
                    {
                        button.RefreshButton();
                    }
                }
                else
                {
                    Debug.Log("é_ëfÇ™ë´ÇËÇ»Ç¢");
                }
                break;
            case UpgradeType.StageOxLv5:
                if (status.stageOx == 75 && OxygenCounter.totalOxygen >= needOxygen)
                {
                    OxygenCounter.totalOxygen -= needOxygen;
                    status.stageOx = 100;
                    SkillUnlock.stageOxLevel = 5;
                    skilldetail.skillText.color = Color.black;
                    Buttonbright[] buttons = FindObjectsByType<Buttonbright>(FindObjectsSortMode.None);
                    Debug.Log("StageOxLV5");
                    foreach (Buttonbright button in buttons)
                    {
                        button.RefreshButton();
                    }
                    ++skillmax;
                }
                else
                {
                    Debug.Log("é_ëfÇ™ë´ÇËÇ»Ç¢");
                }
                break;
                
            case UpgradeType.StageTimeLv1://êßå¿éûä‘
                if (status.stageTime == 10 && OxygenCounter.totalOxygen >= needOxygen)
                {
                    OxygenCounter.totalOxygen -= needOxygen;
                    status.stageTime = 11;
                    //timer.timeRemaining = status.stageTime;
                    SkillUnlock.stageTimeLevel = 1;
                    skilldetail.skillText.color = Color.black;
                    Buttonbright[] buttons = FindObjectsByType<Buttonbright>(FindObjectsSortMode.None);
                    Debug.Log("StageTimeLV1");
                    foreach (Buttonbright button in buttons)
                    {
                        button.RefreshButton();
                    }
                }
                else
                {
                    Debug.Log("é_ëfÇ™ë´ÇËÇ»Ç¢");
                }
                break;
            case UpgradeType.StageTimeLv2:
                if (status.stageTime == 11 && OxygenCounter.totalOxygen >= needOxygen)
                {
                    OxygenCounter.totalOxygen -= needOxygen;
                    status.stageTime = 13;
                    //timer.timeRemaining = status.stageTime;
                    SkillUnlock.stageTimeLevel = 2;
                    skilldetail.skillText.color = Color.black;
                    Buttonbright[] buttons = FindObjectsByType<Buttonbright>(FindObjectsSortMode.None);
                    Debug.Log("StageTimeLV2");
                    foreach (Buttonbright button in buttons)
                    {
                        button.RefreshButton();
                    }
                }
                else
                {
                    Debug.Log("é_ëfÇ™ë´ÇËÇ»Ç¢");
                }
                break;
            case UpgradeType.StageTimeLv3:
                if (status.stageTime == 13 && OxygenCounter.totalOxygen >= needOxygen)
                {
                    OxygenCounter.totalOxygen -= needOxygen;
                    status.stageTime = 15;
                    //timer.timeRemaining = status.stageTime;
                    SkillUnlock.stageTimeLevel = 3;
                    skilldetail.skillText.color = Color.black;
                    Buttonbright[] buttons = FindObjectsByType<Buttonbright>(FindObjectsSortMode.None);
                    Debug.Log("StageTimeLV3");
                    foreach (Buttonbright button in buttons)
                    {
                        button.RefreshButton();
                    }
                }
                else
                {
                    Debug.Log("é_ëfÇ™ë´ÇËÇ»Ç¢");
                }
                break;
            case UpgradeType.StageTimeLv4:
                if (status.stageTime == 15 && OxygenCounter.totalOxygen >= needOxygen)
                {
                    OxygenCounter.totalOxygen -= needOxygen;
                    status.stageTime = 18;
                    //timer.timeRemaining = status.stageTime;
                    SkillUnlock.stageTimeLevel = 4;
                    skilldetail.skillText.color = Color.black;
                    Buttonbright[] buttons = FindObjectsByType<Buttonbright>(FindObjectsSortMode.None);
                    Debug.Log("StageTimeLV4");
                    foreach (Buttonbright button in buttons)
                    {
                        button.RefreshButton();
                    }
                }
                else
                {
                    Debug.Log("é_ëfÇ™ë´ÇËÇ»Ç¢");
                }
                break;
            case UpgradeType.StageTimeLv5:
                if (status.stageTime == 18 && OxygenCounter.totalOxygen >= needOxygen)
                {
                    OxygenCounter.totalOxygen -= needOxygen;
                    status.stageTime = 22;
                    //timer.timeRemaining = status.stageTime;
                    SkillUnlock.stageTimeLevel = 5;
                    skilldetail.skillText.color = Color.black;
                    Buttonbright[] buttons = FindObjectsByType<Buttonbright>(FindObjectsSortMode.None);
                    Debug.Log("StageTimeLV5");
                    foreach (Buttonbright button in buttons)
                    {
                        button.RefreshButton();
                    }
                    ++skillmax;
                }
                else
                {
                    Debug.Log("é_ëfÇ™ë´ÇËÇ»Ç¢");
                }
                break;
        }


    }

    public UpgradeType upgradeType;
}
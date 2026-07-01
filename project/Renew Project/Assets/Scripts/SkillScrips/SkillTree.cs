using UnityEditor.SceneManagement;
using UnityEngine;
//’S“–@ç—tŒ‹‰Á
public class SkillTree : MonoBehaviour
{
    public StatusSkill status;
    public Timer timer;
    public Buttonbright buttonBright;
    public int skillmax = 0;//10‚É‚È‚Á‚½‚çƒXƒLƒ‹‘SŠJ•úÏ‚Ý
    public enum UpgradeType
    {
        RBCSpeedLv1,//ÔŒŒ‹…ƒXƒs[ƒh
        RBCSpeedLv2,
        RBCSpeedLv3,
        RBCAmountLv1,//ÔŒŒ‹…”
        RBCAmountLv2,
        RBCAmountLv3,
        RBCAmountLv4,
        RBCAmountLv5,
        RBCHaveLv1,//Ž‚Ä‚éŽ_‘f”
        RBCHaveLv2,
        RBCHaveLv3,
        WBCTimeLv1,//—}‚¦‚éŽžŠÔ
        WBCTimeLv2,
        WBCTimeLv3,
        WBCRangeLv1,//ƒEƒCƒ‹ƒXŠ´’m”ÍˆÍ
        WBCRangeLv2,
        WBCRangeLv3,
        WBCAmountLv1,//”’ŒŒ‹…”
        WBCAmountLv2,
        WBCAmountLv3,
        WBCAmountLv4,
        WBCAmountLv5,
        PLTCureLv1,//‰ñ•œ‘¬“x
        PLTCureLv2,
        PLTCureLv3,
        PLTAmountLv1,//ŒŒ¬”Â”
        PLTAmountLv2,
        PLTAmountLv3,
        PLTAmountLv4,
        PLTAmountLv5,
        StageOxLv1,//ƒXƒe[ƒW‚ÌŽ_‘f—Ê
        StageOxLv2,
        StageOxLv3,
        StageOxLv4,
        StageOxLv5,
        StageTimeLv1,//§ŒÀŽžŠÔ
        StageTimeLv2,
        StageTimeLv3,
        StageTimeLv4,
        StageTimeLv5
    }
    public void Upgrade()
    {

        switch (upgradeType)
        {
            case UpgradeType.RBCSpeedLv1://ÔŒŒ‹…ƒXƒs[ƒh
                if (status.rbcSpeed == 5f && OxygenCounter.totalOxygen >= 10)
                {
                    OxygenCounter.totalOxygen -= 10;     //Ž_‘fÁ”ï
                    status.rbcSpeed = 5.2f;
                    SkillUnlock.rbcSpeedLevel = 1;
                    buttonBright.RefreshButton();
                    Debug.Log("RBCSpeedLV1");
                }
                else
                {
                    Debug.Log("Ž_‘f‚ª‘«‚è‚È‚¢");
                }
                break;
            case UpgradeType.RBCSpeedLv2:
                if (status.rbcSpeed == 5.2f && OxygenCounter.totalOxygen >= 25)
                {
                    OxygenCounter.totalOxygen -= 25;
                    status.rbcSpeed = 5.5f;
                    SkillUnlock.rbcSpeedLevel = 2;
                    buttonBright.RefreshButton();
                    Debug.Log("RBCSpeedLV2");
                }
                else
                {
                    Debug.Log("Ž_‘f‚ª‘«‚è‚È‚¢");
                }
                break;
            case UpgradeType.RBCSpeedLv3:
                if (status.rbcSpeed == 5.5f && OxygenCounter.totalOxygen >= 50)
                {
                    OxygenCounter.totalOxygen -= 50;
                    status.rbcSpeed = 5.75f;
                    SkillUnlock.rbcSpeedLevel = 3;
                    buttonBright.RefreshButton();
                    Debug.Log("RBCSpeedLV3");
                    ++skillmax;
                }
                else
                {
                    Debug.Log("Ž_‘f‚ª‘«‚è‚È‚¢");
                }
                break;

            case UpgradeType.RBCAmountLv1://ÔŒŒ‹…”
                if (status.rbcAmount == 1 && OxygenCounter.totalOxygen >= 20)
                {
                    OxygenCounter.totalOxygen -= 20;
                    status.rbcAmount = 2; 
                    SkillUnlock.rbcAmountLevel = 1;
                    buttonBright.RefreshButton();
                    Debug.Log("RBCAmountLV1");
                }
                else
                {
                    Debug.Log("Ž_‘f‚ª‘«‚è‚È‚¢");
                }
                    break;
            case UpgradeType.RBCAmountLv2:
                if (status.rbcAmount == 2 && OxygenCounter.totalOxygen >= 35)
                {
                    OxygenCounter.totalOxygen -= 35;
                    status.rbcAmount = 3;
                    SkillUnlock.rbcAmountLevel = 2;
                    buttonBright.RefreshButton();
                    Debug.Log("RBCAmountLV2");
                }
                else
                {
                    Debug.Log("Ž_‘f‚ª‘«‚è‚È‚¢");
                }
                break;
            case UpgradeType.RBCAmountLv3:
                if (status.rbcAmount == 3 && OxygenCounter.totalOxygen >= 60)
                {
                    OxygenCounter.totalOxygen -= 60;
                    status.rbcAmount = 5;
                    SkillUnlock.rbcAmountLevel = 3;
                    buttonBright.RefreshButton();
                    Debug.Log("RBCAmountLV3");
                }
                else
                {
                    Debug.Log("Ž_‘f‚ª‘«‚è‚È‚¢");
                }
                break;
            case UpgradeType.RBCAmountLv4:
                if (status.rbcAmount == 5 && OxygenCounter.totalOxygen >= 85)
                {
                    OxygenCounter.totalOxygen -= 85;
                    status.rbcAmount = 7;
                    SkillUnlock.rbcAmountLevel = 4;
                    buttonBright.RefreshButton();
                    Debug.Log("RBCAmountLV4");
                }
                else
                {
                    Debug.Log("Ž_‘f‚ª‘«‚è‚È‚¢");
                }
                break;
            case UpgradeType.RBCAmountLv5:
                if (status.rbcAmount == 7 && OxygenCounter.totalOxygen >= 120)
                {
                    OxygenCounter.totalOxygen -= 120;
                    status.rbcAmount = 10;
                    SkillUnlock.rbcAmountLevel = 5;
                    buttonBright.RefreshButton();
                    Debug.Log("RBCAmountLV5");
                    ++skillmax;
                }
                else
                {
                    Debug.Log("Ž_‘f‚ª‘«‚è‚È‚¢");
                }
                break;

            case UpgradeType.RBCHaveLv1://Ž‚Ä‚éŽ_‘f”
                if (status.rbcHave == 1 && OxygenCounter.totalOxygen >= 10)
                {
                    OxygenCounter.totalOxygen -= 10;
                    status.rbcHave = 2;
                    SkillUnlock.rbcHaveLevel = 1;
                    buttonBright.RefreshButton();
                    Debug.Log("RBCHaveLV1");
                }
                else
                {
                    Debug.Log("Ž_‘f‚ª‘«‚è‚È‚¢");
                }
                break;
            case UpgradeType.RBCHaveLv2:
                if (status.rbcHave == 2 && OxygenCounter.totalOxygen >= 20)
                {
                    OxygenCounter.totalOxygen -= 20;
                    status.rbcHave = 3;
                    SkillUnlock.rbcHaveLevel = 2;
                    buttonBright.RefreshButton();
                    Debug.Log("RBCHaveLV2");
                }
                else
                {
                    Debug.Log("Ž_‘f‚ª‘«‚è‚È‚¢");
                }
                break;
            case UpgradeType.RBCHaveLv3:
                if (status.rbcHave == 3 && OxygenCounter.totalOxygen >= 50)
                {
                    OxygenCounter.totalOxygen -= 50;
                    status.rbcHave = 5;
                    SkillUnlock.rbcHaveLevel = 3;
                    buttonBright.RefreshButton();
                    Debug.Log("RBCHaveLV3");
                    ++skillmax;
                }
                else
                {
                    Debug.Log("Ž_‘f‚ª‘«‚è‚È‚¢");
                }
                break;

            case UpgradeType.WBCTimeLv1://—}‚¦‚éŽžŠÔ
                if (status.wbcTime == 2.0f && OxygenCounter.totalOxygen >= 10)
                {
                    OxygenCounter.totalOxygen -= 10;
                    status.wbcTime = 2.4f; 
                    SkillUnlock.wbcTimeLevel = 1;
                    buttonBright.RefreshButton();
                    Debug.Log("WBCTimeLV1");
                }
                else
                {
                    Debug.Log("Ž_‘f‚ª‘«‚è‚È‚¢");
                }
                break;
            case UpgradeType.WBCTimeLv2:
                if (status.wbcTime == 2.4f && OxygenCounter.totalOxygen >= 25)
                {
                    OxygenCounter.totalOxygen -= 25;
                    status.wbcTime = 3.0f;
                    SkillUnlock.wbcTimeLevel = 2;
                    buttonBright.RefreshButton();
                    Debug.Log("WBCTimeLV2");
                }
                else
                {
                    Debug.Log("Ž_‘f‚ª‘«‚è‚È‚¢");
                }
                break;
            case UpgradeType.WBCTimeLv3:
                if (status.wbcTime == 3.0f && OxygenCounter.totalOxygen >= 50)
                {
                    OxygenCounter.totalOxygen -= 50;
                    status.wbcTime = 4.0f;
                    SkillUnlock.wbcTimeLevel = 3;
                    buttonBright.RefreshButton();
                    Debug.Log("WBCTimeLV3");
                    ++skillmax;
                }
                else
                {
                    Debug.Log("Ž_‘f‚ª‘«‚è‚È‚¢");
                }
                break;
                //‚Ü‚¾
            case UpgradeType.WBCRangeLv1://ƒEƒCƒ‹ƒXŠ´’m”ÍˆÍ
                if (status.wbcRange == 1.0f && OxygenCounter.totalOxygen >= 10)
                {
                    OxygenCounter.totalOxygen -= 10;
                    status.wbcRange = 1.2f;
                    SkillUnlock.wbcRangeLevel = 1;
                    buttonBright.RefreshButton();
                    Debug.Log("WBCRangeLV1");
                }
                else
                {
                    Debug.Log("Ž_‘f‚ª‘«‚è‚È‚¢");
                }
                break;
            case UpgradeType.WBCRangeLv2:
                if (status.wbcRange == 1.2f && OxygenCounter.totalOxygen >= 25)
                {
                    OxygenCounter.totalOxygen -= 25;
                    status.wbcRange = 1.5f;
                    SkillUnlock.wbcRangeLevel = 2;
                    buttonBright.RefreshButton();
                    Debug.Log("WBCRangeLV2");
                }
                else
                {
                    Debug.Log("Ž_‘f‚ª‘«‚è‚È‚¢");
                }
        break;
            case UpgradeType.WBCRangeLv3:
                if (status.wbcRange == 1.5f && OxygenCounter.totalOxygen >= 60)
                {
                    OxygenCounter.totalOxygen -= 60;
                    status.wbcRange = 2.0f;
                    SkillUnlock.wbcRangeLevel = 3;
                    buttonBright.RefreshButton();
                    Debug.Log("WBCRangeLV3");
                    ++skillmax;
                }
                else
                {
                    Debug.Log("Ž_‘f‚ª‘«‚è‚È‚¢");
                }
                break;
                //
            case UpgradeType.WBCAmountLv1://”’ŒŒ‹…”
                if (status.wbcAmount == 0 && OxygenCounter.totalOxygen >= 15)
                {
                    OxygenCounter.totalOxygen -= 15;
                    status.wbcAmount = 3;
                    SkillUnlock.wbcAmountLevel = 1;
                    buttonBright.RefreshButton();
                    Debug.Log("WBCAmountLV1");
                }
                else
                {
                    Debug.Log("Ž_‘f‚ª‘«‚è‚È‚¢");
                }
                break;
            case UpgradeType.WBCAmountLv2:
                if (status.wbcAmount == 3 && OxygenCounter.totalOxygen >= 35)
                {
                    OxygenCounter.totalOxygen -= 35;
                    status.wbcAmount = 8;
                    SkillUnlock.wbcAmountLevel = 2;
                    buttonBright.RefreshButton();
                    Debug.Log("WBCAmountLV2");
                }
                else
                {
                    Debug.Log("Ž_‘f‚ª‘«‚è‚È‚¢");
                }
                break;
            case UpgradeType.WBCAmountLv3:
                if (status.wbcAmount == 8 && OxygenCounter.totalOxygen >= 50)
                {
                    OxygenCounter.totalOxygen -= 50;
                    status.wbcAmount = 15;
                    SkillUnlock.wbcAmountLevel = 3;
                    buttonBright.RefreshButton();
                    Debug.Log("WBCAmountLV3");
                }
                else
                {
                    Debug.Log("Ž_‘f‚ª‘«‚è‚È‚¢");
                }
                break;
            case UpgradeType.WBCAmountLv4:
                if (status.wbcAmount == 15 && OxygenCounter.totalOxygen >= 80)
                {
                    OxygenCounter.totalOxygen -= 80;
                    status.wbcAmount = 30;
                    SkillUnlock.wbcAmountLevel = 4;
                    buttonBright.RefreshButton();
                    Debug.Log("WBCAmountLV4");
                }
                else
                {
                    Debug.Log("Ž_‘f‚ª‘«‚è‚È‚¢");
                }
                break;
            case UpgradeType.WBCAmountLv5:
                if (status.wbcAmount == 30 && OxygenCounter.totalOxygen >= 120)
                {
                    OxygenCounter.totalOxygen -= 120;
                    status.wbcAmount = 45;
                    SkillUnlock.wbcAmountLevel = 5;
                    buttonBright.RefreshButton();
                    Debug.Log("WBCAmountLV5");
                    ++skillmax;
                }
                else
                {
                    Debug.Log("Ž_‘f‚ª‘«‚è‚È‚¢");
                }
                break;

            case UpgradeType.PLTCureLv1://‰ñ•œ‘¬“x
                if (status.pltCure == 1.0f && OxygenCounter.totalOxygen >= 15)
                {
                    OxygenCounter.totalOxygen -= 15;
                    status.pltCure = 1.2f;
                    SkillUnlock.pltCureLevel = 1;
                    buttonBright.RefreshButton();
                    Debug.Log("PLTCureLV1");
                }
                else
                {
                    Debug.Log("Ž_‘f‚ª‘«‚è‚È‚¢");
                }
                break;
            case UpgradeType.PLTCureLv2:
                if (status.pltCure == 1.2f && OxygenCounter.totalOxygen >= 30)
                {
                    OxygenCounter.totalOxygen -= 30;
                    status.pltCure = 1.5f;
                    SkillUnlock.pltCureLevel = 2;
                    buttonBright.RefreshButton();
                    Debug.Log("PLTCureLV2");
                }
                else
                {
                    Debug.Log("Ž_‘f‚ª‘«‚è‚È‚¢");
                }
                break;
            case UpgradeType.PLTCureLv3:
                if (status.pltCure == 1.5f && OxygenCounter.totalOxygen >= 60)
                {
                    OxygenCounter.totalOxygen -= 60;
                    status.pltCure = 1.8f;
                    SkillUnlock.pltCureLevel = 3;
                    buttonBright.RefreshButton();
                    Debug.Log("PLTCureLV3");
                    ++skillmax;
                }
                else
                {
                    Debug.Log("Ž_‘f‚ª‘«‚è‚È‚¢");
                }
                break;

            case UpgradeType.PLTAmountLv1://ŒŒ¬”Â”
                if (status.pltAmount == 0 && OxygenCounter.totalOxygen >= 15)
                {
                    OxygenCounter.totalOxygen -= 15;
                    status.pltAmount = 10;
                    SkillUnlock.pltAmountLevel = 1;
                    buttonBright.RefreshButton();
                    Debug.Log("PLTAmountLV1");
                }
                else
                {
                    Debug.Log("Ž_‘f‚ª‘«‚è‚È‚¢");
                }
                break;
            case UpgradeType.PLTAmountLv2:
                if (status.pltAmount == 10 && OxygenCounter.totalOxygen >= 35)
                {
                    OxygenCounter.totalOxygen -= 35;
                    status.pltAmount = 18;
                    SkillUnlock.pltAmountLevel = 2;
                    buttonBright.RefreshButton();
                    Debug.Log("PLTAmountLV2");
                }
                else
                {
                    Debug.Log("Ž_‘f‚ª‘«‚è‚È‚¢");
                }
                break;
            case UpgradeType.PLTAmountLv3:
                if (status.pltAmount == 18 && OxygenCounter.totalOxygen >= 50)
                {
                    OxygenCounter.totalOxygen -= 50;
                    status.pltAmount = 25;
                    SkillUnlock.pltAmountLevel = 3;
                    buttonBright.RefreshButton();
                    Debug.Log("PLTAmountLV3");
                }
                else
                {
                    Debug.Log("Ž_‘f‚ª‘«‚è‚È‚¢");
                }
                break;
            case UpgradeType.PLTAmountLv4:
                if (status.pltAmount == 25 && OxygenCounter.totalOxygen >= 80)
                {
                    OxygenCounter.totalOxygen -= 80;
                    status.pltAmount = 40;
                    SkillUnlock.pltAmountLevel = 4;
                    buttonBright.RefreshButton();
                    Debug.Log("PLTAmountLV4");
                }
                else
                {
                    Debug.Log("Ž_‘f‚ª‘«‚è‚È‚¢");
                }
                break;
            case UpgradeType.PLTAmountLv5:
                if (status.pltAmount == 40 && OxygenCounter.totalOxygen >= 120)
                {
                    OxygenCounter.totalOxygen -= 120;
                    status.pltAmount = 60;
                    SkillUnlock.pltAmountLevel = 5;
                    buttonBright.RefreshButton();
                    Debug.Log("PLTAmountLV5");
                    ++skillmax;
                }
                else
                {
                    Debug.Log("Ž_‘f‚ª‘«‚è‚È‚¢");
                }
                break;
                
            case UpgradeType.StageOxLv1://ƒXƒe[ƒW‚ÌŽ_‘f—Ê
                if (status.stageOx == 30 && OxygenCounter.totalOxygen >= 15)
                {
                    OxygenCounter.totalOxygen -= 15;
                    status.stageOx = 35;
                    SkillUnlock.stageOxLevel = 1;
                    buttonBright.RefreshButton();
                    Debug.Log("StageOxLV1");
                }
                else
                {
                    Debug.Log("Ž_‘f‚ª‘«‚è‚È‚¢");
                }
                break;
            case UpgradeType.StageOxLv2:
                if (status.stageOx == 35 && OxygenCounter.totalOxygen >= 30)
                {
                    OxygenCounter.totalOxygen -= 30;
                    status.stageOx = 48;
                    SkillUnlock.stageOxLevel = 2;
                    buttonBright.RefreshButton();
                    Debug.Log("StageOxLV2");
                }
                else
                {
                    Debug.Log("Ž_‘f‚ª‘«‚è‚È‚¢");
                }
                break;
            case UpgradeType.StageOxLv3:
                if (status.stageOx == 48 && OxygenCounter.totalOxygen >= 45)
                {
                    OxygenCounter.totalOxygen -= 45;
                    status.stageOx = 60;
                    SkillUnlock.stageOxLevel = 3;
                    buttonBright.RefreshButton();
                    Debug.Log("StageOxLV3");
                }
                else
                {
                    Debug.Log("Ž_‘f‚ª‘«‚è‚È‚¢");
                }
                break;
            case UpgradeType.StageOxLv4:
                if (status.stageOx == 60 && OxygenCounter.totalOxygen >= 70)
                {
                    OxygenCounter.totalOxygen -= 70;
                    status.stageOx = 75;
                    SkillUnlock.stageOxLevel = 4;
                    buttonBright.RefreshButton();
                    Debug.Log("StageOxLV4");
                }
                else
                {
                    Debug.Log("Ž_‘f‚ª‘«‚è‚È‚¢");
                }
                break;
            case UpgradeType.StageOxLv5:
                if (status.stageOx == 75 && OxygenCounter.totalOxygen >= 100)
                {
                    OxygenCounter.totalOxygen -= 100;
                    status.stageOx = 100;
                    SkillUnlock.stageOxLevel = 5;
                    buttonBright.RefreshButton();
                    Debug.Log("StageOxLV5");
                    ++skillmax;
                }
                else
                {
                    Debug.Log("Ž_‘f‚ª‘«‚è‚È‚¢");
                }
                break;
                
            case UpgradeType.StageTimeLv1://§ŒÀŽžŠÔ
                if (status.stageTime == 10 && OxygenCounter.totalOxygen >= 10)
                {
                    OxygenCounter.totalOxygen -= 10;
                    status.stageTime = 11;
                    //timer.timeRemaining = status.stageTime;
                    SkillUnlock.stageTimeLevel = 1;
                    buttonBright.RefreshButton();
                    Debug.Log("StageTimeLV1");
                }
                else
                {
                    Debug.Log("Ž_‘f‚ª‘«‚è‚È‚¢");
                }
                break;
            case UpgradeType.StageTimeLv2:
                if (status.stageTime == 11 && OxygenCounter.totalOxygen >= 30)
                {
                    OxygenCounter.totalOxygen -= 30;
                    status.stageTime = 13;
                    //timer.timeRemaining = status.stageTime;
                    SkillUnlock.stageTimeLevel = 2;
                    buttonBright.RefreshButton();
                    Debug.Log("StageTimeLV2");
                }
                else
                {
                    Debug.Log("Ž_‘f‚ª‘«‚è‚È‚¢");
                }
                break;
            case UpgradeType.StageTimeLv3:
                if (status.stageTime == 13 && OxygenCounter.totalOxygen >= 45)
                {
                    OxygenCounter.totalOxygen -= 45;
                    status.stageTime = 15;
                    //timer.timeRemaining = status.stageTime;
                    SkillUnlock.stageTimeLevel = 3;
                    buttonBright.RefreshButton();
                    Debug.Log("StageTimeLV3");
                }
                else
                {
                    Debug.Log("Ž_‘f‚ª‘«‚è‚È‚¢");
                }
                break;
            case UpgradeType.StageTimeLv4:
                if (status.stageTime == 15 && OxygenCounter.totalOxygen >= 70)
                {
                    OxygenCounter.totalOxygen -= 70;
                    status.stageTime = 18;
                    //timer.timeRemaining = status.stageTime;
                    SkillUnlock.stageTimeLevel = 4;
                    buttonBright.RefreshButton();
                    Debug.Log("StageTimeLV4");
                }
                else
                {
                    Debug.Log("Ž_‘f‚ª‘«‚è‚È‚¢");
                }
                break;
            case UpgradeType.StageTimeLv5:
                if (status.stageTime == 18 && OxygenCounter.totalOxygen >= 100)
                {
                    OxygenCounter.totalOxygen -= 100;
                    status.stageTime = 22;
                    //timer.timeRemaining = status.stageTime;
                    SkillUnlock.stageTimeLevel = 5;
                    buttonBright.RefreshButton();
                    Debug.Log("StageTimeLV5");
                    ++skillmax;
                }
                else
                {
                    Debug.Log("Ž_‘f‚ª‘«‚è‚È‚¢");
                }
                break;
        }


    }

    public UpgradeType upgradeType;
}
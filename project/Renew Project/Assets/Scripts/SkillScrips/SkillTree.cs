using UnityEngine;

public class SkillTree : MonoBehaviour
{
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

    public UpgradeType upgradeType;
    RBCEnhance rbc;
    WBCEnhance wbc;
    PLTEnhance plt;
    StageEnhance stage;


    public void Upgrade()
    {

        switch (upgradeType)
        {
            case UpgradeType.RBCSpeedLv1://ÔŒŒ‹…ƒXƒs[ƒh
                if (rbc.speed == 5f /*&& OxygenCounter.totalOxygen>=10) {
                    OxygenCounter.totalOxygen -= 10;     //Ž_‘fÁ”ï*/) {
                    rbc.speed = 5.2f;
                    Debug.Log("RBCSpeedLV1");
                }
                break;
            case UpgradeType.RBCSpeedLv2:
                if (rbc.speed == 5.2f /*&& OxygenCounter.totalOxygen>=25){
                    OxygenCounter.totalOxygen -= 25; */) {
                        rbc.speed = 5.5f;
                    Debug.Log("RBCSpeedLV2");
                }
                break;
            case UpgradeType.RBCSpeedLv3:
                if (rbc.speed == 5.5f /*&& OxygenCounter.totalOxygen>=50){
                    OxygenCounter.totalOxygen -= 50; */) {
                        rbc.speed = 5.75f;
                    Debug.Log("RBCSpeedLV3");
                }
                break;

            case UpgradeType.RBCAmountLv1://ÔŒŒ‹…”
                if (rbc.amount == 1 /*&& OxygenCounter.totalOxygen>=20){
                    OxygenCounter.totalOxygen -= 20; */) {
                        rbc.amount = 2;
                    Debug.Log("RBCAmountLV1");
                }
                break;
            case UpgradeType.RBCAmountLv2:
                if (rbc.amount == 2 /*&& OxygenCounter.totalOxygen>=35){
                    OxygenCounter.totalOxygen -= 35; */) {
                        rbc.amount = 3;
                    Debug.Log("RBCAmountLV2");
                }
                break;
            case UpgradeType.RBCAmountLv3:
                if (rbc.amount == 3 /*&& OxygenCounter.totalOxygen>=60){
                    OxygenCounter.totalOxygen -= 60; */) {
                        rbc.amount = 5;
                    Debug.Log("RBCAmountLV3");
                }
                break;
            case UpgradeType.RBCAmountLv4:
                if (rbc.amount == 5 /*&& OxygenCounter.totalOxygen>=85){
                    OxygenCounter.totalOxygen -= 85; */) {
                        rbc.amount = 7;
                    Debug.Log("RBCAmountLV4");
                }
                break;
            case UpgradeType.RBCAmountLv5:
                if (rbc.amount == 7 /*&& OxygenCounter.totalOxygen>=120){
                    OxygenCounter.totalOxygen -= 120; */) {
                        rbc.amount = 10;
                    Debug.Log("RBCAmountLV5");
                }
                break;

            case UpgradeType.RBCHaveLv1://Ž‚Ä‚éŽ_‘f”
                if (rbc.have == 1 /*&& OxygenCounter.totalOxygen>=10){
                    OxygenCounter.totalOxygen -= 10; */) {
                        rbc.have = 2;
                    Debug.Log("RBCHaveLV1");
                }
                break;
            case UpgradeType.RBCHaveLv2:
                if (rbc.have == 2 /*&& OxygenCounter.totalOxygen>=20){
                    OxygenCounter.totalOxygen -= 20; */) {
                        rbc.have = 3;
                    Debug.Log("RBCHaveLV2");
                }
                break;
            case UpgradeType.RBCHaveLv3:
                if (rbc.have == 3 /*&& OxygenCounter.totalOxygen>=50){
                    OxygenCounter.totalOxygen -= 50;*/)
                {
                    rbc.have = 5;
                    Debug.Log("RBCHaveLV3");
                }
                break;

            case UpgradeType.WBCTimeLv1://—}‚¦‚éŽžŠÔ
                if (wbc.time == 2.0f /*&& OxygenCounter.totalOxygen>=10){
                    OxygenCounter.totalOxygen -= 10; */) {
                        wbc.time = 2.4f;
                    Debug.Log("WBCTimeLV1");
                }
                break;
            case UpgradeType.WBCTimeLv2:
                if (wbc.time == 2.4f /*&& OxygenCounter.totalOxygen>=25){
                    OxygenCounter.totalOxygen -= 25; */) {
                        wbc.time = 3.0f;
                    Debug.Log("WBCTimeLV2");
                }
                break;
            case UpgradeType.WBCTimeLv3:
                if(wbc.time == 3.0f /*&& OxygenCounter.totalOxygen>=50){
                    OxygenCounter.totalOxygen -= 50; */) {
                        wbc.time = 4.0f;
                    Debug.Log("WBCTimeLV3");
                }
                break;

            case UpgradeType.WBCRangeLv1://ƒEƒCƒ‹ƒXŠ´’m”ÍˆÍ
                if (wbc.range == 1.0f /*&& OxygenCounter.totalOxygen>=10){
                    OxygenCounter.totalOxygen -= 10; */) {
                        wbc.range = 1.2f;
                    Debug.Log("WBCRangeLV1");
                }
                break;
            case UpgradeType.WBCRangeLv2:
                if (wbc.range == 1.2f /*&& OxygenCounter.totalOxygen>=25) {
                    OxygenCounter.totalOxygen -= 25; */) {
                        wbc.range = 1.5f;
                    Debug.Log("WBCRangeLV2");
                }
                break;
            case UpgradeType.WBCRangeLv3:
                if (wbc.range == 1.5f /*&& OxygenCounter.totalOxygen>=60){
                    OxygenCounter.totalOxygen -= 60; */) {
                        wbc.range = 2.0f;
                    Debug.Log("WBCRangeLV3");
                }
                break;

            case UpgradeType.WBCAmountLv1://”’ŒŒ‹…”
                if (wbc.amount == 0 /*&& OxygenCounter.totalOxygen>=15){
                    OxygenCounter.totalOxygen -= 15; */) {
                        wbc.amount = 3;
                    Debug.Log("WBCAmountLV1");
                }
                break;
            case UpgradeType.WBCAmountLv2:
                if (wbc.amount == 3 /*&& OxygenCounter.totalOxygen>=35){
                    OxygenCounter.totalOxygen -= 35; */) {
                        wbc.amount = 8;
                    Debug.Log("WBCAmountLV2");
                }
                break;
            case UpgradeType.WBCAmountLv3:
                if (wbc.amount == 8 /*&& OxygenCounter.totalOxygen>=50){
                    OxygenCounter.totalOxygen -= 50; */) {
                        wbc.amount = 15;
                    Debug.Log("WBCAmountLV3");
                }
                break;
            case UpgradeType.WBCAmountLv4:
                if (wbc.amount == 15 /*&& OxygenCounter.totalOxygen>=80){
                    OxygenCounter.totalOxygen -= 80; */) {
                        wbc.amount = 30;
                    Debug.Log("WBCAmountLV4");
                }
                break;
            case UpgradeType.WBCAmountLv5:
                if (wbc.amount == 30 /*&& OxygenCounter.totalOxygen>=120){
                    OxygenCounter.totalOxygen -= 120; */) {
                        wbc.amount = 45;
                    Debug.Log("WBCAmountLV5");
                }
                break;

            case UpgradeType.PLTCureLv1://‰ñ•œ‘¬“x
                if (plt.curu == 1.0f /*&& OxygenCounter.totalOxygen>=15){
                    OxygenCounter.totalOxygen -= 15; */) {
                        plt.curu = 1.2f;
                    Debug.Log("PLTCureLV1");
                }
                break;
            case UpgradeType.PLTCureLv2:
                if (plt.curu == 1.2f /*&& OxygenCounter.totalOxygen>=30){
                    OxygenCounter.totalOxygen -= 30; */) {
                        plt.curu = 1.5f;
                    Debug.Log("PLTCureLV2");
                }
                break;
            case UpgradeType.PLTCureLv3:
                if (plt.curu == 1.5f /*&& OxygenCounter.totalOxygen>=60){
                    OxygenCounter.totalOxygen -= 60; */) {
                        plt.curu = 1.8f;
                    Debug.Log("PLTCureLV3");
                }
                break;

            case UpgradeType.PLTAmountLv1://ŒŒ¬”Â”
                if (plt.amount == 0 /*&& OxygenCounter.totalOxygen>=15){
                    OxygenCounter.totalOxygen -= 15; */) {
                        plt.amount = 10;
                    Debug.Log("PLTAmountLV1");
                }
                break;
            case UpgradeType.PLTAmountLv2:
                if (plt.amount == 10 /*&& OxygenCounter.totalOxygen>=35){
                    OxygenCounter.totalOxygen -= 35; */) {
                        plt.amount = 18;
                    Debug.Log("PLTAmountLV2");
                }
                break;
            case UpgradeType.PLTAmountLv3:
                if (plt.amount == 18 /*&& OxygenCounter.totalOxygen>=50){
                    OxygenCounter.totalOxygen -= 50;*/)
                {
                    plt.amount = 25;
                    Debug.Log("PLTAmountLV3");
                }
                break;
            case UpgradeType.PLTAmountLv4:
                if (plt.amount == 25 /*&& OxygenCounter.totalOxygen>=80) {
                    OxygenCounter.totalOxygen -= 80; */) {
                        plt.amount = 40;
                    Debug.Log("PLTAmountLV4");
                }
                break;
            case UpgradeType.PLTAmountLv5:
                if (plt.amount == 40 /*&& OxygenCounter.totalOxygen>=120){
                    OxygenCounter.totalOxygen -= 120; */) {
                        plt.amount = 60;
                    Debug.Log("PLTAmountLV5");
                }
                break;

            case UpgradeType.StageOxLv1://ƒXƒe[ƒW‚ÌŽ_‘f—Ê
                if (stage.ox == 30 /*&& OxygenCounter.totalOxygen>=15){
                    OxygenCounter.totalOxygen -= 15; */) {
                        stage.ox = 35;
                    Debug.Log("StageOxLV1");
                }
                break;
            case UpgradeType.StageOxLv2:
                if (stage.ox == 35 /*&& OxygenCounter.totalOxygen>=30){
                    OxygenCounter.totalOxygen -= 30; */) {
                        stage.ox = 48;
                    Debug.Log("StageOxLV2");
                }
                break;
            case UpgradeType.StageOxLv3:
                if (stage.ox == 48 /*&& OxygenCounter.totalOxygen>=45){
                    OxygenCounter.totalOxygen -= 45; */) {
                        stage.ox = 60;
                    Debug.Log("StageOxLV3");
                }
                break;
            case UpgradeType.StageOxLv4:
                if (stage.ox == 60 /*&& OxygenCounter.totalOxygen>=70){
                    OxygenCounter.totalOxygen -= 70; */) {
                        stage.ox = 75;
                    Debug.Log("StageOxLV4");
                }
                break;
            case UpgradeType.StageOxLv5:
                if (stage.ox == 75 /*&& OxygenCounter.totalOxygen>=100) {
                    OxygenCounter.totalOxygen -= 100; */) {
                        stage.ox = 100;
                    Debug.Log("StageOxLV5");
                }
                break;

            case UpgradeType.StageTimeLv1://§ŒÀŽžŠÔ
                if (stage.time == 10 /*&& OxygenCounter.totalOxygen>=10){
                    OxygenCounter.totalOxygen -= 10; */) {
                        stage.time = 11;
                    Debug.Log("StageTimeLV1");
                }
                break;
            case UpgradeType.StageTimeLv2:
                if (stage.time == 11 /*&& OxygenCounter.totalOxygen>=30){
                    OxygenCounter.totalOxygen -= 30; */) {
                        stage.time = 13;
                    Debug.Log("StageTimeLV2");
                }
                break;
            case UpgradeType.StageTimeLv3:
                if (stage.time == 13 /*&& OxygenCounter.totalOxygen>=45){
                    OxygenCounter.totalOxygen -= 45; */) {
                        stage.time = 15; 
                    Debug.Log("StageTimeLV3");
                }
                break;
            case UpgradeType.StageTimeLv4:
                if (stage.time == 15 /*&& OxygenCounter.totalOxygen>=70){
                    OxygenCounter.totalOxygen -= 70; */) {
                        stage.time = 18;
                    Debug.Log("StageTimeLV4");
                }
                break;
            case UpgradeType.StageTimeLv5:
                if (stage.time == 18 /*&& OxygenCounter.totalOxygen>=100){
                    OxygenCounter.totalOxygen -= 100; */) {
                        stage.time = 22;
                    Debug.Log("StageTimeLV5");
                }
                break;
        }
  

    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        rbc = FindFirstObjectByType<RBCEnhance>();
        wbc = FindFirstObjectByType<WBCEnhance>();
        plt = FindFirstObjectByType<PLTEnhance>();
        stage = FindFirstObjectByType<StageEnhance>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
using UnityEngine;

/// <summary>
/// ’S“–Ò–¼FÎú±•Ÿl
/// 
/// _‘f‚Ì”‚ğŒvZ‚·‚éƒNƒ‰ƒX‚Å‚·
/// </summary>
public static class OxygenCounter
{
    public static int totalOxygen = 0;
    private static int currentOxygen = 0;

    public static void Add(int amount = 1)
    {
        currentOxygen += amount;
        Debug.Log("Œ»İ‚Ì_‘f”: " + currentOxygen);
    }
    
    //@_‘f‚ğWŒv‚·‚éŠÖ”
    public static void OxygenTotaling()
    {
        totalOxygen = totalOxygen + currentOxygen;
        currentOxygen = 0;
    }

    //@Œ»İ•Û‚µ‚Ä‚¢‚é_‘f‚ğ”jŠü‚·‚éŠÖ”
    public static void DeleteCurrentOxygen()
    {
        currentOxygen = 0;
    }
}

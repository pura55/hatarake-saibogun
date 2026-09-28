using UnityEngine;

/// <summary>
/// ’S“–Ò–¼FÎú±•Ÿl
/// 
/// _‘f‚Ì”‚ğŒvZ‚·‚éƒNƒ‰ƒX‚Å‚·
/// </summary>
public static class OxygenCounter
{
    public static int totalOxygen = 0; // WŒv‚·‚é_‘f”
    private static int currentOxygen = 0; // Œ»İ‚Ì_‘f”

    public static int CurrentOxygen => currentOxygen;

    /// @brief _‘f‚ğ‰ÁZ‚·‚éŠÖ”
    public static void Add(int amount = 1)
    {
        currentOxygen += amount;
        Debug.Log("Œ»İ‚Ì_‘f”: " + currentOxygen);
    }

    /// @brief Œ»İŠ‚µ‚Ä‚¢‚é_‘f‚ğŒ¸­‚³‚¹‚éŠÖ”
    public static void Reduction(int amount = 1)
    {
        currentOxygen -= amount;
        Debug.Log("Œ»İ‚Ì_‘f”: " + currentOxygen);
    }

    /// @brief@_‘f‚ğWŒv‚·‚éŠÖ”
    public static void OxygenTotaling()
    {
        totalOxygen = totalOxygen + currentOxygen;
        currentOxygen = 0;
    }

    /// @brief@Œ»İ•Û‚µ‚Ä‚¢‚é_‘f‚ğ”jŠü‚·‚éŠÖ”
    public static void DeleteCurrentOxygen()
    {
        currentOxygen = 0;
    }
}

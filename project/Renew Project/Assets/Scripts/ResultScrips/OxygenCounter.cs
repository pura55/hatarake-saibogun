using UnityEngine;
public static class OxygenCounter
{
    public static int totalOxygen = 0;

    public static void Add(int amount = 1)
    {
        totalOxygen += amount;
        Debug.Log("ëçé_ëfêî: " + totalOxygen);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public static int Score;
    public static int Tries;
    public static float SuccessRate;

    public static void IncreaseScoreAndTries()
    {
        Score++;
        Tries++;

        CalculateSuccessRate();
    }

    public static void IncreaseTries()
    {
        Tries++;

        CalculateSuccessRate();
    }

    private static void CalculateSuccessRate()
    {
        if (Score != 0)
            SuccessRate = (float)Score / (float)Tries * 100.00f;
    }

    public static void ResetStats()
    {
        Score = Tries = 0;
        SuccessRate = 0;
    }
}

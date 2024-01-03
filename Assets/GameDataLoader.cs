using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataLoader : MonoBehaviour
{
    public int SmallDronesKilled;
    public int HeavyDronesKilled;
    public int RoboScorpsKilled;
    public float HealthLost;
    public float HealthRestored;
    public int BonusesUsed;
    public float TotalShotsFired;
    public float TotalShotsAccepted;
    public float PercentageOfHits;
    public int WavesPassed;
    public float TotalScore;
    void Start()
    {
        SmallDronesKilled = PlayerPrefs.GetInt("SmallDronesKilled");
        HeavyDronesKilled = PlayerPrefs.GetInt("HeavyDronesKilled");
        RoboScorpsKilled = PlayerPrefs.GetInt("RoboScorpsKilled");
        HealthLost = PlayerPrefs.GetFloat("HealthLost");
        HealthRestored = PlayerPrefs.GetFloat("HealthRestored");
        BonusesUsed = PlayerPrefs.GetInt("BonusesUsed");
        TotalShotsFired = PlayerPrefs.GetFloat("TotalShotsFired");
        TotalShotsAccepted = PlayerPrefs.GetFloat("TotalShotsAccepted");
        PercentageOfHits = PlayerPrefs.GetFloat("PercentageOfHits");
        WavesPassed = PlayerPrefs.GetInt("WavesPassed");
        TotalScore = PlayerPrefs.GetFloat("TotalScore");
    }
}

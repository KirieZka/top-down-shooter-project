using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataSaver : MonoBehaviour
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
    public void SaveData()
    {
        PercentageOfHits = (TotalShotsAccepted / TotalShotsFired) * 100;
        TotalScore = (SmallDronesKilled * 10) + (HeavyDronesKilled * 50) + (RoboScorpsKilled * 25) - (HealthLost * 10) - (BonusesUsed * 10) + (PercentageOfHits * 50) + (WavesPassed * 100);
        PlayerPrefs.SetInt("SmallDronesKilled", SmallDronesKilled);
        PlayerPrefs.SetInt("HeavyDronesKilled", HeavyDronesKilled);
        PlayerPrefs.SetInt("RoboScorpsKilled", RoboScorpsKilled);
        PlayerPrefs.SetFloat("HealthLost", HealthLost);
        PlayerPrefs.SetFloat("HealthRestored", HealthRestored);
        PlayerPrefs.SetInt("BonusesUsed", BonusesUsed);
        PlayerPrefs.SetFloat("TotalShotsFired", TotalShotsFired);
        PlayerPrefs.SetFloat("TotalShotsAccepted", TotalShotsAccepted);
        PlayerPrefs.SetFloat("PercentageOfHits", PercentageOfHits);
        PlayerPrefs.SetInt("WavesPassed", WavesPassed+1);
        PlayerPrefs.SetFloat("TotalScore", TotalScore);
    }
}

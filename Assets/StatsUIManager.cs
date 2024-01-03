using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsUIManager : MonoBehaviour
{
    public GameDataLoader GameDataLoader;
    public Text LightDronesKilledText;
    public Text HeavyDronesKilledText;
    public Text RoboScropsKilledText;
    public Text HealthLostText;
    public Text HealthRestoredText;
    public Text BonusesUsedText;
    public Text TotalShotsText;
    public Text PercentageOfHitsText;
    public Text WavesPassedtext;
    public Text TotalScoretext;

    private void Start()
    {
        LightDronesKilledText.text = $"Small drones killed: {GameDataLoader.SmallDronesKilled}";
        HeavyDronesKilledText.text = $"Heavy drones killed: {GameDataLoader.HeavyDronesKilled}";
        RoboScropsKilledText.text = $"RoboScorps killed: {GameDataLoader.RoboScorpsKilled}";
        HealthLostText.text = $"Health lost: {GameDataLoader.HealthLost}";
        HealthRestoredText.text = $"Health restored: {GameDataLoader.HealthRestored}";
        BonusesUsedText.text = $"Bonuses used: {GameDataLoader.BonusesUsed}";
        TotalShotsText.text = $"Total shots fired: {GameDataLoader.TotalShotsFired}";
        PercentageOfHitsText.text = $"Percentage of hits: {GameDataLoader.PercentageOfHits}";
        WavesPassedtext.text = $"Waves passed: {GameDataLoader.WavesPassed}";
        TotalScoretext.text = $"TOTAL SCORE: {GameDataLoader.TotalScore}";
    }
}

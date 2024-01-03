using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitToMenuScript : MonoBehaviour
{
    public void ExitToMenu()
    {
        PlayerPrefs.DeleteKey("SmallDronesKilled");
        PlayerPrefs.DeleteKey("HeavyDronesKilled");
        PlayerPrefs.DeleteKey("RoboScorpsKilled");
        PlayerPrefs.DeleteKey("HealthLost");
        PlayerPrefs.DeleteKey("HealthRestored");
        PlayerPrefs.DeleteKey("BonusesUsed");
        PlayerPrefs.DeleteKey("TotalShotsFired");
        PlayerPrefs.DeleteKey("TotalShotsAccepted");
        PlayerPrefs.DeleteKey("PercentageOfHits");
        PlayerPrefs.DeleteKey("WavesPassed");
        PlayerPrefs.DeleteKey("TotalScore");
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}

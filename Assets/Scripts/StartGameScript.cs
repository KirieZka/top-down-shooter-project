using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGameScript : MonoBehaviour
{
    public Slider MusicSlider;
    public Slider SoundSlider;
    public CharNumScript charNum;
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void SaveMenuData()
    {
        PlayerPrefs.SetFloat("MusicVolume", MusicSlider.value);
        PlayerPrefs.SetFloat("SoundVolume", SoundSlider.value);
        PlayerPrefs.SetInt("CharNum", charNum.CharNum);
        Debug.Log("Saved");
    }
}

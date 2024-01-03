using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadMenuData : MonoBehaviour
{

    public Slider MusicSlider;
    public Slider SoundSlider;
    public int CharNum;

    public GameObject[] chars;
    void Awake()
    {
        
        if (PlayerPrefs.HasKey("MusicVolume"))
        {
            MusicSlider.value = PlayerPrefs.GetFloat("MusicVolume");
            SoundSlider.value = PlayerPrefs.GetFloat("SoundVolume");
            CharNum = PlayerPrefs.GetInt("CharNum");
            chars[CharNum - 1].SetActive(true);
            Debug.Log("Game data loaded!");
        }
        else
            Debug.LogError("There is no save data!");
    }

    private void Start()
    {
            
        
    }
}

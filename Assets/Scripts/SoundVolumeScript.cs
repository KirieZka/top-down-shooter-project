using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundVolumeScript : MonoBehaviour
{
    public AudioSource[] AudioSources;
    public Slider slider;
    public void ChangeVolume()
    {
        foreach (AudioSource sound in AudioSources)
        {
            sound.volume = slider.value;
        }
    }
}

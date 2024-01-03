using UnityEngine;
using UnityEngine.UI;

public class SoundsVolumeController : MonoBehaviour
{
    public Slider musicVolumeSlider;
    public Slider sfxVolumeSlider;

    private void Start()
    {
        // Инициализация слайдеров с текущими значениями громкости
        musicVolumeSlider.value = GetMusicVolume();
        sfxVolumeSlider.value = GetSFXVolume();

        // Добавление обработчиков событий изменения значений слайдеров
        musicVolumeSlider.onValueChanged.AddListener(ChangeMusicVolume);
        sfxVolumeSlider.onValueChanged.AddListener(ChangeSFXVolume);
    }

    private float GetMusicVolume()
    {
        // Получение текущей громкости музыки из Wwise
        uint musicRTPCID = AkSoundEngine.GetIDFromString("musicVolume");
        uint playingID = AkSoundEngine.AK_INVALID_PLAYING_ID;
        float musicVolume;
        int valueType = 0;

        AKRESULT result = AkSoundEngine.GetRTPCValue(musicRTPCID, gameObject, playingID, out musicVolume, ref valueType);

        if (result == AKRESULT.AK_Success)
        {
            return musicVolume;
        }
        else
        {
            Debug.LogWarning("Failed to get music volume from Wwise.");
            return 0f;
        }
    }

    private float GetSFXVolume()
    {
        // Получение текущей громкости звуковых эффектов из Wwise
        uint sfxRTPCID = AkSoundEngine.GetIDFromString("soundVolume");
        uint playingID = AkSoundEngine.AK_INVALID_PLAYING_ID;
        float sfxVolume;
        int valueType = 0;

        AKRESULT result = AkSoundEngine.GetRTPCValue(sfxRTPCID, gameObject, playingID, out sfxVolume, ref valueType);

        if (result == AKRESULT.AK_Success)
        {
            return sfxVolume;
        }
        else
        {
            Debug.LogWarning("Failed to get SFX volume from Wwise.");
            return 0f;
        }
    }

    private void ChangeMusicVolume(float volume)
    {
        // Изменение громкости музыки в Wwise
        uint musicRTPCID = AkSoundEngine.GetIDFromString("musicVolume");
        uint playingID = AkSoundEngine.AK_INVALID_PLAYING_ID;

        AKRESULT result = AkSoundEngine.SetRTPCValue(musicRTPCID, volume, gameObject);
        if (result != AKRESULT.AK_Success)
        {
            Debug.LogWarning("Failed to set music volume in Wwise.");
        }
    }

    private void ChangeSFXVolume(float volume)
    {
        // Изменение громкости звуковых эффектов в Wwise
        uint sfxRTPCID = AkSoundEngine.GetIDFromString("soundVolume");
        uint playingID = AkSoundEngine.AK_INVALID_PLAYING_ID;

        AKRESULT result = AkSoundEngine.SetRTPCValue(sfxRTPCID, volume, gameObject);

        if (result != AKRESULT.AK_Success)
        {
            Debug.LogWarning("Failed to set SFX volume in Wwise.");
        }
    }
}

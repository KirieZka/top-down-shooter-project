using UnityEngine;
using UnityEngine.UI;

public class SoundsVolumeController : MonoBehaviour
{
    public Slider musicVolumeSlider;
    public Slider sfxVolumeSlider;

    private void Start()
    {
        // ������������� ��������� � �������� ���������� ���������
        musicVolumeSlider.value = GetMusicVolume();
        sfxVolumeSlider.value = GetSFXVolume();

        // ���������� ������������ ������� ��������� �������� ���������
        musicVolumeSlider.onValueChanged.AddListener(ChangeMusicVolume);
        sfxVolumeSlider.onValueChanged.AddListener(ChangeSFXVolume);
    }

    private float GetMusicVolume()
    {
        // ��������� ������� ��������� ������ �� Wwise
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
        // ��������� ������� ��������� �������� �������� �� Wwise
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
        // ��������� ��������� ������ � Wwise
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
        // ��������� ��������� �������� �������� � Wwise
        uint sfxRTPCID = AkSoundEngine.GetIDFromString("soundVolume");
        uint playingID = AkSoundEngine.AK_INVALID_PLAYING_ID;

        AKRESULT result = AkSoundEngine.SetRTPCValue(sfxRTPCID, volume, gameObject);

        if (result != AKRESULT.AK_Success)
        {
            Debug.LogWarning("Failed to set SFX volume in Wwise.");
        }
    }
}

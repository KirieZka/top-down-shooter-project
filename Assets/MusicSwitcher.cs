using UnityEngine;
using AK.Wwise; // ������������ ���������� AK.Wwise

public class MusicSwitcher : MonoBehaviour
{
    public AK.Wwise.Event musicEvent1; // ������� ��� ������ ����������
    public AK.Wwise.Event musicEvent2; // ������� ��� ������ ����������

    private bool playFirstMusic = true;

    private void Start()
    {
        // ������������� ��������� ������� (������)
        if (playFirstMusic)
        {
            musicEvent1.Post(gameObject);
        }
        else
        {
            musicEvent2.Post(gameObject);
        }

        // ������ ����������� ��������� ����������
        AkSoundEngine.PostEvent(playFirstMusic ? musicEvent1.Id : musicEvent2.Id, gameObject, (uint)AkCallbackType.AK_EndOfEvent, OnMusicEndCallback, null);
    }

    private void OnMusicEndCallback(object in_cookie, AkCallbackType in_type, object in_info)
    {
        if (this == null)
        {
            // ��������, ��� ������ �� ��� ���������
            return;
        }

        if (in_type == AkCallbackType.AK_EndOfEvent)
        {
            // ������������ �� ��������� ����������
            playFirstMusic = !playFirstMusic;

            // ������������� ������� ��� ��������������� ����������
            if (playFirstMusic)
            {
                musicEvent1.Post(gameObject);
            }
            else
            {
                musicEvent2.Post(gameObject);
            }

            // ������ ����������� ��������� ����� ����������
            AkSoundEngine.PostEvent(playFirstMusic ? musicEvent1.Id : musicEvent2.Id, gameObject, (uint)AkCallbackType.AK_EndOfEvent, OnMusicEndCallback, null);
        }
    }
}

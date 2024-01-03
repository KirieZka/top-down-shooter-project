using UnityEngine;
using AK.Wwise; // Импортируйте библиотеку AK.Wwise

public class MusicSwitcher : MonoBehaviour
{
    public AK.Wwise.Event musicEvent1; // Событие для первой композиции
    public AK.Wwise.Event musicEvent2; // Событие для второй композиции

    private bool playFirstMusic = true;

    private void Start()
    {
        // Воспроизвести начальное событие (музыку)
        if (playFirstMusic)
        {
            musicEvent1.Post(gameObject);
        }
        else
        {
            musicEvent2.Post(gameObject);
        }

        // Начать отслеживать окончание композиции
        AkSoundEngine.PostEvent(playFirstMusic ? musicEvent1.Id : musicEvent2.Id, gameObject, (uint)AkCallbackType.AK_EndOfEvent, OnMusicEndCallback, null);
    }

    private void OnMusicEndCallback(object in_cookie, AkCallbackType in_type, object in_info)
    {
        if (this == null)
        {
            // Проверка, что объект не был уничтожен
            return;
        }

        if (in_type == AkCallbackType.AK_EndOfEvent)
        {
            // Переключение на следующую композицию
            playFirstMusic = !playFirstMusic;

            // Воспроизвести событие для соответствующей композиции
            if (playFirstMusic)
            {
                musicEvent1.Post(gameObject);
            }
            else
            {
                musicEvent2.Post(gameObject);
            }

            // Начать отслеживать окончание новой композиции
            AkSoundEngine.PostEvent(playFirstMusic ? musicEvent1.Id : musicEvent2.Id, gameObject, (uint)AkCallbackType.AK_EndOfEvent, OnMusicEndCallback, null);
        }
    }
}

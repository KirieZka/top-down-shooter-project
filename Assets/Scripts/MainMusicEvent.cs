using UnityEngine;

public class MainMusicEvent : MonoBehaviour
{
    public AK.Wwise.Event musicEvent; // Ссылка на Wwise событие для воспроизведения музыки

    void Start()
    {
        // Воспроизведение музыки при запуске сцены
        musicEvent.Post(gameObject);
    }
}

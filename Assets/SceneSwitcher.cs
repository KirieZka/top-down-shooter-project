using UnityEngine;
using AK.Wwise;

public class SceneSwitcher : MonoBehaviour
{
    // Стопим звуковые события при уничтожении объекта или выходе из приложения
    private void OnDestroy()
    {
        AkSoundEngine.StopAll();
    }

    private void OnApplicationQuit()
    {
        AkSoundEngine.StopAll();
    }
}

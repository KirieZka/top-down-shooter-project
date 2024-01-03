using UnityEngine;
using AK.Wwise;

public class SceneSwitcher : MonoBehaviour
{
    // ������ �������� ������� ��� ����������� ������� ��� ������ �� ����������
    private void OnDestroy()
    {
        AkSoundEngine.StopAll();
    }

    private void OnApplicationQuit()
    {
        AkSoundEngine.StopAll();
    }
}

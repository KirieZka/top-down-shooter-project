using UnityEngine;

public class MainMusicEvent : MonoBehaviour
{
    public AK.Wwise.Event musicEvent; // ������ �� Wwise ������� ��� ��������������� ������

    void Start()
    {
        // ��������������� ������ ��� ������� �����
        musicEvent.Post(gameObject);
    }
}

using UnityEngine;
using UnityEngine.UI;

public class UIClickScript : MonoBehaviour
{
    // ����� �� ������ ��������� ��� ������� Wwise ����� �������� Unity
    public string buttonClickEventName = "UIClick";

    private void Start()
    {
        // ������� ������ "Button" � ����� ��� ����������� ���� ������ ���������� ������.
        Button button = GetComponent<Button>();

        // ��������������� ������� ��� ��������� ������� ������.
        button.onClick.AddListener(PlayButtonClickSound);
    }

    private void PlayButtonClickSound()
    {
        // �������������� ���� ������� ������, ������� ������� Wwise �� ��� �����.
        AkSoundEngine.PostEvent(buttonClickEventName, gameObject);
    }
}

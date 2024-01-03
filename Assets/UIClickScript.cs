using UnityEngine;
using UnityEngine.UI;

public class UIClickScript : MonoBehaviour
{
    // Здесь вы можете присвоить имя события Wwise через редактор Unity
    public string buttonClickEventName = "UIClick";

    private void Start()
    {
        // Найдите объект "Button" в сцене или используйте свой способ нахождения кнопки.
        Button button = GetComponent<Button>();

        // Зарегистрируйте функцию для обработки нажатия кнопки.
        button.onClick.AddListener(PlayButtonClickSound);
    }

    private void PlayButtonClickSound()
    {
        // Воспроизведите звук нажатия кнопки, вызывая событие Wwise по его имени.
        AkSoundEngine.PostEvent(buttonClickEventName, gameObject);
    }
}

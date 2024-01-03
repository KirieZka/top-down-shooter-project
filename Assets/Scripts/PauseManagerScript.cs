using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseManagerScript : MonoBehaviour
{
    public GameObject PauseMenu; // Ссылка на окно паузы
    public GameObject SettingsMenu;
    private bool isPaused = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0; // Останавливаем игру
        PauseMenu.SetActive(true); // Открываем окно паузы
    }

    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1; // Возобновляем игру
        PauseMenu.SetActive(false); // Закрываем окно паузы
    }

    public void Settings()
    {
        SettingsMenu.SetActive(true);
    }
    public void ExitToMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}

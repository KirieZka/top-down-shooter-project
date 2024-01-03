using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseManagerScript : MonoBehaviour
{
    public GameObject PauseMenu; // ������ �� ���� �����
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
        Time.timeScale = 0; // ������������� ����
        PauseMenu.SetActive(true); // ��������� ���� �����
    }

    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1; // ������������ ����
        PauseMenu.SetActive(false); // ��������� ���� �����
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

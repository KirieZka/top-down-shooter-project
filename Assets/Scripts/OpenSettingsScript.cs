using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenSettingsScript : MonoBehaviour
{
    public GameObject SettingsWindow;

    public void OpenSettings()
    {
        SettingsWindow.SetActive(true);
    }
}

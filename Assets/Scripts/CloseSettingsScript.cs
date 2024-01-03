using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseSettingsScript : MonoBehaviour
{
    public GameObject SettingsTab;

    public void CloseSettingsTab()
    {
        SettingsTab.SetActive(false);
    }
}

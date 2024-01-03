using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
    public GameObject PauseTab;

    public void Pause()
    {
        PauseTab.SetActive(true);
        Time.timeScale = 0f;
    }
}

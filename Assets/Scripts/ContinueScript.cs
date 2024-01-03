using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinueScript : MonoBehaviour
{
    public GameObject PauseTab;

    public void ContinueGame()
    {
        PauseTab.SetActive(false);
        Time.timeScale = 1;
    }
}

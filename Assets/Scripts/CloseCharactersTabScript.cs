using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseCharactersTabScript : MonoBehaviour
{
    public GameObject CharactersTab;

    public void CloseCharactersTab()
    {
        CharactersTab.SetActive(false);
    }
}

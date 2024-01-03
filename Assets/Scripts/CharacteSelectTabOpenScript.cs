using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacteSelectTabOpenScript : MonoBehaviour
{
    public GameObject CharactersTab;

    public void OpenCharactersTab()
    {
        CharactersTab.SetActive(true);
    }
}

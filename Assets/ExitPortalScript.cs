using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitPortalScript : MonoBehaviour
{
    GameDataSaver Saver;

    private void Start()
    {
        Saver = GameObject.FindGameObjectWithTag("GameDataSaver").GetComponent<GameDataSaver>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Saver.SaveData();
            SceneManager.LoadScene(2);
        }
    }
}

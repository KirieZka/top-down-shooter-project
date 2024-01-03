using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeathChecker : MonoBehaviour
{
    public CharacterHealth Health;
    public GameDataSaver Saver;

    void Update()
    {
        if (Health.Health <= 0)
        {
            Saver.SaveData();
            SceneManager.LoadScene(2);
        }
    }
}

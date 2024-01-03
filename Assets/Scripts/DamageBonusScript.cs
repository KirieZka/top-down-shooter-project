using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AK.Wwise; // Импортируйте библиотеку AK.Wwise

public class DamageBonusScript : MonoBehaviour
{
    public BonusManagerScript BonusManager;
    public GameDataSaver GameDataSaver;
    public AK.Wwise.Event bonusPickupSound; // Событие для звука бонуса

    private void Start()
    {
        GameDataSaver = GameObject.FindGameObjectWithTag("GameDataSaver").GetComponent<GameDataSaver>();
        BonusManager = GameObject.FindGameObjectWithTag("BonusManager").GetComponent<BonusManagerScript>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameDataSaver.BonusesUsed++;
            BonusManager.DamageBonusState = true;
            BonusManager.DamageBonusTimer += 10f;

            // Воспроизводим звук бонуса и добавляем коллбэк окончания события
            bonusPickupSound.Post(gameObject, (uint)AkCallbackType.AK_EndOfEvent, OnSoundEndCallback);

            // Оставляем объект бонуса в сцене
            gameObject.SetActive(false);
        }
    }

    private void OnSoundEndCallback(object in_cookie, AkCallbackType in_type, object in_info)
    {
        // Закончилось воспроизведение звука, теперь можно уничтожить объект бонуса
        Destroy(gameObject);
    }
}

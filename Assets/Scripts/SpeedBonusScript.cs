using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBonusScript : MonoBehaviour
{
    public BonusManagerScript BonusManager;
    public GameDataSaver GameDataSaver;
    public AK.Wwise.Event bonusPickupSound;


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
            BonusManager.SpeedBonusState = true;
            BonusManager.SpeedBonusTimer += 10f;
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

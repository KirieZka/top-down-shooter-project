using System.Collections.Generic;
using UnityEngine;

public class RestoreHealth : MonoBehaviour
{
    public float RestoredHealth = 50;
    CharacterHealth health;
    public GameDataSaver GameDataSaver;
    public AK.Wwise.Event bonusPickupSound;



    private void Start()
    {
        GameDataSaver = GameObject.FindGameObjectWithTag("GameDataSaver").GetComponent<GameDataSaver>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameDataSaver.BonusesUsed++;
            health = other.gameObject.GetComponent<CharacterHealth>();
            health.Health += RestoredHealth;
            GameDataSaver.HealthRestored += RestoredHealth;

            if (health.Health > health.MaxHealth)
            {
                health.Health = health.MaxHealth;
            }
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

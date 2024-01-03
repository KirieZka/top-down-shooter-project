using UnityEngine;

public class ApplyDamage : MonoBehaviour
{
    public int Damage = 10;
    private Ability _ability;
    public GameDataSaver GameDataSaver;

    private void Start()
    {
        GameDataSaver = GameObject.FindGameObjectWithTag("GameDataSaver").GetComponent<GameDataSaver>();
        _ability = GameObject.FindGameObjectWithTag("Player").GetComponent<Ability>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!gameObject.CompareTag("PlayerBullet")) 
        {
            if (other.gameObject.CompareTag("Player"))
            {
                try
                {
                    CharacterHealth characterHealth = other.gameObject.GetComponent<CharacterHealth>();
                    characterHealth.Health -= (Damage) / characterHealth.Armor;
                    GameDataSaver.HealthLost += (Damage) / characterHealth.Armor;

                }
                catch (System.NullReferenceException e)
                {
                    // Обработка исключения (например, вывод в консоль или другие действия)
                    Debug.LogError("CharacterHealth is null: " + e.Message);
                }
            }
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            try
            {
                CharacterHealth characterHealth = other.gameObject.GetComponent<CharacterHealth>();
                characterHealth.Health -= (Damage*_ability.DamageMult) / characterHealth.Armor;
                GameDataSaver.TotalShotsAccepted++;

            }
            catch (System.NullReferenceException e)
            {
                // Обработка исключения (например, вывод в консоль или другие действия)
                Debug.LogError("CharacterHealth is null: " + e.Message);
            }
        }
        Destroy(this.gameObject);

    }
}

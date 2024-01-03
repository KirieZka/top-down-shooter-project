using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public partial class MeleeAttackSystem : SystemBase
{
    public GameDataSaver GameDataSaver;
    protected override void OnUpdate()
    {
        GameDataSaver = GameObject.FindGameObjectWithTag("GameDataSaver").GetComponent<GameDataSaver>();
        float deltaTime = Time.DeltaTime;

        Entities
            .WithAll<EnemyComponent>()
            .WithoutBurst()
            .ForEach((Entity entity, ref EnemyComponent enemy, ref AnimData animData, in Translation translation) =>
            {
                // Проверим, был ли уже нанесен урон игроку

                // Предположим, что есть доступ к компоненту Translation игрока и его радиусу
                float playerRadius = 0.5f; // Радиус игрока
                Translation playerTranslation = GetComponent<Translation>(GetSingletonEntity<PlayerTag>());

                float distanceToPlayer = math.distance(playerTranslation.Value, translation.Value);

                if (distanceToPlayer <= playerRadius)
                {
                    // Получаем компонент CharacterHealth игрока, если он существует
                    CharacterHealth playerHealth = EntityManager.HasComponent<CharacterHealth>(GetSingletonEntity<PlayerTag>())
                        ? EntityManager.GetComponentData<CharacterHealth>(GetSingletonEntity<PlayerTag>())
                        : new CharacterHealth();

                    // Наносим урон игроку
                    if (!enemy.DamageDealt)
                    {
                        playerHealth.Health -= enemy.Damage/playerHealth.Armor;
                        GameDataSaver.HealthLost += enemy.Damage / playerHealth.Armor;
                        
                    }
                    enemy.DamageDealt = true;
                    animData.Dead = true;


                    // Устанавливаем состояние Dead в AnimData врага

                    
                    // Устанавливаем флаг DamageDealt, чтобы не наносить урон в будущем

                    // Обновляем CharacterHealth игрока, если он существует
                    if (EntityManager.HasComponent<CharacterHealth>(GetSingletonEntity<PlayerTag>()))
                    {
                        EntityManager.SetComponentData(GetSingletonEntity<PlayerTag>(), playerHealth);
                    }
                }
            }).Run();
    }
}

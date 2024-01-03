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
                // ��������, ��� �� ��� ������� ���� ������

                // �����������, ��� ���� ������ � ���������� Translation ������ � ��� �������
                float playerRadius = 0.5f; // ������ ������
                Translation playerTranslation = GetComponent<Translation>(GetSingletonEntity<PlayerTag>());

                float distanceToPlayer = math.distance(playerTranslation.Value, translation.Value);

                if (distanceToPlayer <= playerRadius)
                {
                    // �������� ��������� CharacterHealth ������, ���� �� ����������
                    CharacterHealth playerHealth = EntityManager.HasComponent<CharacterHealth>(GetSingletonEntity<PlayerTag>())
                        ? EntityManager.GetComponentData<CharacterHealth>(GetSingletonEntity<PlayerTag>())
                        : new CharacterHealth();

                    // ������� ���� ������
                    if (!enemy.DamageDealt)
                    {
                        playerHealth.Health -= enemy.Damage/playerHealth.Armor;
                        GameDataSaver.HealthLost += enemy.Damage / playerHealth.Armor;
                        
                    }
                    enemy.DamageDealt = true;
                    animData.Dead = true;


                    // ������������� ��������� Dead � AnimData �����

                    
                    // ������������� ���� DamageDealt, ����� �� �������� ���� � �������

                    // ��������� CharacterHealth ������, ���� �� ����������
                    if (EntityManager.HasComponent<CharacterHealth>(GetSingletonEntity<PlayerTag>()))
                    {
                        EntityManager.SetComponentData(GetSingletonEntity<PlayerTag>(), playerHealth);
                    }
                }
            }).Run();
    }
}

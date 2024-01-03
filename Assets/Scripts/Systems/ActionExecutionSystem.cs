using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;
using UnityEngine.AI;

public partial class ActionExecutionSystem : SystemBase
{
    public Ability abilityBullet;
    protected override void OnUpdate()
    {
        float deltaTime = Time.DeltaTime;

        Entities
            .WithAll<EnemyComponent, UtilityAction, UtilitySystem>()
            .WithoutBurst()
            .ForEach((Entity entity, ref UtilityAction utilityAction, ref AnimData animData, ref EnemyComponent enemy, ref Translation translation, in NavMeshAgent navAgent, in CharacterHealth health) =>
            {
                switch (utilityAction.Action)
                {
                    case ActionType.ApproachPlayer:
                        ExecuteApproachAction(entity, ref translation, ref enemy, navAgent, deltaTime);
                        break;

                    case ActionType.FleeFromPlayer:
                        ExecuteFleeAction(entity, ref translation, ref enemy, navAgent, deltaTime);
                        break;

                    case ActionType.Attack:
                        ExecuteAttackAction(entity, ref animData, ref enemy, deltaTime, ref translation, in health);
                        break;

                    default:
                        break;
                }
            }).Run();
    }

    private void ExecuteApproachAction(Entity entity, ref Translation translation, ref EnemyComponent enemy, NavMeshAgent navAgent, float deltaTime)
    {
        // Предположим, что есть целевой объект, к которому нужно приблизиться, например, игрок
        float3 targetPosition = GetPlayerPosition();

        // Устанавливаем позицию назначения для NavMeshAgent
        if (navAgent.isActiveAndEnabled)
        {
            navAgent.destination = targetPosition;
            navAgent.speed = enemy.Speed;
        }
        
    }

    private void ExecuteFleeAction(Entity entity, ref Translation translation, ref EnemyComponent enemy, NavMeshAgent navAgent, float deltaTime)
    {
        // Предположим, что есть целевой объект, от которого нужно убежать, например, игрок
        float3 targetPosition = GetPlayerPosition();

        // Устанавливаем позицию назначения для NavMeshAgent, чтобы убежать от игрока
        if (navAgent.isActiveAndEnabled)
        {
            navAgent.destination = translation.Value + (translation.Value - targetPosition);
            navAgent.speed = enemy.Speed;
        }
    }

    private void ExecuteAttackAction(Entity entity, ref AnimData animData, ref EnemyComponent enemy, float deltaTime, ref Translation translation, in CharacterHealth health )
    {
        Translation playerPosition = GetComponent<Translation>(GetSingletonEntity<PlayerTag>());
        Translation enemyPosition = GetComponent<Translation>(entity);
        Rotation enemyRotation = GetComponent<Rotation>(entity);
        if (UnityEngine.Time.time < enemy.ShootTime + enemy.ShootDelay || health.Health <= 0) return;

        enemy.ShootTime = UnityEngine.Time.time;
        if (abilityBullet == null)
        {
            abilityBullet = GameObject.FindGameObjectWithTag("Player").GetComponent<Ability>();
        }
        if (abilityBullet.EnemyBulletPrefab != null)
        {
            enemyRotation.Value = quaternion.LookRotation(playerPosition.Value - translation.Value, math.up());
            animData.Firing = true;
            GameObject newBullet = Object.Instantiate(abilityBullet.EnemyBulletPrefab, enemyPosition.Value, Quaternion.identity);
        }
    }

    private float3 GetPlayerPosition()
    {
        // Найдите сущность игрока в вашем ECS мире (предположим, что игрок единственный)
        Entity playerEntity = GetSingletonEntity<PlayerTag>();

        // Получите компонент Translation, чтобы получить позицию игрока
        Translation playerTranslation = GetComponent<Translation>(playerEntity);

        // Верните позицию игрока
        return playerTranslation.Value;
    }
}
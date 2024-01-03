using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public partial class UtilityDecisionSystem : SystemBase
{
    protected override void OnUpdate()
    {
        Entities
    .WithAll<EnemyComponent, UtilityAction, UtilitySystem>()
    .WithoutBurst()
    .ForEach((Entity entity,ref UtilitySystem utilitySystem, ref UtilityAction utilityAction, ref EnemyComponent enemy, ref Translation translation, in CharacterHealth health) =>
    {
        float3 playerPosition = GetPlayerPosition();
        float distanceToPlayer = CalculateDistanceToPlayer(translation, playerPosition); // Расстояние до игрока

        // Оценка уровней полезности и выбор наилучшего действия с использованием UtilitySystem
        float maxUtility = 0f;
        ActionType bestAction = ActionType.ApproachPlayer;

        // Оценка уровней полезности

        utilitySystem.utilityFleeFromPlayer = utilitySystem.FleeFromPlayerUtilityWeight / (health.Health <= 10f ? health.Health + 0.1f : -1f);
        //Debug.Log($"{utilitySystem.FleeFromPlayerUtilityWeight} {health.Health }");
        //Debug.Log($"fleeUtility: {utilityFleeFromPlayer}");

        utilitySystem.utilityAttack = utilitySystem.AttackUtilityWeight * (enemy.Type == EnemyType.Shooter && health.Health > 0 ? 1f : 0f);
        //Debug.Log($"atckUtility: {utilityAttack}");

        utilitySystem.utilityApproachPlayer = utilitySystem.ApproachPlayerUtilityWeight / (1 / distanceToPlayer + 0.1f);
        //Debug.Log($"approachUtility: {utilityApproachPlayer}");


        // Выбор наилучшего действия
        if (utilitySystem.utilityApproachPlayer > maxUtility)
        {
            maxUtility = utilitySystem.utilityApproachPlayer;
            bestAction = ActionType.ApproachPlayer;
        }
        if (utilitySystem.utilityFleeFromPlayer > maxUtility)
        {
            maxUtility = utilitySystem.utilityFleeFromPlayer;
            bestAction = ActionType.FleeFromPlayer;
        }
        if (utilitySystem.utilityAttack > maxUtility)
        {
            maxUtility = utilitySystem.utilityAttack;
            bestAction = ActionType.Attack;
        }

        // Присвоение выбранного действия
        utilityAction.Action = bestAction;
    })
    .Run();
    }

        private float3 GetPlayerPosition()
    {
        float3 playerPosition = float3.zero; // Инициализируйте позицию игрока нулевым значением (или другим по умолчанию)

        // Создайте EntityQuery, чтобы найти сущность игрока с тегом "PlayerTag"
        EntityQuery playerQuery = EntityManager.CreateEntityQuery(typeof(PlayerTag));

        // Если найдена сущность игрока, получите ее позицию
        if (playerQuery.CalculateEntityCount() > 0)
        {
            Entity playerEntity = playerQuery.GetSingletonEntity();
            Translation playerTranslation = EntityManager.GetComponentData<Translation>(playerEntity);
            playerPosition = playerTranslation.Value;
        }

        return playerPosition;
    }
    private float CalculateDistanceToPlayer(Translation translation, float3 playerPosition)
    {
        float3 enemyPosition = translation.Value;
        return math.distance(enemyPosition, playerPosition);
    }

}

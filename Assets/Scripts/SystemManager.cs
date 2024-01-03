using Unity.Collections;
using Unity.Entities;
using UnityEngine;

public class SystemManager : MonoBehaviour
{
    private World world;

    private void Start()
    {
        // Создаем новый мир ECS
        world = World.DefaultGameObjectInjectionWorld;

        // Добавляем системы в цикл обновления ECS
        AddSystemsToUpdateList();
    }

    private void AddSystemsToUpdateList()
    {
        if (world != null)
        {
            // Получаем или создаем необходимые системы и добавляем их в цикл обновления
            ActionExecutionSystem actionExecutionSystem = world.GetOrCreateSystem<ActionExecutionSystem>();
            if (actionExecutionSystem != null)
            {
                world.GetOrCreateSystem<SimulationSystemGroup>().AddSystemToUpdateList(actionExecutionSystem);
            }

            CharacterAnimSystem characterAnimSystem = world.GetOrCreateSystem<CharacterAnimSystem>();
            if (characterAnimSystem != null)
            {
                world.GetOrCreateSystem<SimulationSystemGroup>().AddSystemToUpdateList(characterAnimSystem);
            }

            CharacterMovementSystem characterMovementSystem = world.GetOrCreateSystem<CharacterMovementSystem>();
            if (characterMovementSystem != null)
            {
                world.GetOrCreateSystem<SimulationSystemGroup>().AddSystemToUpdateList(characterMovementSystem);
            }

            CharacterReloadSystem characterReloadSystem = world.GetOrCreateSystem<CharacterReloadSystem>();
            if (characterReloadSystem != null)
            {
                world.GetOrCreateSystem<SimulationSystemGroup>().AddSystemToUpdateList(characterReloadSystem);
            }
            CharacterShootSystem characterShootSystem = world.GetOrCreateSystem<CharacterShootSystem>();
            if (characterShootSystem != null)
            {
                world.GetOrCreateSystem<SimulationSystemGroup>().AddSystemToUpdateList(characterShootSystem);
            }
            InputSystem inputSystem = world.GetOrCreateSystem<InputSystem>();
            if (inputSystem != null)
            {
                world.GetOrCreateSystem<SimulationSystemGroup>().AddSystemToUpdateList(inputSystem);
            }
            MeleeAttackSystem meleeAttackSystem = world.GetOrCreateSystem<MeleeAttackSystem>();
            if (meleeAttackSystem != null)
            {
                world.GetOrCreateSystem<SimulationSystemGroup>().AddSystemToUpdateList(meleeAttackSystem);
            }
            NavMeshMovementSystem navMeshMovementSystem = world.GetOrCreateSystem<NavMeshMovementSystem>();
            if (navMeshMovementSystem != null)
            {
                world.GetOrCreateSystem<SimulationSystemGroup>().AddSystemToUpdateList(navMeshMovementSystem);
            }
            UtilityDecisionSystem utilityDecisionSystem = world.GetOrCreateSystem<UtilityDecisionSystem>();
            if (utilityDecisionSystem != null)
            {
                world.GetOrCreateSystem<SimulationSystemGroup>().AddSystemToUpdateList(utilityDecisionSystem);
            }
        }
    }

    private void RemoveSystemsFromUpdateList()
    {
        if (world != null)
        {
            // Получаем или создаем необходимые системы и добавляем их в цикл обновления
            ActionExecutionSystem actionExecutionSystem = world.GetOrCreateSystem<ActionExecutionSystem>();
            if (actionExecutionSystem != null)
            {
                world.GetOrCreateSystem<SimulationSystemGroup>().RemoveSystemFromUpdateList(actionExecutionSystem);
            }

            CharacterAnimSystem characterAnimSystem = world.GetOrCreateSystem<CharacterAnimSystem>();
            if (characterAnimSystem != null)
            {
                world.GetOrCreateSystem<SimulationSystemGroup>().RemoveSystemFromUpdateList(characterAnimSystem);
            }

            CharacterMovementSystem characterMovementSystem = world.GetOrCreateSystem<CharacterMovementSystem>();
            if (characterMovementSystem != null)
            {
                world.GetOrCreateSystem<SimulationSystemGroup>().RemoveSystemFromUpdateList(characterMovementSystem);
            }

            CharacterReloadSystem characterReloadSystem = world.GetOrCreateSystem<CharacterReloadSystem>();
            if (characterReloadSystem != null)
            {
                world.GetOrCreateSystem<SimulationSystemGroup>().RemoveSystemFromUpdateList(characterReloadSystem);
            }
            CharacterShootSystem characterShootSystem = world.GetOrCreateSystem<CharacterShootSystem>();
            if (characterShootSystem != null)
            {
                world.GetOrCreateSystem<SimulationSystemGroup>().RemoveSystemFromUpdateList(characterShootSystem);
            }
            InputSystem inputSystem = world.GetOrCreateSystem<InputSystem>();
            if (inputSystem != null)
            {
                world.GetOrCreateSystem<SimulationSystemGroup>().RemoveSystemFromUpdateList(inputSystem);
            }
            MeleeAttackSystem meleeAttackSystem = world.GetOrCreateSystem<MeleeAttackSystem>();
            if (meleeAttackSystem != null)
            {
                world.GetOrCreateSystem<SimulationSystemGroup>().RemoveSystemFromUpdateList(meleeAttackSystem);
            }
            NavMeshMovementSystem navMeshMovementSystem = world.GetOrCreateSystem<NavMeshMovementSystem>();
            if (navMeshMovementSystem != null)
            {
                world.GetOrCreateSystem<SimulationSystemGroup>().RemoveSystemFromUpdateList(navMeshMovementSystem);
            }
            UtilityDecisionSystem utilityDecisionSystem = world.GetOrCreateSystem<UtilityDecisionSystem>();
            if (utilityDecisionSystem != null)
            {
                world.GetOrCreateSystem<SimulationSystemGroup>().RemoveSystemFromUpdateList(utilityDecisionSystem);
            }
        }
    }
        private void Update()
    {
        if (world != null)
        {
            // Обновляем мир ECS только если он существует
            world.Update();
        }
    }


    private void DestroyAllEntitiesInWorld(World world)
    {
        EntityManager entityManager = world.EntityManager;
        EntityQuery allEntitiesQuery = entityManager.CreateEntityQuery(ComponentType.ReadOnly<Entity>());

        // Получаем массив всех сущностей
        NativeArray<Entity> allEntities = allEntitiesQuery.ToEntityArray(Allocator.TempJob);

        // Удаляем каждую сущность
        for (int i = 0; i < allEntities.Length; i++)
        {
            entityManager.DestroyEntity(allEntities[i]);
        }

        // Освобождаем ресурсы
        allEntities.Dispose();
    }

    private void OnDestroy()
    {
        // Останавливаем и уничтожаем мир ECS при уничтожении объекта
        if (world != null)
        {
            RemoveSystemsFromUpdateList();
            DestroyAllEntitiesInWorld(world);
            
        }
    }
}

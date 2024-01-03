using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

public class ECSWorld : MonoBehaviour
{
    private World world;
    private ComponentSystemBase movementSystem;

    private void Start()
    {
        // Создаем новый мир ECS
        world = World.DefaultGameObjectInjectionWorld;
        world.GetOrCreateSystem<SimulationSystemGroup>().AddSystemToUpdateList(movementSystem);
    }

    private void Update()
    {
        // Обновляем мир ECS
        world.Update();
    }
}

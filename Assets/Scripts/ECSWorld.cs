using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

public class ECSWorld : MonoBehaviour
{
    private World world;
    private ComponentSystemBase movementSystem;

    private void Start()
    {
        // ������� ����� ��� ECS
        world = World.DefaultGameObjectInjectionWorld;
        world.GetOrCreateSystem<SimulationSystemGroup>().AddSystemToUpdateList(movementSystem);
    }

    private void Update()
    {
        // ��������� ��� ECS
        world.Update();
    }
}

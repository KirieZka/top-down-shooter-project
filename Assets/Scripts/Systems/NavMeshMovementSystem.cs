using Unity.Entities;
using Unity.Transforms;
using Unity.AI.Navigation;
using UnityEngine.AI;
using Unity.Mathematics;
using UnityEngine;

public partial class NavMeshMovementSystem : SystemBase
{
    protected override void OnUpdate()
    {
        float deltaTime = Time.DeltaTime;

        Entities
            .WithAll<EnemyComponent>()
            .WithoutBurst()
            .ForEach((ref Translation translation, ref AnimData animData, ref Rotation rotation, in NavMeshAgent navAgent, in Transform transform) =>
            {
                // ѕроверка наличи€ пути
                if (!navAgent.hasPath)
                {
                    translation.Value = transform.position;
                    return;
                }

                // –ассчитываем направление движени€
                float3 moveDirection = math.normalize((float3)navAgent.steeringTarget - (float3)transform.position);

                // –ассчитываем новую позицию на основе текущей позиции, скорости и времени
                float3 newPosition = (float3)transform.position + moveDirection * navAgent.speed * deltaTime;

                // ѕримен€ем новую позицию
                transform.position = newPosition;
                translation.Value = transform.position;
                float3 directionToPlayer = (float3)navAgent.steeringTarget - translation.Value;

                // –ассчитываем угол между текущим направлением врага и направлением к игроку
                quaternion newRotation = quaternion.LookRotationSafe(directionToPlayer, math.up());

                // ѕримен€ем новое вращение
                rotation.Value = newRotation;

                animData.moveForward = Vector3.Dot(moveDirection, transform.forward) > 0.005f;
                animData.moveBackward = Vector3.Dot(moveDirection, -transform.forward) > 0.005f;
                animData.moveLeft = Vector3.Dot(moveDirection, -transform.right) > 0.005f;
                animData.moveRight = Vector3.Dot(moveDirection, transform.right) > 0.005f;

                if (animData.moveForward || animData.moveBackward || animData.moveLeft || animData.moveRight)
                {
                    animData.Moving = true;
                }
                else
                {
                    animData.Moving = false;
                }
            }).Run();
    }
}
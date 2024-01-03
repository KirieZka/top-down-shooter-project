using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public partial class CharacterMovementSystem : ComponentSystem
{
    private EntityQuery _moveQuery;
    private float2 _moveInput;

    private float MinAngle = 0f;
    private float MaxAngle = 0f;

    public void OnMoveInput(Vector2 input)
    {
        _moveInput = input;
    }
    protected override void OnCreate()
    {
        _moveQuery = GetEntityQuery(ComponentType.ReadOnly<InputData>(), 
            ComponentType.ReadOnly<MoveData>(), 
            ComponentType.ReadOnly<Transform>());
    }
    protected override void OnUpdate()
    {
        Entities.With(_moveQuery).ForEach(
                    (Entity entity, Transform transform, ref InputData inputData, ref MoveData move, ref AnimData animData, ref Translation translation) =>
                    {
                        inputData.pos = transform.position;
                        Vector3 movementDirection = new Vector3(inputData.Move.x * move.Speed, 0, inputData.Move.y * move.Speed);
                        inputData.pos += movementDirection;
                        inputData.pos.y = Mathf.Clamp(inputData.pos.y, 0.35f, 0.35f);
                        transform.position = inputData.pos;
                        translation.Value = inputData.pos;

                        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
                        float rayDistance;

                        // Определение направления движения
                        animData.moveForward = Vector3.Dot(movementDirection, transform.forward) > 0.005f;
                        animData.moveBackward = Vector3.Dot(movementDirection, -transform.forward) > 0.005f;
                        animData.moveLeft = Vector3.Dot(movementDirection, -transform.right) > 0.005f;
                        animData.moveRight = Vector3.Dot(movementDirection, transform.right) > 0.005f;

                        if (animData.moveForward || animData.moveBackward || animData.moveLeft || animData.moveRight)
                        {
                            animData.Moving = true;
                        } else
                        {
                            animData.Moving = false;
                        }

                        //Debug.Log($"forward: {Vector3.Dot(movementDirection, transform.forward)}, back: {Vector3.Dot(movementDirection, -transform.forward)}" +
                            //$"left: {Vector3.Dot(movementDirection, -transform.right)}, right: {Vector3.Dot(movementDirection, transform.right)} ");

                        if (groundPlane.Raycast(ray, out rayDistance))
                        {
                            Vector3 targetPoint = ray.GetPoint(rayDistance);

                            inputData.lookDirection = targetPoint - inputData.pos;
                            inputData.lookDirection.y = 0f;

                            Quaternion targetRotation = Quaternion.LookRotation(inputData.lookDirection);
                            transform.rotation = Quaternion.Euler(Mathf.Clamp(targetRotation.eulerAngles.x, MinAngle, MaxAngle),
                                targetRotation.eulerAngles.y,
                                Mathf.Clamp(targetRotation.eulerAngles.z, MinAngle, MaxAngle));
                        }
                    });
    }
}

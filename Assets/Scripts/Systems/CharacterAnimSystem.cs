using System;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public partial class CharacterAnimSystem : ComponentSystem
{
    private EntityQuery _animQuery;

    protected override void OnCreate()
    {
        _animQuery = GetEntityQuery(ComponentType.ReadOnly<AnimData>(), ComponentType.ReadOnly<Animator>());
    }
    protected override void OnUpdate()
    {
        Entities.With(_animQuery).ForEach(
                    (Entity entity, ref AnimData animData, Animator animator, CharacterHealth health) =>
                    {
                        if (animator == null) return;
                        animator.SetBool("Move", animData.Moving);

                        animator.SetBool("forwarddirection", animData.moveForward);
                        animator.SetBool("backdirection", animData.moveBackward);
                        animator.SetBool("leftdir", animData.moveLeft);
                        animator.SetBool("rightdir", animData.moveRight);
                        animator.SetBool("reloading", animData.Reloading);
                        animator.SetBool("firing", animData.Firing);
                        animator.SetBool("attacked", animData.Attacked);
                        animator.SetBool("dead", animData.Dead);

                        if (health.Health <= 0)
                        {
                            animData.Dead = true;
                        }
                        else
                        {
                            animData.Dead = false;
                        }


                    });
    }
}

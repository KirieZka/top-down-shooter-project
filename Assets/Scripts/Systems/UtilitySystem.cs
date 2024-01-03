using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

[GenerateAuthoringComponent]
public struct UtilitySystem : IComponentData
{
    public float ApproachPlayerUtilityWeight;
    public float FleeFromPlayerUtilityWeight;
    public float AttackUtilityWeight;

    public float utilityFleeFromPlayer;
    public float utilityAttack;
    public float utilityApproachPlayer;


}

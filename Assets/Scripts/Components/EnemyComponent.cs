using Unity.Entities;
using UnityEngine;

[GenerateAuthoringComponent]
public struct EnemyComponent : IComponentData
{
    public EnemyType Type;
    public float Speed;
    public float Damage;
    public float ShootTime;
    public float ShootDelay;
    public bool DamageDealt;
    // ������ ���������, ����� ��� ������������ ��������, �������� � ��.
}

public enum EnemyType
{
    Shooter,
    SmallMelee,
    BigMelee
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : MonoBehaviour, IAbilityTarget
{
    public GameObject BulletPrefab;
    public Transform BulletSpawnPoint;
    public GameObject EnemyBulletPrefab;

    public float DamageMult;
    public float SpeedMult;
    public float WeaponSpeedMult;
    public float WeaponReloadMult;

    public void Execute()
    {
    }
}

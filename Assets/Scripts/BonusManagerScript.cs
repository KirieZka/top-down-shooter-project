using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusManagerScript : MonoBehaviour
{

    public GameObject[] bonusPrefabs; // Массив префабов бонусов
    

    public bool ArmorBonusState;
    public bool SpeedBonusState;
    public bool DamageBonusState;
    public bool WeaponBonusState;

    public float DamageBonusTimer;
    public float ArmorBonusTimer;
    public float SpeedBonusTimer;
    public float WeaponBonusTimer;
    public float spawnChance = 0.5f; // Вероятность выпадения бонуса (50%)


    private CharacterHealth _health;
    private Ability _ability;

    private void Start()
    {
        _health = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterHealth>();
        _ability = GameObject.FindGameObjectWithTag("Player").GetComponent<Ability>();
        

    }

    public void SpawnBonus(Vector3 position)
    {
        if (Random.value <= spawnChance)
        {
            int randomBonusIndex = Random.Range(0, bonusPrefabs.Length);
            GameObject bonusPrefab = bonusPrefabs[randomBonusIndex];
            Instantiate(bonusPrefab, position, Quaternion.identity);
        }
    }
    private void Update()
    {
        if (ArmorBonusState)
        {
            _health.Armor = 2f;
            ArmorBonusTimer -= Time.deltaTime;

            if (ArmorBonusTimer <= 0)
            {
                _health.Armor = 1;
                ArmorBonusState = false;
            }
        }

        if (DamageBonusState)
        {
            _ability.DamageMult = 2f;
            DamageBonusTimer -= Time.deltaTime;
            if (DamageBonusTimer <= 0)
            {
                _ability.DamageMult = 1f;
                DamageBonusState = false;
            }
        }

        if (SpeedBonusState)
        {
            _ability.SpeedMult = 5f;
            SpeedBonusTimer -= Time.deltaTime;
            if (SpeedBonusTimer <= 0)
            {
                _ability.SpeedMult = 1f;
                SpeedBonusState = false;
            }
        }

        if (WeaponBonusState)
        {
            _ability.WeaponSpeedMult = 2f;
            _ability.WeaponReloadMult = 2f;
            WeaponBonusTimer -= Time.deltaTime;
            if (WeaponBonusTimer <= 0)
            {
                _ability.WeaponSpeedMult = 1f;
                _ability.WeaponReloadMult = 1f;
                WeaponBonusState = false;
            }
        }
    }
}

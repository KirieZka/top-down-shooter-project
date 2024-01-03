using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ReturnToPoolEvent : MonoBehaviour
{
    public EnemySpawner Pool;
    public Transform PoolTransform;
    public CharacterHealth characterHealth;
    public BonusManagerScript BonusManager;
    public NavMeshAgent navMeshAgent;
    public GameDataSaver GameDataSaver;

    public AK.Wwise.Event DeathEvent;
    void Start()
    {
        //Debug.Log(gameObject.name);
        GameDataSaver = GameObject.FindGameObjectWithTag("GameDataSaver").GetComponent<GameDataSaver>();
        BonusManager = GameObject.FindGameObjectWithTag("BonusManager").GetComponent<BonusManagerScript>();
        PoolTransform = GameObject.FindGameObjectWithTag("Pool").transform;
        Pool = GameObject.FindGameObjectWithTag("Spawner").GetComponent<EnemySpawner>();
        characterHealth = gameObject.GetComponent<CharacterHealth>();
        navMeshAgent = gameObject.GetComponent<NavMeshAgent>();
    }


    public void ReturnToPool()
    {
        BonusManager.SpawnBonus(gameObject.transform.position);
        gameObject.transform.position = PoolTransform.position;
        

        if (characterHealth.MaxHealth == 75)
        {
            Pool.HeavyEnemyPools.Add(gameObject);
            GameDataSaver.HeavyDronesKilled++;
        }
        if (characterHealth.MaxHealth == 25)
        {
            Pool.LightEnemyPools.Add(gameObject);
            GameDataSaver.SmallDronesKilled++;
        }
        if (characterHealth.MaxHealth == 50)
        {
            Pool.ArcherEnemyPools.Add(gameObject);
            GameDataSaver.RoboScorpsKilled++;
        }
        DeathEvent.Post(gameObject);
        Pool.Enemies--;
        characterHealth.Health = characterHealth.MaxHealth;
        navMeshAgent.enabled = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;
using UnityEngine.AI;

public class EnemySpawner : MonoBehaviour
{
    public Transform[] spawnPoints; // Массив точек спавна
    public GameObject[] enemyPrefabs; // Массив префабов врагов
    public int maxWaves = 10; // Максимальное количество волн
    public int currentWave = 1; // Текущая волна
    public int Enemies = 0;
    private int enemiesPerWave = 3; // Начальное количество врагов в волне
    private float waveSpawnInterval = 12f; // Время между волнами
    private float enemySpawnInterval = 4f; // Время между спауном врагов
    private NavMeshAgent navMeshAgent;

    public List<List<GameObject>> enemyPools = new List<List<GameObject>>();
    public List<GameObject> LightEnemyPools;
    public List<GameObject> HeavyEnemyPools;
    public List<GameObject> ArcherEnemyPools; // Пулы врагов для каждого типа
    public GameDataSaver GameDataSaver;
    public GameObject ExitPortal;

    private void Start()
    {
        GameDataSaver = GameObject.FindGameObjectWithTag("GameDataSaver").GetComponent<GameDataSaver>();
        InitializePool();
        StartCoroutine(SpawnWaves());
    }

    public void InitializePool()
    {
        enemyPools.Add(ArcherEnemyPools);
        enemyPools.Add(HeavyEnemyPools);
        enemyPools.Add(LightEnemyPools);
    }
    private IEnumerator SpawnWaves()
    {
        while (currentWave <= maxWaves)
        {
            if (currentWave > maxWaves) // Добавьте это условие для остановки спавна после 10 волн
                break;

            int enemiesToSpawn = enemiesPerWave * currentWave;

            for (int i = 0; i < enemiesToSpawn; i++)
            {
                SpawnEnemy();
                yield return new WaitForSeconds(enemySpawnInterval);
            }
            GameDataSaver.WavesPassed = currentWave - 1;
            currentWave++;

            yield return new WaitForSeconds(waveSpawnInterval);
        }
    }

    private void SpawnEnemy()
    {
        int enemyTypeIndex = Random.Range(0, enemyPrefabs.Length);
        List<GameObject> enemyPool = enemyPools[enemyTypeIndex];

        if (enemyPool.Count > 0)
        {
            int randomIndex = Random.Range(0, enemyPool.Count);
            GameObject enemy = enemyPool[randomIndex];
            Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

            enemy.transform.position = spawnPoint.position;
            navMeshAgent = enemy.GetComponent<NavMeshAgent>();
            navMeshAgent.enabled = true;
            Enemies++;
            

            // Удаляем использованный объект из пула
            enemyPool.RemoveAt(randomIndex);
        }
        else
        {
            Debug.LogWarning("No available enemies in the pool for type " + enemyPrefabs[enemyTypeIndex].name);
        }
    }

    private void Update()
    {
        if (currentWave>10 && Enemies == 0)
        {
            ExitPortal.SetActive(true);
        }
    }
}

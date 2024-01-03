using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletBehaviour : MonoBehaviour
{
    public float BulletSpeed = 10f;
    private Transform player; // Ссылка на объект игрока
    private Vector3 bulletDirection;

    // Start is called before the first frame update
    void Start()
    {
        player = FindPlayer(); // Найдем игрока
        if (player)
        {
            bulletDirection = (player.position - transform.position).normalized;
        }
        else
        {
            // Если игрок не найден, двигайтесь в каком-то стандартном направлении (например, вперед)
            bulletDirection = Vector3.forward;
        }
    }

    void Update()
    {
        transform.position += bulletDirection * BulletSpeed * Time.deltaTime;
    }

    // Поиск игрока
    private Transform FindPlayer()
    {
        GameObject playerObject = GameObject.FindWithTag("Player"); // Поиск игрока по тегу "Player"
        if (playerObject)
        {
            return playerObject.transform; // Возвращаем трансформ игрока
        }
        return null; // Если игрок не найден, возвращаем null
    }
}

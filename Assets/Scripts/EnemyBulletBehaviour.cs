using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletBehaviour : MonoBehaviour
{
    public float BulletSpeed = 10f;
    private Transform player; // ������ �� ������ ������
    private Vector3 bulletDirection;

    // Start is called before the first frame update
    void Start()
    {
        player = FindPlayer(); // ������ ������
        if (player)
        {
            bulletDirection = (player.position - transform.position).normalized;
        }
        else
        {
            // ���� ����� �� ������, ���������� � �����-�� ����������� ����������� (��������, ������)
            bulletDirection = Vector3.forward;
        }
    }

    void Update()
    {
        transform.position += bulletDirection * BulletSpeed * Time.deltaTime;
    }

    // ����� ������
    private Transform FindPlayer()
    {
        GameObject playerObject = GameObject.FindWithTag("Player"); // ����� ������ �� ���� "Player"
        if (playerObject)
        {
            return playerObject.transform; // ���������� ��������� ������
        }
        return null; // ���� ����� �� ������, ���������� null
    }
}

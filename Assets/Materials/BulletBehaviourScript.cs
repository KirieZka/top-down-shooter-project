using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviourScript : MonoBehaviour
{
    public float BulletSpeed = 10f;
    private Transform GunDir;
    private Vector3 _bulletDirection;
    public GameDataSaver GameDataSaver;
    // Start is called before the first frame update
    void Start()
    {
        GameDataSaver = GameObject.FindGameObjectWithTag("GameDataSaver").GetComponent<GameDataSaver>();
        GunDir = GameObject.FindGameObjectWithTag("Player").transform;
        _bulletDirection = GunDir.forward;
        GameDataSaver.TotalShotsFired++;
    }
    void Update()
    {
        transform.position += _bulletDirection * BulletSpeed * Time.deltaTime;
    }
}

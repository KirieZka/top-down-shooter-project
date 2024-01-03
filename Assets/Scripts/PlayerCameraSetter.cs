using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraSetter : MonoBehaviour
{
    public CinemachineVirtualCamera virualCamera;
    public Transform playerTransform;
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        virualCamera.Follow = playerTransform;
    }
}

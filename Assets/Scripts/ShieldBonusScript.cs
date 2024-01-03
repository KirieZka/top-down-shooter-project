using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBonusScript : MonoBehaviour
{
    public BonusManagerScript BonusManager;
    public GameDataSaver GameDataSaver;
    public AK.Wwise.Event bonusPickupSound;


    private void Start()
    {
        GameDataSaver = GameObject.FindGameObjectWithTag("GameDataSaver").GetComponent<GameDataSaver>();
        BonusManager = GameObject.FindGameObjectWithTag("BonusManager").GetComponent<BonusManagerScript>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameDataSaver.BonusesUsed++;
            BonusManager.ArmorBonusState = true;
            BonusManager.ArmorBonusTimer += 10f;
            // ������������� ���� ������ � ��������� ������� ��������� �������
            bonusPickupSound.Post(gameObject, (uint)AkCallbackType.AK_EndOfEvent, OnSoundEndCallback);

            // ��������� ������ ������ � �����
            gameObject.SetActive(false);
        }
        
    }
    private void OnSoundEndCallback(object in_cookie, AkCallbackType in_type, object in_info)
    {
        // ����������� ��������������� �����, ������ ����� ���������� ������ ������
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManagerScript : MonoBehaviour
{
    public Sprite[] CharacterPortraits;
    public Image CharacterPortrait;
    public CharacterHealth Health;
    public Sprite[] AngryCharPortraits;
    public Image Healthbar;
    public Image BonusDamageImage;
    public Image BonusSpeedImage;
    public Image BonusShieldImage;
    public Image BonusWeaponImage;
    public Text AmmoText;
    public Text WavesText;
    public Text EnemiesText;

    public AK.Wwise.Event maleHurtEvent;
    public AK.Wwise.Event femaleHurtEvent;

    private BonusManagerScript _bonusManager;
    private CharNumScript _playerNum;
    private float _healthBefore;
    private UserInputData _userInputData;
    private EnemySpawner _enemySpawner;
    void Start()
    {
        _playerNum = GameObject.FindGameObjectWithTag("Player").GetComponent<CharNumScript>();
        _userInputData = GameObject.FindGameObjectWithTag("Player").GetComponent<UserInputData>();
        CharacterPortrait.sprite = CharacterPortraits[_playerNum.CharNum - 1];
        Health = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterHealth>();
        _healthBefore = Health.Health;
        _bonusManager = GameObject.FindGameObjectWithTag("BonusManager").GetComponent<BonusManagerScript>();
        _enemySpawner = GameObject.FindGameObjectWithTag("Spawner").GetComponent<EnemySpawner>();
        Healthbar.rectTransform.sizeDelta = new Vector2(_healthBefore * 5, 50);
    }

    void Update()
    {
        DamageTakenUIChecker();
        RageEmojiChecker();
        BonusStateChecker();
        AmmoCounter();
        WavesAndEnemiesCounter();
    }


    public void DamageTakenUIChecker()
    {
        if (_healthBefore != Health.Health)
        {
            if (_playerNum.CharNum == 1 || _playerNum.CharNum == 3)
            {
                maleHurtEvent.Post(_playerNum.gameObject);
            }
            if (_playerNum.CharNum == 2)
            {
                femaleHurtEvent.Post(_playerNum.gameObject);
            }
            Debug.Log("Damage accepted");
            CharacterPortrait.color = Color.red;
            _healthBefore = Health.Health;
            Healthbar.rectTransform.sizeDelta = new Vector2(_healthBefore * 5, 50);
        }
        else
        {
            CharacterPortrait.color = Color.white;
        }
    }

    public void RageEmojiChecker()
    {
        if (_bonusManager.DamageBonusState)
        {
            CharacterPortrait.sprite = AngryCharPortraits[_playerNum.CharNum - 1];
        } else { CharacterPortrait.sprite = CharacterPortraits[_playerNum.CharNum - 1]; }
    }

    public void BonusStateChecker()
    {
        if (_bonusManager.ArmorBonusState)
        {
            BonusShieldImage.enabled = true;
            BonusShieldImage.fillAmount = _bonusManager.ArmorBonusTimer/10;
        }
        if (_bonusManager.DamageBonusState)
        {
            BonusDamageImage.enabled = true;
            BonusDamageImage.fillAmount = _bonusManager.DamageBonusTimer / 10;
        }
        if (_bonusManager.SpeedBonusState)
        {
            BonusSpeedImage.enabled = true;
            BonusSpeedImage.fillAmount = _bonusManager.SpeedBonusTimer / 10;
        }
        if (_bonusManager.WeaponBonusState)
        {
            BonusWeaponImage.enabled = true;
            BonusWeaponImage.fillAmount = _bonusManager.WeaponBonusTimer / 10;
        }

    }

    public void AmmoCounter()
    {
        AmmoText.text = $"Ammo: {_userInputData.Ammo} / {_userInputData.MaxAmmo}";
    }

    public void WavesAndEnemiesCounter()
    {
        WavesText.text = $"Wave: {_enemySpawner.currentWave}";
        EnemiesText.text = $"Enemies remaining: {_enemySpawner.Enemies}";
    }

    public void EndGameChecker()
    {
        if (Health.Health <= 0)
        {
            SceneManager.LoadScene(2);
        }
    }
}

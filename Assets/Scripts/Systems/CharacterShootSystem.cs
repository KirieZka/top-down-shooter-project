using System.Collections.Generic;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public partial class CharacterShootSystem : ComponentSystem
{
    public AudioEvents audioEvents;
    public AK.Wwise.Event Shoot1Event;
    public AK.Wwise.Event Shoot2Event;
    public AK.Wwise.Event Shoot3Event;
    public CharNumScript charNum;
    public GameObject player;

    private EntityQuery _shootQuery;

    public Ability abilityBullet;

    private float _shootTime = 0;

    public bool Shoot;
    public List<GameObject> Targets { get; set; }

    protected override void OnCreate()
    {
        _shootQuery = GetEntityQuery(ComponentType.ReadOnly<InputData>(),
            ComponentType.ReadOnly<ShootData>(),
            ComponentType.ReadOnly<UserInputData>());
    }
    protected override void OnUpdate()
    {
        Entities.With(_shootQuery).ForEach(
                    (Entity entity, UserInputData userInputData, ref ShootData shootData,ref AnimData animData) =>
                    {
                        animData.Firing = false;
                        if (shootData.Shoot > 0f && userInputData.ShootAction != null && userInputData.ShootAction is IAbilityTarget ability)
                        {
                            if (UnityEngine.Time.time < _shootTime + shootData.ShootDelay) return;

                            _shootTime = UnityEngine.Time.time;
                            if (abilityBullet == null)
                            {
                                abilityBullet = GameObject.FindGameObjectWithTag("Player").GetComponent<Ability>();
                            }
                            if (charNum == null)
                            {
                                charNum = GameObject.FindGameObjectWithTag("Player").GetComponent<CharNumScript>();
                            }
                            if (player == null)
                            {
                                player = GameObject.FindGameObjectWithTag("Player");
                            }
                            if (audioEvents == null)
                            {
                                audioEvents = GameObject.FindGameObjectWithTag("Player").GetComponent<AudioEvents>();
                            }
                            if (Shoot1Event == null)
                            {
                                Shoot1Event = audioEvents.Shoot1Event;
                                Shoot2Event = audioEvents.Shoot2Event;
                                Shoot3Event = audioEvents.Shoot3Event;
                            }
                            if (abilityBullet.BulletPrefab != null && userInputData.Ammo > 0)
                            {
                                Shoot = true;
                                animData.Firing = true;
                                Transform t = abilityBullet.BulletSpawnPoint;
                                GameObject newBullet = Object.Instantiate(abilityBullet.BulletPrefab, t.position, t.rotation);

                                if (Shoot)
                                {
                                    if (charNum.CharNum == 1 && userInputData.Ammo > 0)
                                    {
                                        Shoot1Event.Post(player);
                                    }
                                    if (charNum.CharNum == 2 && userInputData.Ammo > 0)
                                    {
                                        Shoot2Event.Post(player);
                                    }
                                    if (charNum.CharNum == 3 && userInputData.Ammo > 0)
                                    {
                                        Shoot3Event.Post(player);
                                    }
                                }
                                userInputData.Ammo--;
                                Shoot = false;
                            }
                            else if (userInputData.Ammo == 0)
                            {

                            }
                            else { Debug.Log("NoBulletPref"); }
                        }
                    });
    }
}

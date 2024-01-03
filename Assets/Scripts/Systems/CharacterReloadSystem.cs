using System.Collections.Generic;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public partial class CharacterReloadSystem : ComponentSystem
{
    private EntityQuery _reloadQuery;

    private float _timer;
    private bool _reloadState;

    protected override void OnCreate()
    {
        _reloadQuery = GetEntityQuery(ComponentType.ReadOnly<InputData>(),
            ComponentType.ReadOnly<ReloadData>(),
            ComponentType.ReadOnly<ShootData>(),
            ComponentType.ReadOnly<UserInputData>());


    }
    protected override void OnUpdate()
    {
        Entities.With(_reloadQuery).ForEach(
                    ((Entity entity, UserInputData userInputData, ref ReloadData reloadData, ref ShootData shootData, ref AnimData animData) =>
                    {
                        if (reloadData.Reload > 0f)
                        { _reloadState = true; }
                        if (_reloadState)
                        {
                            animData.Reloading = true;
                            if (userInputData.Ammo == shootData.MaxAmmo) return;
                            _timer += Time.DeltaTime;
                            if (_timer >= reloadData.ReloadTime)
                            {
                                userInputData.Ammo = shootData.MaxAmmo;
                                animData.Reloading = false;
                                _timer = 0f;
                                _reloadState = false;
                            }
                        }
                    }));
    }
}

using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public class UserInputData : MonoBehaviour, IConvertGameObjectToEntity
{
    public float speed;
    public string moveAnimHash;
    public string moveAnimSpeedHash;

    public float ShootDelay = 1f;
    public int MaxAmmo = 8;
    public float ReloadTime = 2f;
    public int Ammo;

    public float Shoot;

    public Ability Ability;

    public MonoBehaviour ShootAction;

    private void Start()
    {
        Ammo = MaxAmmo;
    }
    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        
        dstManager.AddComponentData<InputData>(entity, new InputData());
        dstManager.AddComponentData<MoveData>(entity, new MoveData() { Speed = (speed * Ability.SpeedMult ) / 100 });
        if (ShootAction != null && ShootAction is IAbilityTarget)
        {
            dstManager.AddComponentData<ShootData>(entity, new ShootData() { ShootDelay = ShootDelay/Ability.WeaponSpeedMult, MaxAmmo = MaxAmmo, Ammo = MaxAmmo });
        }
        dstManager.AddComponentData<ReloadData>(entity, new ReloadData() { ReloadTime =  ReloadTime/Ability.WeaponReloadMult});
        if (moveAnimHash != string.Empty)
        {
            dstManager.AddComponentData(entity, new AnimData());
        }
    }
}

public struct CharacterData: IComponentData
{
    public InputData InputData;
    public MoveData MoveData;
    public ShootData ShootData;
    public ReloadData ReloadData;
}
public struct InputData : IComponentData
{
    public Vector2 Move;
    public Vector3 lookDirection;
    public Vector3 pos;


    //направления движения

}
public struct MoveData : IComponentData
{
    public float Speed;

}
public struct ShootData : IComponentData
{
    public float ShootDelay;
    public int MaxAmmo;
    public int Ammo;
    public float Shoot;
    
}



public struct ReloadData: IComponentData
{
    public float Reload;
    public float ReloadTime;
}

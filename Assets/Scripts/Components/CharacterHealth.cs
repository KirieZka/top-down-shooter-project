using Unity.Entities;
using UnityEngine;

public class CharacterHealth : MonoBehaviour, IComponentData
{
    public float MaxHealth;
    public float Armor;
    public float Health; // Здесь вы можете настроить значение здоровья в редакторе Unity
}
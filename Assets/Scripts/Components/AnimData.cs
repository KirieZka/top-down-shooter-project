using Unity.Entities;
using UnityEngine;

[GenerateAuthoringComponent]
public struct AnimData : IComponentData
{
    public bool Moving;
    public bool moveForward;
    public bool moveBackward;
    public bool moveLeft;
    public bool moveRight;
    public bool Reloading;
    public bool Firing;
    public bool Attacked;
    public bool Dead;
}
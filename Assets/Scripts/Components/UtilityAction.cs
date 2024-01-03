using Unity.Entities;

[GenerateAuthoringComponent]
public struct UtilityAction : IComponentData
{
    public ActionType Action;
}

public enum ActionType
{
    ApproachPlayer,
    FleeFromPlayer,
    Attack
}

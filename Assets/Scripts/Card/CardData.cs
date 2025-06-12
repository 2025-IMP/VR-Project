using UnityEngine;

public enum AbilityType
{
    RAILGUN_POWER,
    RAILGUN_BULLET,
    RAILGUN_EXPLOSION,
    RAILGUN_THROUGH,
    PASSIVE_POWER,
    PASSIVE_SPEED,
    PASSIVE_HEALTH,
    PASSIVE_PROTECT
}

[System.Serializable]
public class PowerUp
{
    [Multiline] public string Desc;
    public float Value;
}

[CreateAssetMenu(fileName = "CardData", menuName = "Scriptable Objects/CardData")]
public class CardData : ScriptableObject
{
    public AbilityType Type;
    public string Name;
    public Sprite Icon;
    public int MaxLevel;

    public PowerUp[] PowerUps;
}

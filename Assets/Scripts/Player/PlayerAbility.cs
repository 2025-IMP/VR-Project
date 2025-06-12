using System.Collections.Generic;

public partial class PlayerAbility
{
    private Player m_Player;

    private Dictionary<AbilityType, int> m_Abilities = new Dictionary<AbilityType, int>();
    public Dictionary<AbilityType, int> Abilities => m_Abilities;

    public PlayerAbility(Player player)
    {
        m_Player = player;
    }

    public void Initialize()
    {
        m_Abilities.Clear();
    }

    public void PowerUpAbility(AbilityType type)
    {
        switch (type)
        {
            case AbilityType.RAILGUN_POWER:
                PowerUpRailgunPower();
                break;
            case AbilityType.RAILGUN_BULLET:
                PowerUpRailgunBullet();
                break;
            case AbilityType.RAILGUN_EXPLOSION:
                PowerUpRailgunExplosion();
                break;
            case AbilityType.RAILGUN_THROUGH:
                PowerUpRailgunThrough();
                break;
            case AbilityType.PASSIVE_POWER:
                PowerUpPassivePower();
                break;
            case AbilityType.PASSIVE_SPEED:
                PowerUpPassiveSpeed();
                break;
            case AbilityType.PASSIVE_HEALTH:
                PowerUpPassiveHealth();
                break;
            case AbilityType.PASSIVE_PROTECT:
                PowerUpPassiveProtect();
                break;
        }
    }


}

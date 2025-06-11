using System.Linq;

public partial class PlayerAbility
{
    private void PowerUpRailgunPower()
    {
        if (!m_Abilities.ContainsKey(AbilityType.RAILGUN_POWER))
        {
            m_Abilities[AbilityType.RAILGUN_POWER] = 1;
        }
        else
        {
            m_Abilities[AbilityType.RAILGUN_POWER] += 1;
        }

        int level = m_Abilities[AbilityType.RAILGUN_POWER];
        PowerUp pu = AbilityManager.Instance.CardDataStorage.First(data => data.Type == AbilityType.RAILGUN_POWER).PowerUps[level - 1];

        m_Player.PowerUpRailgunPower(pu.Value);
    }

    private void PowerUpRailgunBullet()
    {
        if (!m_Abilities.ContainsKey(AbilityType.RAILGUN_BULLET))
        {
            m_Abilities[AbilityType.RAILGUN_BULLET] = 1;
        }
        else
        {
            m_Abilities[AbilityType.RAILGUN_BULLET] += 1;
        }

        int level = m_Abilities[AbilityType.RAILGUN_BULLET];
        PowerUp pu = AbilityManager.Instance.CardDataStorage.First(data => data.Type == AbilityType.RAILGUN_BULLET).PowerUps[level - 1];

        m_Player.PowerUpRailgunBullet((int)pu.Value);
    }

    private void PowerUpRailgunExplosion()
    {
        if (!m_Abilities.ContainsKey(AbilityType.RAILGUN_EXPLOSION))
        {
            m_Abilities[AbilityType.RAILGUN_EXPLOSION] = 1;
        }
        else
        {
            m_Abilities[AbilityType.RAILGUN_EXPLOSION] += 1;
        }

        int level = m_Abilities[AbilityType.RAILGUN_EXPLOSION];
        PowerUp pu = AbilityManager.Instance.CardDataStorage.First(data => data.Type == AbilityType.RAILGUN_EXPLOSION).PowerUps[level - 1];

        m_Player.PowerUpRailgunExplosion(pu.Value);
    }

    private void PowerUpRailgunThrough()
    {
        if (!m_Abilities.ContainsKey(AbilityType.RAILGUN_THROUGH))
        {
            m_Abilities[AbilityType.RAILGUN_THROUGH] = 1;
        }
        else
        {
            m_Abilities[AbilityType.RAILGUN_THROUGH] += 1;
        }

        int level = m_Abilities[AbilityType.RAILGUN_THROUGH];
        PowerUp pu = AbilityManager.Instance.CardDataStorage.First(data => data.Type == AbilityType.RAILGUN_THROUGH).PowerUps[level - 1];

        m_Player.PowerUpRailgunThrough((int)pu.Value);
    }

    private void PowerUpPassivePower()
    {
        if (!m_Abilities.ContainsKey(AbilityType.PASSIVE_POWER))
        {
            m_Abilities[AbilityType.PASSIVE_POWER] = 1;
        }
        else
        {
            m_Abilities[AbilityType.PASSIVE_POWER] += 1;
        }

        int level = m_Abilities[AbilityType.PASSIVE_POWER];
        PowerUp pu = AbilityManager.Instance.CardDataStorage.First(data => data.Type == AbilityType.PASSIVE_POWER).PowerUps[level - 1];

        m_Player.PowerUpPassivePower(pu.Value);
    }

    private void PowerUpPassiveSpeed()
    {
        if (!m_Abilities.ContainsKey(AbilityType.PASSIVE_SPEED))
        {
            m_Abilities[AbilityType.PASSIVE_SPEED] = 1;
        }
        else
        {
            m_Abilities[AbilityType.PASSIVE_SPEED] += 1;
        }

        int level = m_Abilities[AbilityType.PASSIVE_SPEED];
        PowerUp pu = AbilityManager.Instance.CardDataStorage.First(data => data.Type == AbilityType.PASSIVE_SPEED).PowerUps[level - 1];

        m_Player.PowerUpPassiveSpeed(pu.Value);
    }

    private void PowerUpPassiveHealth()
    {
        if (!m_Abilities.ContainsKey(AbilityType.PASSIVE_HEALTH))
        {
            m_Abilities[AbilityType.PASSIVE_HEALTH] = 1;
        }
        else
        {
            m_Abilities[AbilityType.PASSIVE_HEALTH] += 1;
        }

        int level = m_Abilities[AbilityType.PASSIVE_HEALTH];
        PowerUp pu = AbilityManager.Instance.CardDataStorage.First(data => data.Type == AbilityType.PASSIVE_HEALTH).PowerUps[level - 1];

        m_Player.PowerUpPassiveHealth(pu.Value);
    }

    private void PowerUpPassiveProtect()
    {
        if (!m_Abilities.ContainsKey(AbilityType.PASSIVE_PROTECT))
        {
            m_Abilities[AbilityType.PASSIVE_PROTECT] = 1;
        }
        else
        {
            m_Abilities[AbilityType.PASSIVE_PROTECT] += 1;
        }

        int level = m_Abilities[AbilityType.PASSIVE_PROTECT];
        PowerUp pu = AbilityManager.Instance.CardDataStorage.First(data => data.Type == AbilityType.PASSIVE_PROTECT).PowerUps[level - 1];

        m_Player.PowerUpPassiveProtect(pu.Value);
    }
}

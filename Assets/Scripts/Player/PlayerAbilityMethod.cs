using System.Linq;

public partial class PlayerAbility
{
    private void PowerUpRailgunPower()
    {
        if (!m_Abilities.ContainsKey(AbilityType.RAILGUN_POWER))
        {
            m_Abilities[AbilityType.RAILGUN_POWER] = 1;
        } else
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
        } else
        {
            m_Abilities[AbilityType.RAILGUN_BULLET] += 1;
        }

        int level = m_Abilities[AbilityType.RAILGUN_BULLET];
        PowerUp pu = AbilityManager.Instance.CardDataStorage.First(data => data.Type == AbilityType.RAILGUN_BULLET).PowerUps[level - 1];

        m_Player.PowerUpRailgunBullet((int)pu.Value);
    }
}

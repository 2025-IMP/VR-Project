using UnityEngine;

namespace IMP.Core
{
    public class HealStrategy : IDropItemStrategy
    {
        private DropItem m_DropItem;
        private int m_HealAmount = 30;

        public HealStrategy(DropItem dropItem)
        {
            m_DropItem = dropItem;
        }

        public void Execute(Player player)
        {
            PlayerHealth health = player.GetComponent<PlayerHealth>();
            if (health != null)
            {
                health.Heal(m_HealAmount);
                GameObject.Destroy(m_DropItem.gameObject);
            }
        }
    }
}

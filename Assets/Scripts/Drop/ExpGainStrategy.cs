using UnityEngine;

namespace IMP.Core
{
    public class ExpGainStrategy : IDropItemStrategy
    {
        private DropItem m_DropItem;

        private int m_ExpPoint = 1;

        public ExpGainStrategy(DropItem dropItem)
        {
            m_DropItem = dropItem;
        }

        public void Execute(Player player)
        {
            player.GainExp(m_ExpPoint);
            GameObject.Destroy(m_DropItem.gameObject);
        }
    }
}

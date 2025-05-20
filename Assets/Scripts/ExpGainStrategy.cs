using UnityEngine;

namespace IMP.Core
{
    public class ExpGainStrategy : IDropItemStrategy
    {
        private DropItem m_DropItem;

        [SerializeField] private float m_ExpPoint = 1f;

        public ExpGainStrategy(DropItem dropItem)
        {
            m_DropItem = dropItem;
        }

        public void Execute()
        {

        }
    }
}

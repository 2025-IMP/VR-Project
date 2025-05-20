using UnityEngine;

namespace IMP.Core
{
    public class MagnetStrategy : IDropItemStrategy
    {
        private DropItem m_DropItem;

        public MagnetStrategy(DropItem dropItem)
        {
            m_DropItem = dropItem;
        }

        public void Execute()
        {
        }
    }
}

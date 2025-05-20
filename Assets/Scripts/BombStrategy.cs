using UnityEngine;

namespace IMP.Core
{
    public class BombStrategy : IDropItemStrategy
    {
        private DropItem m_DropItem;

        [SerializeField] private float m_Radius = 10f;

        public BombStrategy(DropItem dropItem)
        {
            m_DropItem = dropItem;
        }

        public void Execute()
        {
            
        }
    }
}


using UnityEngine;

namespace IMP.Core
{
    public class DropItem : MonoBehaviour
    {
        [SerializeField] private bool m_AutoGained;

        private IDropItemStrategy m_ItemStrategy;

        public void SetStrategy(string type)
        {
            switch (type)
            {
                case "exp":
                    m_ItemStrategy = new ExpGainStrategy(this);
                    break;

                case "magnet":
                    m_ItemStrategy = new MagnetStrategy(this);
                    break;

                case "bomb":
                    m_ItemStrategy = new BombStrategy(this);
                    break;
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (m_AutoGained && collision.CompareTag("Player"))
            {
                m_ItemStrategy.Execute();
            }
        }
    }
}

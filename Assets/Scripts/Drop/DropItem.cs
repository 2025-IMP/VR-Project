using UnityEngine;

namespace IMP.Core
{
    public enum DropType
    {
        EXP,
        MAGNET,
        BOMB,
        HEAL
    }

    public class DropItem : MonoBehaviour
    {
        [SerializeField] private bool m_AutoGained;

        private IDropItemStrategy m_ItemStrategy;
        public IDropItemStrategy ItemStrategy => m_ItemStrategy;

        private void Start()
        {
            SetStrategy(DropType.EXP);
        }

        public void SetStrategy(DropType type)
        {
            switch (type)
            {
                case DropType.EXP:
                    m_ItemStrategy = new ExpGainStrategy(this);
                    break;

                case DropType.MAGNET:
                    m_ItemStrategy = new MagnetStrategy(this);
                    break;

                case DropType.BOMB:
                    m_ItemStrategy = new BombStrategy(this);
                    break;

                case DropType.HEAL:
                    m_ItemStrategy = new HealStrategy(this);
                    break;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (m_AutoGained && other.CompareTag("Player"))
            {
                AudioManager.Instance.PlayAudio(AudioType.SFX, AudioManager.Instance.itemGetSFX);

                Player player = other.GetComponent<Player>();
                m_ItemStrategy.Execute(player);
                Destroy(gameObject);
            }
        }
    }
}

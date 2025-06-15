using UnityEngine;

namespace TheDeveloperTrain.SciFiGuns
{
    public class Bullet : MonoBehaviour
    {
        private int damage = 1;
        private float speed = 60f;
        private float lifetime = 5f;

        private int throughCount = 0;

        void Start()
        {
            transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            Destroy(gameObject, lifetime);
        }

        void Update()
        {
            transform.Translate(speed * Time.deltaTime * Vector3.forward, Space.Self);
        }

        protected virtual void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Enemy" && other.TryGetComponent(out EnemyController enemy))
            {
                if (enemy.IsDead) return;

                enemy.TakeDamage((int)((float)RailGun.Instance.Damage * Player.PlayerInstance.PowerRatio * RailGun.Instance.PowerRatio));
                throughCount += 1;

                if (throughCount >= RailGun.Instance.BulletThroughCount)
                {
                    Destroy(gameObject);
                }
            }
        }

        public void Setup(int damage, float speed)
        {
            this.damage = damage;
            this.speed = speed;
        }
    }
}
using UnityEngine;

namespace TheDeveloperTrain.SciFiGuns
{
    public class Bullet : MonoBehaviour
    {
        private int damage = 1;
        private float speed = 60f;
        private float lifetime = 5f;

        void Start()
        {
            transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            Destroy(gameObject, lifetime);
        }

        void Update()
        {
            transform.Translate(speed * Time.deltaTime * Vector3.forward, Space.Self);
        }

        void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Enemy")
            {
                other.GetComponent<EnemyController>().TakeDamage(damage);
            }
        }

        public void Setup(int damage, float speed)
        {
            this.damage = damage;
            this.speed = speed;
        }
    }
}
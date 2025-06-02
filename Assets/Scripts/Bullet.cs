using UnityEngine;

namespace TheDeveloperTrain.SciFiGuns
{
    public class Bullet : MonoBehaviour
    {
        [HideInInspector]
        private float speed = 60.0f;
        void Start()
        {
            transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            Destroy(gameObject, 2f);
        }

        // Update is called once per frame
        void Update()
        {

            transform.Translate(speed * Time.deltaTime * Vector3.forward, Space.Self);
        }

        void OnDestroy()
        {
            Instantiate(ExplosionSingletone.Instance.GetExplosion(), transform.position, transform.rotation);
        }
        void OnTriggerEnter(Collider other)
        {
            Debug.Log("E");
            if (other.tag != "Weapon")
            {
                if (other.tag == "Enemy")
                {
                    Debug.Log("Enemy");
                    other.GetComponent<EnemyController>().TakeDamage(1);
                }
                else
                {
                    Debug.Log("Else");
                    Destroy(gameObject, 0.0f);
                }
            }
        }
    }
}
using UnityEngine;

namespace TheDeveloperTrain.SciFiGuns
{

    public class Bullet : MonoBehaviour
    {
        [HideInInspector]
        public float speed = 1.0f;
        void Start()
        {
            transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            Destroy(gameObject, 5f);
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
    }
}
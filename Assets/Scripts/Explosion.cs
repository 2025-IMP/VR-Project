using UnityEngine;

public class Explosion : MonoBehaviour
{
    void Start()
    {
        Invoke("DestroySelf", 1f);
    }
    void DestroySelf()
    {
        Destroy(gameObject);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Weapon")
        {
            Debug.Log("Explosion");
            if (other.tag == "Enemy")
            {
                other.GetComponent<EnemyController>().TakeDamage(1);
            }
        }
    }
}

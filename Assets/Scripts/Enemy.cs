using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int hp = 30;
    public float speed = 1.2f;

    Transform target;

    void Start() { target = Camera.main.transform; }

    void Update()
    {
        Vector3 dir = (target.position - transform.position).normalized;
        transform.position += dir * speed * Time.deltaTime;
        transform.LookAt(target);
    }

    public void TakeDamage(int dmg)
    {
        hp -= dmg;
        if (hp <= 0) { Destroy(gameObject); }
    }
}

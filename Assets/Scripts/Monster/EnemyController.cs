/*

Lee DongHun -> PlayerHealth 연동을 위해 관련 코드 추가.

*/

using UnityEngine;
using UnityEngine.UI;

public enum EnemyType { Normal, Bomb, Flying }

public class EnemyController : MonoBehaviour
{
    private ITraceStrategy strategy;
    private Transform playerTransform;
    private Animator animator;
    private PlayerHealth playerHP; // donghun

    public EnemyType enemyType;
    public float moveSpeed = 2f;

    public int maxHealth;
    private int currentHealth;

    public Slider healthBar;

    private bool isDead = false;

    // donghun
    public int damage = 10;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();

        // 타입에 따라 체력 다르게 설정
        switch (enemyType)
        {
            case EnemyType.Normal:
                maxHealth = 3;
                break;
            case EnemyType.Bomb:
                maxHealth = 1;
                break;
            case EnemyType.Flying:
                maxHealth = 5;
                break;
        }

        currentHealth = maxHealth;

        if (healthBar != null)
        {
            healthBar.maxValue = maxHealth;
            healthBar.value = currentHealth;
        }

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerTransform = player.transform;
            playerHP = player.GetComponent<PlayerHealth>(); //donghun
        }
        
        switch (enemyType)
        {
            case EnemyType.Normal:
                strategy = new TraceNormalStrategy();
                break;
            case EnemyType.Bomb:
                strategy = new TraceBombStrategy();
                break;
            case EnemyType.Flying:
                strategy = new TraceFlyingStrategy();
                break;
        }
        }

        void Update()
        {
            if (isDead) return;

            if (playerTransform != null && strategy != null)
            {
                Vector3 direction = (playerTransform.position - transform.position).normalized;
                direction.y = 0;

                if (direction.magnitude > 0.01f)
                {
                    Quaternion toRotation = Quaternion.LookRotation(direction);
                    transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, Time.deltaTime * 5f);
                }

                strategy.Trace(transform, playerTransform, moveSpeed);
            }
        }

        void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                if (playerHP != null)
                {
                    playerHP.TakeDamage(damage);
                }
                TakeDamage(1);
            }
        }

        void TakeDamage(int amount)
        {
            if (isDead) return;

            currentHealth -= amount;
            if (healthBar != null)
            {
                healthBar.value = currentHealth;
            }

            if (currentHealth <= 0)
            {
                Die();
            }
        }

        void Die()
        {
            if (isDead) return;
            isDead = true;

            if (animator != null)
            {
                animator.SetTrigger("Death");
            }

            Destroy(gameObject, 2f);
        }
    }

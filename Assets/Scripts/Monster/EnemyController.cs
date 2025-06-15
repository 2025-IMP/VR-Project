using UnityEngine;
using UnityEngine.UI;
using IMP.Core;

public enum EnemyType { Normal, Bomb, Flying }

[System.Serializable]
public class DropPrefabEntry
{
    public DropType type;
    public GameObject prefab;
}

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
    public bool IsDead => isDead;

    // donghun
    public int damage = 10;

    [SerializeField] private DropPrefabEntry[] dropPrefabs;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();

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
        if (isDead) return;

        if (other.CompareTag("Player"))
        {
            if (playerHP != null)
            {
                playerHP.TakeDamage(damage);
            }
            TakeDamage(1);
        }
    }

    public void TakeDamage(int amount)
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

        AudioManager.Instance.PlayAudio(AudioType.SFX, AudioManager.Instance.monsterDieSFX);

        DropRandomItem();

        Destroy(gameObject, 2f);
        DropHandler.OnEnemyDead?.Invoke(transform);
    }

    private void DropRandomItem()
    {
        int dropCount = Random.Range(3, 5);

        for (int i = 0; i < dropCount; i++)
        {
            DropType dropType = DropHelper.GetRandomDropType();
            GameObject selectedPrefab = null;

            foreach (var entry in dropPrefabs)
            {
                if (entry.type == dropType)
                {
                    selectedPrefab = entry.prefab;
                    break;
                }
            }

            if (selectedPrefab == null) continue;

            Vector3 dropPos = transform.position + Random.insideUnitSphere * 0.5f;
            dropPos.y = transform.position.y;

            GameObject drop = Instantiate(selectedPrefab, dropPos, Quaternion.identity);
            DropItem dropItem = drop.GetComponent<DropItem>();
            dropItem.SetStrategy(dropType);
        }
    }
}

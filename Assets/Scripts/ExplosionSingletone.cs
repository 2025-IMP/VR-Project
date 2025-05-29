using UnityEngine;

public class ExplosionSingletone : MonoBehaviour
{
    public static ExplosionSingletone Instance { get; private set; }
    [SerializeField] GameObject explosion;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public GameObject GetExplosion()
    {
        return explosion;
    }
}

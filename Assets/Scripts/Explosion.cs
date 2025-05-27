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
}

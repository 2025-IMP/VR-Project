using UnityEngine;

public class EnemySpawnPoint : MonoBehaviour
{
    private bool m_Spawnable = true;

    public bool CanSpawn()
    {
        return m_Spawnable;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            m_Spawnable = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            m_Spawnable = true;
        }
    }
}

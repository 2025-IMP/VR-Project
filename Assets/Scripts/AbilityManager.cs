using UnityEngine;

public class AbilityManager : MonoBehaviour
{
    private static AbilityManager s_Instance;
    public static AbilityManager Instance => s_Instance;

    [SerializeField] private CardData[] m_CardDataStorage;
    public CardData[] CardDataStorage => m_CardDataStorage;

    private void Awake()
    {
        if (s_Instance != null && s_Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            s_Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}

using System.Collections;
using UnityEngine;

public class Game : MonoBehaviour
{
    private Player m_Player;
    private EnemySpawner m_Spawner;

    [SerializeField] private EndPanel m_EndPanel;

    private float m_ElapsedTime = 0f;

    private void Awake()
    {
        m_Player = FindAnyObjectByType<Player>();
        m_Spawner = FindAnyObjectByType<EnemySpawner>();

        m_EndPanel.gameObject.SetActive(false);
        m_ElapsedTime = 0f;
    }

    private void Start()
    {
        AudioManager.Instance.PlayAudio(AudioType.BGM, AudioManager.Instance.inGameBGM);
        StartCoroutine(EnemySpawnCoroutine());
    }

    private void Update()
    {
        m_ElapsedTime += Time.deltaTime;
    }

    public IEnumerator EnemySpawnCoroutine()
    {
        int spawnCount = 5;

        while (true)
        {
            for (int i = 0; i < spawnCount; i++)
            {
                m_Spawner.Spawn(EnemyType.Normal);
                yield return null;
            }

            yield return new WaitForSeconds(3f);
        }
    }

    public void OnGameOver()
    {
        m_EndPanel.gameObject.SetActive(true);
        m_EndPanel.Show(m_ElapsedTime);
    }
}

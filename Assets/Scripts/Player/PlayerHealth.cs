/*
Lee DongHun
*/

using UnityEngine;
using UnityEngine.Events;   // ➜ Game-Over UI 호출용
using UnityEngine.UI;       // ➜ HP 바(Slider) 갱신용
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    [Header("Stats")]
    public int maxHP = 100;
    public float invincibleTime = 0.5f;   // 피격 후 무적시간

    [Header("UI References")]
    public Slider hpBar;          // Inspector에 HP 슬라이더(선택)
    public UnityEvent onGameOver;   // Game-Over Canvas ▸ Show() 묶기

    int currentHP;
    bool invincible;
    bool isDead;

    void Start()
    {
        currentHP = maxHP;
        if (hpBar)
        {
            hpBar.maxValue = maxHP;
            hpBar.value = currentHP;
        }
    }

    /* EnemyController가 호출하는 공개 메서드 */
    public void TakeDamage(int dmg)
    {
        if (isDead || invincible) return;

        currentHP -= dmg;
        if (hpBar) hpBar.value = currentHP;

        if (currentHP <= 0)
        {
            Die();
        }
        else
        {
            StartCoroutine(IFrames());
        }
    }

    public void Heal(int amount)
    {
        if (isDead) return; // 사망 상태면 회복 불가

        currentHP = Mathf.Min(currentHP + amount, maxHP); // 최대 체력 초과 방지

        if (hpBar) hpBar.value = currentHP; // UI 갱신
    } // CHAEWON

    IEnumerator IFrames()          // 잠깐 무적(핏박스 연속충돌 방지)
    {
        invincible = true;
        yield return new WaitForSeconds(invincibleTime);
        invincible = false;
    }

    /* 사망 처리 */
    void Die()
    {
        if (isDead) return;
        isDead = true;

        onGameOver?.Invoke();      // UI 열기
        Time.timeScale = 0f;       // 게임 정지
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    [Header("Boss health things")]
    public float bossHealth = 100f;
    public float bossPresentHealth;

    public UIBossHealth uIBossHealth;
    private HandleGameOver handleGameOver;

    private void Awake()
    {
        uIBossHealth = FindObjectOfType<UIBossHealth>();
        handleGameOver = FindObjectOfType<HandleGameOver>();
    }

    private void Start()
    {
        bossPresentHealth = bossHealth;
        if(uIBossHealth != null)
        {
            uIBossHealth.InitBossHealth(bossPresentHealth);
        }
    }

    public void BossHitDamage(float takeDamge)
    {
        bossPresentHealth -= takeDamge;
        if (uIBossHealth != null)
        {
            uIBossHealth.ReduceBossHealth(takeDamge);
            uIBossHealth.UpdateBossHealthIndex(bossHealth);
        }
        if (bossPresentHealth <= 0)
        {
            BossDie();
            handleGameOver.VictoryGame(bossPresentHealth);
        }
    }

    private void BossDie()
    {
        Destroy(gameObject, 0.3f);
        if(uIBossHealth != null)
        {
            uIBossHealth.gameObject.SetActive(false);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    [Header("Enemy health things")]
    public float enemyHealth = 100f;
    public float enemyPresentHealth;

    public UIEnemyHealth uIEnemyHealth;

    private void Start()
    {
        enemyPresentHealth = enemyHealth;
        uIEnemyHealth.InitEnemyHealth(enemyPresentHealth);
    }

    public void EnemyHitDamage(float takeDamge)
    {
        enemyPresentHealth -= takeDamge;
        uIEnemyHealth.ReduceEnemyHealth(takeDamge);

        if (enemyPresentHealth <= 0)
        {
            EnemyDie();
        }
    }

    private void EnemyDie()
    {
        Destroy(gameObject, 0.3f);
    }
}

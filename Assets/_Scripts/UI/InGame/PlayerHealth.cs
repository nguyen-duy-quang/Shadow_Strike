using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Header("Player health things")]
    private float playerHealth = 200f;
    public float presentHealth;

    public UIPlayerHealth uIPlayerHealth;

    public HandleGameOver handleGameOver;

    private void Start()
    {
        presentHealth = playerHealth;
    }

    public void playerHitDamage(float takeDamge)
    {
        presentHealth -= takeDamge;
        uIPlayerHealth.ReducePlayerHealth(takeDamge);

        if (presentHealth <= 0)
        {
            PlayerDie();
        }
    }

    private void PlayerDie()
    {
        Destroy(gameObject, 1.0f);
        handleGameOver.DefeatGame();
    }
}

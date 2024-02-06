using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIEnemyHealth : MonoBehaviour
{
    public Slider health;

    public void InitEnemyHealth(float enemyPresentHealth)
    {
        health.maxValue = enemyPresentHealth;
        health.value = enemyPresentHealth;
        health.minValue = 0f;
    }    

    public void ReduceEnemyHealth(float takeDamge)
    {
        health.value -= takeDamge;
    }
}

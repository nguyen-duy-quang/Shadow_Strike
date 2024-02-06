using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIPlayerHealth : MonoBehaviour
{
    public Slider health;
    public TextMeshProUGUI textPlayerHealth;

    private float presentHealth;

    public PlayerHealth playerHealth;

    private void Start()
    {
        health.maxValue = playerHealth.presentHealth;
        health.value = playerHealth.presentHealth;
        health.minValue = 0f;

        presentHealth = playerHealth.presentHealth;
        InitHealth();
    }

    public void InitHealth()
    {
        textPlayerHealth.text = playerHealth.presentHealth.ToString() + "/" + playerHealth.presentHealth.ToString();
    }

    public void ReducePlayerHealth(float takeDamge)
    {
        health.value -= takeDamge;
        UpdateHealthIndex();
    }

    public void UpdateHealthIndex()
    {
        textPlayerHealth.text = health.value.ToString() + "/" + presentHealth;
    }
}

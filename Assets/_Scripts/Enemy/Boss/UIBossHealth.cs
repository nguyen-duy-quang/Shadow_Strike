using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIBossHealth : MonoBehaviour
{
    public Slider health;
    public TextMeshProUGUI bossHealthText;

    public void InitBossHealth(float bossPresentHealth)
    {
        health.maxValue = bossPresentHealth;
        health.value = bossPresentHealth;
        health.minValue = 0f;

        InitBossHealthText(bossPresentHealth);
    }

    public void InitBossHealthText(float bossPresentHealth)
    {
        bossHealthText.text = bossPresentHealth.ToString() + "/" + bossPresentHealth.ToString();
    }

    public void ReduceBossHealth(float takeDamge)
    {
        health.value -= takeDamge;
    }

    public void UpdateBossHealthIndex(float bossPresentHealth)
    {
        bossHealthText.text = health.value.ToString() + "/" + bossPresentHealth;
    }
}

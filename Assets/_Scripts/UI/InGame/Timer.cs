using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float timeInSeconds = 300;
    private float bossAppearanceTime;
    private bool bossSpawned = false;

    public TextMeshProUGUI textTime;

    public Transform bossIndex;
    public GameObject bossHealthSlider;
    public GameObject boss;

    private GameManager gameManager;
    public HandleGameOver handleGameOver;
    public TextEffect textEffect;

    private void Start()
    {
        bossAppearanceTime = timeInSeconds / 3;
        gameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        if (timeInSeconds > 0)
        {
            // Giảm thời gian đi 1 giây mỗi frame
            timeInSeconds -= Time.deltaTime;

            // Hiển thị thời gian dưới dạng phút và giây
            TimeSpan timeSpan = TimeSpan.FromSeconds(timeInSeconds);
            string formattedTime = string.Format("{0:D2}:{1:D2}", timeSpan.Minutes, timeSpan.Seconds);

            textTime.text = formattedTime;

            if (!bossSpawned && timeInSeconds <= bossAppearanceTime)
            {
                // Tạo ra boss nếu chưa tạo và có thể tạo enemy
                if (gameManager.CanSpawnEnemy)
                {
                    Instantiate(boss, bossIndex.position, transform.rotation);
                    bossSpawned = true; // Đánh dấu rằng boss đã được tạo
                    bossHealthSlider.SetActive(true);
                    gameManager.SetCanSpawnEnemy(false); // Ngừng tạo enemy
                    textEffect.ShowBossText();
                }
            }
        }
        else
        {
            // Thời gian đã hết
            handleGameOver.DefeatGame();
        }
    }
}

using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionGuide : MonoBehaviour
{
    public Button close;

    public GameManager gameManager;

    public GameMenuBase gameMenuBase;

    private void Start()
    {
        close.onClick.AddListener(CloseMissionGuide);

        StartCoroutine(ActivateMissionGuideAfterDelay());

        gameMenuBase.SetMenuIntroVisible(true);
    }

    private void CloseMissionGuide()
    {
        gameObject.SetActive(false);
        gameManager.ResumeGame();

        gameMenuBase.SetMenuIntroVisible(false);
        AudioManager._instance.ButtonClickSound();
    }

    IEnumerator ActivateMissionGuideAfterDelay()
    {
        // Tạm dừng trong 10 giây (thời gian thực)
        float pauseEndTime = Time.realtimeSinceStartup + 10f;
        while (Time.realtimeSinceStartup < pauseEndTime)
        {
            yield return null;
        }

        gameManager.ResumeGame(); // Đặt lại timeScale để kích hoạt lại hoạt động trong game
        gameMenuBase.SetMenuIntroVisible(false);
        gameObject.SetActive(false);
    }
}

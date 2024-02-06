using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Instruct : MonoBehaviour
{
    public Button close;
    public GameObject missionGuide;

    public GameManager gameManager;

    public GameMenuBase gameMenuBase;

    private void Start()
    {
        close.onClick.AddListener(CloseInstruct);

        gameManager.PauseGame();
        StartCoroutine(ActivateInstructAfterDelay());

        gameMenuBase.SetMenuIntroVisible(true);
    }

    private void CloseInstruct()
    {
        gameObject.SetActive(false);
        missionGuide.SetActive(true);
        AudioManager._instance.ButtonClickSound();
    }

    IEnumerator ActivateInstructAfterDelay()
    {
        // Tạm dừng trong 10 giây (thời gian thực)
        float pauseEndTime = Time.realtimeSinceStartup + 10f;
        while (Time.realtimeSinceStartup < pauseEndTime)
        {
            yield return null;
        }

        gameObject.SetActive(false);
        missionGuide.SetActive(true);
    }
}

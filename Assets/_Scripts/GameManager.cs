using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool canSpawnEnemy = true;

    public GameObject introduction;
    public GameObject settings;

    public Weapon weapon;

    private void Start()
    {
        if(introduction != null)
        {
            introduction.SetActive(true);
        }
    }

    public bool CanSpawnEnemy
    {
        get { return canSpawnEnemy; }
    }

    public void SetCanSpawnEnemy(bool value)
    {
        canSpawnEnemy = value;
    }

    // Khóa con trỏ chuột
    public void LockCursor()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Mở con trỏ chuột
    public void UnlockCursor()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void SwitchGameScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void OpenSettings()
    {
        settings.SetActive(true);
        AudioManager._instance.ButtonClickSound();
    }    

    public void PauseGame()
    {
        Time.timeScale = 0;
        if(weapon != null)
        {
            weapon.enabled = false;
        }
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
        if (weapon != null)
        {
            weapon.enabled = true;
        }
        AudioManager._instance.ButtonClickSound();
    }

    public void QuitGame()
    {
        Application.Quit();
        AudioManager._instance.ButtonClickSound();
    }
}

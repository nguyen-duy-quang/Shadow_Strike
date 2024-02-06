using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenuBase : MonoBehaviour, IGameMenu
{
    [SerializeField] protected GameManager gameManager;
    [SerializeField] protected string homeScene;
    [SerializeField] protected string currentScene;
    [SerializeField] protected string levelMenuScene;

    protected int keyPressCount = 0;
    [SerializeField] protected GameObject pauseMenu;

    // Thêm biến để kiểm tra trạng thái của menu
    private bool isMenuVisible = false;

    // Trong GameMenuBase
    private bool isMenuIntroVisible = false;

    private void Update()
    {
        // Kiểm tra nếu phím P được nhấn
        if (Input.GetKeyDown(KeyCode.P))
        {
            keyPressCount++;

            bool isPause = keyPressCount % 2 == 1;

            // Kiểm tra xem trạng thái menu đã thay đổi hay chưa và menu mua item không hiển thị
            if (isPause != isMenuVisible && !isMenuIntroVisible)
            {
                TogglePauseMenu(isPause);
            }
        }
    }

    // Thêm một phương thức để cập nhật trạng thái của menu mua item
    public void SetMenuIntroVisible(bool isVisible)
    {
        isMenuIntroVisible = isVisible;
    }

    private void TogglePauseMenu(bool isPause)
    {
        if (isPause)
        {
            Pause();
        }
        else
        {
            gameManager.ResumeGame();
            //gameManager.LockCursor();
            pauseMenu.SetActive(false);
        }

        // Cập nhật trạng thái của biến isMenuVisible
        isMenuVisible = pauseMenu.activeSelf; // Sử dụng trạng thái thực tế của pauseMenu
    }

    public void Pause()
    {
        gameManager.PauseGame();
        //gameManager.UnlockCursor();
        pauseMenu.SetActive(true);
    }

    public void ClickResume()
    {
        // Khi click vào nút Resume, ẩn menu
        TogglePauseMenu(false);
        AudioManager._instance.ButtonClickSound();
    }

    public void ClickHome()
    {
        gameManager.SwitchGameScene(homeScene);
        gameManager.ResumeGame();
        AudioManager._instance.ButtonClickSound();
    }

    public void ClickRestart()
    {
        gameManager.SwitchGameScene(currentScene);
        gameManager.ResumeGame();
        AudioManager._instance.ButtonClickSound();
    }

    public void ClickLevelMenu()
    {
        gameManager.SwitchGameScene(levelMenuScene);
        gameManager.ResumeGame();
        AudioManager._instance.ButtonClickSound();
    }    
}

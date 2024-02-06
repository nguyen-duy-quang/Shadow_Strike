using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseGame : GameMenuBase
{
    public Button levelMenu;
    public Button resume;
    public Button settings;
    public Button close;

    private void Start()
    {
        levelMenu.onClick.AddListener(ClickLevelMenu);
        resume.onClick.AddListener(ClickResume);
        settings.onClick.AddListener(gameManager.OpenSettings);
        close.onClick.AddListener(ClosePauseMenu);
    }

    private void ClosePauseMenu()
    {
        gameObject.SetActive(false);
    }    
}

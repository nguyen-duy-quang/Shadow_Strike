using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Victory : GameMenuBase
{
    public Button home;
    public Button restart;
    public Button nextLevel;

    public string sceneName;

    public CheckLevel checkLevel;

    private void Start()
    {
        AudioManager._instance.VictorySound();

        home.onClick.AddListener(ClickHome);
        restart.onClick.AddListener(ClickRestart);
        nextLevel.onClick.AddListener(NextLevel);
    }

    private void NextLevel()
    {
        if(checkLevel != null)
        {
            if (checkLevel.isOpenLevel)
            {
                gameManager.SwitchGameScene(sceneName);
            }
        }    
    }    
}

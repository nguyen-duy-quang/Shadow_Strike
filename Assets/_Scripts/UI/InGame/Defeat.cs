using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Defeat : GameMenuBase
{
    public Button levelMenu;
    public Button restart;
    public Button home;

    private void Start()
    {
        AudioManager._instance.DefeatSound();

        levelMenu.onClick.AddListener(ClickLevelMenu);
        restart.onClick.AddListener(ClickRestart);
        home.onClick.AddListener(ClickHome);
    }
}

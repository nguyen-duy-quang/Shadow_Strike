using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelMenuController : MonoBehaviour
{
    public GameManager gameManager;

    public Button home;
    public Button settings;

    public string sceneHome;

    public SaveCheckLevel saveCheckLevel;

    private void Start()
    {
        saveCheckLevel.LoadData();

        home.onClick.AddListener(HomeScene);
        settings.onClick.AddListener(gameManager.OpenSettings);
    }

    private void HomeScene()
    {
        gameManager.SwitchGameScene(sceneHome);
        AudioManager._instance.ButtonClickSound();
    }    
}

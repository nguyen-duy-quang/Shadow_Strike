using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public string sceneName;

    public Button play;
    public Button settings;
    public Button quit;

    public GameManager gameManager;

    private void Start()
    {
        play.onClick.AddListener(Play);
        settings.onClick.AddListener(gameManager.OpenSettings);
        quit.onClick.AddListener(gameManager.QuitGame);
    }

    private void Play()
    {
        gameManager.SwitchGameScene(sceneName);
        AudioManager._instance.ButtonClickSound();
    }    
}

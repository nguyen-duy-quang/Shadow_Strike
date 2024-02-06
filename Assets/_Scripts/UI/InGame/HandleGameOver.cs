using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleGameOver : MonoBehaviour
{
    public Timer timer;
    public GameManager gameManager;

    public GameObject player;
    public GameObject victoryMenu;
    public GameObject defeatMenu;
    public GameObject[] enemies;

    public CheckLevel checkLevel;
    public SaveCheckLevel saveCheckLevel;

    public void VictoryGame(float bossHealth)
    {
        if (timer.timeInSeconds > 0 && bossHealth <= 0)
        {
            victoryMenu.SetActive(true);
            foreach (GameObject enemy in enemies)
            {
                enemy.SetActive(false);
            }
            gameManager.PauseGame();

            if(checkLevel != null)
            {
                checkLevel.isOpenLevel = true;
                if(saveCheckLevel != null)
                {
                    saveCheckLevel.SaveData();
                }    
            }
        }    
    }    

    public void DefeatGame()
    {
        if (player != null)
        {
            Destroy(player);
        }
        defeatMenu.SetActive(true);

    }    
}

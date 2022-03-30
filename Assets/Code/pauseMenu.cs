using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class pauseMenu : MonoBehaviour
{
    public GameObject ui;

    public string menuScenename = "MainMenu";

    public ScenesFader scene;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P)){
            Toggle();
            Debug.Log("pause");
        }
    }
    public void Toggle()
    {
        ui.SetActive(!ui.activeSelf);

        if (ui.activeSelf)
        {
            Time.timeScale = 0f;

        }
        else
        {
            Time.timeScale = 1f;
        }
    }
    public void Retry()
    {
        
        Toggle();
        reload();
        Debug.Log("retry");
        scene.FadeTo(SceneManager.GetActiveScene().name);     
        // reset data man choi

    }
    public void Menu()
    {
        Toggle();
        Debug.Log("Menu");
        scene.FadeTo(menuScenename);
        waySpawn.EnemiesAlives = 0;
        reload();
    }
     void reload()
     {
        
        waySpawn.wayIndex = waySpawn.starwayIndex;
        PlayerStart.Rounds = PlayerStart.startRounds;
        PlayerStart.Money = PlayerStart.startMoney;
     }
}

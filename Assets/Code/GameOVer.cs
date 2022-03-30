using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameOVer : MonoBehaviour
{

    public string menuScenename = "MainMenu";

    public ScenesFader scene;
 
    public void Retry()
    {
        scene.FadeTo(SceneManager.GetActiveScene().name);

        reload();
    }
    public void Menu()
    {
        scene.FadeTo(menuScenename);

        reload();
    }

    void reload()
    {
        waySpawn.wayIndex = waySpawn.starwayIndex;
        PlayerStart.Rounds = PlayerStart.startRounds;
        PlayerStart.Money = PlayerStart.startMoney;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class completelevel : MonoBehaviour
{
    public string menuScenename = "MainMenu";
    public ScenesFader scenes;
    public string nextLevel = "Level2";

    public int levelUnlock = 2;

    public ScenesFader scene;

    public void Continue()
    {


        if (PlayerPrefs.GetInt("levelReached") <= levelUnlock)
        {
            PlayerPrefs.SetInt("levelReached", levelUnlock);
        }

        scene.FadeTo(nextLevel);
        reload();
    }
    public void Menu()
    {
        scene.FadeTo(menuScenename);
    }

    void reload()
    {
        waySpawn.wayIndex = waySpawn.starwayIndex;
        PlayerStart.Rounds = PlayerStart.startRounds;
        PlayerStart.Money = PlayerStart.startMoney;
    }
}

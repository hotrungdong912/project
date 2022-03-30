using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class levelselector : MonoBehaviour
{
    public ScenesFader scenes;

    public Button[] levelButton;

    public Button backButton;
    void Start()
    {
        
        int levelReached = PlayerPrefs.GetInt("levelReached", 1);

        for (int i = 0; i < levelButton.Length; i++)
        {
            if(i+1 > levelReached)
            {
                levelButton[i].interactable = false;
            }
            else
            {
                levelButton[i].interactable = true;
            }    
        }
    }
    public void Select(string levelName)
    {
        scenes.FadeTo(levelName);
    }
}

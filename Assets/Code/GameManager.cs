 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GameManager : MonoBehaviour
{
    public static bool GameIsOver = false;

    public GameObject gameOverUI;

    public GameObject completeLevelUI;

    public ScenesFader scenes;

    public static main main;
    public static GameManager mangager;
    void Start()
    {
        GameIsOver = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (GameIsOver)
        {
            return;
        }
        if (Input.GetKeyDown("e"))
        {
            winLevel();
        }
        if (Input.GetKeyDown("b"))
        {
            PlayerPrefs.DeleteKey("levelReached");
        }
        if (PlayerStart.Lives <= 0)
        {
            End();

        }
        
    }
        void End()
        {
            GameIsOver = true;

            gameOverUI.SetActive(true);
        }
        public void winLevel()
        {
            if (!GameIsOver)
            {
                StartCoroutine(login.instans.main.Savepoint(PlayerStart.point));
                GameIsOver = true;
                completeLevelUI.SetActive(true);
            }

        } 
    
    
}

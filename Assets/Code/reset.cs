using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class reset : MonoBehaviour
{
    public void butoneset()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("LevelScenes");
    }
}

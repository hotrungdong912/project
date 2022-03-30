using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string mainplay;
    public string menuplay = "MainMenu";
    public string Guideplay = "GuideScenes";

    public ScenesFader scenes;
    public void Play()
    {
        scenes.FadeTo(mainplay);      
    }

    public void GuideScenes()
    {
        scenes.FadeTo(Guideplay);
    }
    public void Back()
    {
        scenes.FadeTo(menuplay);
    }
    public void Quit()
    {
        Application.Quit();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Regi : MonoBehaviour
{

    public string loginScenename = "LoginScenes";
    public ScenesFader scene;

    public InputField username;
    public InputField password;
    public Button RegisterButton;
    public Button Back;
    void Start()
    {
        RegisterButton.onClick.AddListener(() =>
        {
            StartCoroutine(login.instans.main.Register(username.text, password.text));
            if (login.instans.main.RegisterSuccess == true)
            {
                scene.FadeTo(loginScenename);
                login.instans.main.RegisterSuccess = false;
            }
        });
        Back.onClick.AddListener(() =>
        {
            scene.FadeTo(loginScenename);
        });
    }

}

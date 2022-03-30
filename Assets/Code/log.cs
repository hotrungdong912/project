using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class log : MonoBehaviour
{
    public string menuScenename = "MainMenu";
    public string RegisterScenename = "RegisterScenes";
    public ScenesFader scene;

    public InputField username;
    public InputField password;
    public Button loginButton;
    public Button RegisterButton;


    void Start()
    {
        loginButton.onClick.AddListener(() =>
        {
           StartCoroutine(login.instans.main.Login(username.text, password.text));
           if(login.instans.main.loginSuccess == true)
           {
                scene.FadeTo(menuScenename);
                login.instans.main.loginSuccess = false;
           }
            if (login.instans.main.loginSuccess == false)
            {
               
            }
        });

        RegisterButton.onClick.AddListener(() =>
        {
                scene.FadeTo(RegisterScenename);              
        });
    }

   
}

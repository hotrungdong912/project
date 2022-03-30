 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class main : MonoBehaviour
{
    void Start()
    {
       // StartCoroutine(Register("dong","dong1"));
    }
    [HideInInspector]
    public bool loginSuccess = false;
    [HideInInspector]
    public bool RegisterSuccess = false;
    [HideInInspector]
    public string Name = "";
    [HideInInspector]
    public string Pass = "";
    public IEnumerator Login(string username , string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("loginUser", username);
        form.AddField("loginPass", password);
        using (UnityWebRequest www = UnityWebRequest.Post("https://trungdong0901.000webhostapp.com/Server/login.php", form))
        {
            yield return www.SendWebRequest();
            if (www.downloadHandler.text == "1")
            {
                Debug.Log(www.downloadHandler.text);
                loginSuccess = true;
                Name = username;
                Pass = password;
            }
            else
            {
                Debug.Log("Error");
            }
        }
    }
    public IEnumerator Register(string username, string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("loginUser", username);
        form.AddField("loginPass", password);       
        using (UnityWebRequest www = UnityWebRequest.Post("https://trungdong0901.000webhostapp.com/Server/register.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log("Error");
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
                RegisterSuccess = true;
            }
        }
    }
    public IEnumerator Savepoint(int point)
    {
        WWWForm form = new WWWForm();
        form.AddField("loginUser", Name);
        form.AddField("loginPass", Pass);
        form.AddField("Score", point);
        using (UnityWebRequest www = UnityWebRequest.Post("https://trungdong0901.000webhostapp.com/Server/update.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log("Error");
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
            }
        }

    }
}
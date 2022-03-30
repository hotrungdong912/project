using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class login : MonoBehaviour
{
    public static login instans;
    [HideInInspector]
    public main main;
    void Start()
    {
        instans = this;
        main = GetComponent<main>();
    }

  
}

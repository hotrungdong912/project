using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turntower : MonoBehaviour
{
    public GameObject game;

    // Update is called once per frame
    void Update()
    {
        game.transform.Rotate(new Vector3(0f,1f,0f));
       
    }
}

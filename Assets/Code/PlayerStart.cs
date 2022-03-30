using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerStart : MonoBehaviour
{
    public static int Money;
    public static int startMoney = 600;

    public static int Lives;
    public int startLives = 20;

    public static int Rounds;
    public static int startRounds = 0;

    public static int liveText;
   
    public static int point;
    void Start()
    {
        Money = startMoney;
        Lives = startLives;
        Rounds = startRounds;
        waySpawn.EnemiesAlives = 0;
    }
    
}

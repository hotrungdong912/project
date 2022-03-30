﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Wave
{
    public float rate;
    
    public WaveGroup[] enemies;
    [System.Serializable]
    public class WaveGroup
    {
        public GameObject enemy;
        public int count;
    }
}


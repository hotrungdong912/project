using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LiveUI : MonoBehaviour
{
    public Text liveText;
    public Text waveText;
    public Text enemydie;
    // Update is called once per frame
    void Update()
    {

        liveText.text = PlayerStart.Lives.ToString() + " lives";

        waveText.text = PlayerStart.Rounds.ToString() + " waves";

        enemydie.text = PlayerStart.point.ToString() + " point";
    }
}

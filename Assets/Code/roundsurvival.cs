using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class roundsurvival : MonoBehaviour
{
    public Text roundsText;
    void OnEnable()
    {
        StartCoroutine(AnimaText());

    }
    IEnumerator AnimaText()
    {
        roundsText.text = "0";
        int round = 0;
        yield return new WaitForSeconds(0.7f);

        while (round < PlayerStart.Rounds)
        {
            round++;
            roundsText.text = round.ToString();

            yield return new WaitForSeconds(0.5f);
        }

    }
}

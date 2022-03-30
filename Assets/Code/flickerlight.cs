using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flickerlight : MonoBehaviour
{
    public Light lightflicker;
    float minspeed = 0.01f;

    float maxspeed = 0.6f;

    float minIntdensity = 0.1f;

    float maxIntdensity = 5f;
    void Start()
    {
        lightflicker = GetComponent<Light>();
        StartCoroutine(run());
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator run()
    {
        while (true)
        {
            lightflicker.enabled = true;
            lightflicker.intensity = Random.Range(minIntdensity, maxIntdensity);
            yield return new WaitForSeconds(Random.Range(minspeed, maxspeed));
            lightflicker.enabled = false;
            yield return new WaitForSeconds(Random.Range(minspeed, maxspeed));
        }
    }
}

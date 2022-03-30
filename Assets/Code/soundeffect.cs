using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundeffect : MonoBehaviour
{
    public static AudioClip arrowHit1, arrowHit2, cannonHit;
    static AudioSource audioSrc; 
    // Start is called before the first frame update
    void Start()
    {
        arrowHit1 = Resources.Load<AudioClip>("arrowhit1");
        arrowHit2 = Resources.Load<AudioClip>("arrowhit2");
        cannonHit = Resources.Load<AudioClip>("cannonhit");

        audioSrc = GetComponent<AudioSource> () ;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void Playsound (string clip)
    {
        switch (clip)
        {
            case "arrowhit1":
                audioSrc.PlayOneShot(arrowHit1);
                Debug.Log(clip);
                break;
            case "arrowhit2":
                audioSrc.PlayOneShot(arrowHit2);
                break;
            case "cannonhit":
                audioSrc.PlayOneShot(cannonHit);
                break;
        }
        
    }
    
}

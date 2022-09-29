using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WakeCamScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject WakeCamWoosh;
    public GameObject FemaleCrying;
    public GameObject Laughter;

    public void playWakeCamWoosh()
    {
        WakeCamWoosh.gameObject.GetComponent<AudioSource>().Play();
    }

    public void playCrying()
    {
        FemaleCrying.gameObject.GetComponent<AudioSource>().Play();
    }

    public void playLaughter()
    {
        Laughter.gameObject.GetComponent<AudioSource>().Play();
    }



}

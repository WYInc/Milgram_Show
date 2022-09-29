using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamWinScript : MonoBehaviour
{
    public GameObject FallingScream;
    public GameObject Splat;

    public void playFallingScream()
    {
        FallingScream.gameObject.GetComponent<AudioSource>().Play();
    }

    public void playSplat()
    {
        Splat.gameObject.GetComponent<AudioSource>().Play();
    }

}

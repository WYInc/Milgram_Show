using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamNeighborScript : MonoBehaviour
{
    public GameObject FScream;
    public GameObject NeighborLaugh;


    public void playFScream()
    {
        FScream.gameObject.GetComponent<AudioSource>().Play();
    }

    public void playNeighborLaugh()
    {
        NeighborLaugh.gameObject.GetComponent<AudioSource>().Play();
    }

    
}

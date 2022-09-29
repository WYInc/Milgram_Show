using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectrocutionCamScript : MonoBehaviour
{
    //current1, current2, scream1, scream2

    public GameObject Current1;
    public GameObject Current2;
    public GameObject Scream1;
    public GameObject Scream2;
    public GameObject ElectLaughter;


    public void playScream1()
    {
        Scream1.gameObject.GetComponent<AudioSource>().Play();
    }

    public void playScream2()
    {
        Scream2.gameObject.GetComponent<AudioSource>().Play();
    }

    public void playCurrent1()
    {
        Current1.gameObject.GetComponent<AudioSource>().Play();
    }
    
    public void playCurrent2()
    {
        Current2.gameObject.GetComponent<AudioSource>().Play();
    }

    public void playElectLaughter()
    {
        ElectLaughter.gameObject.GetComponent<AudioSource>().Play();
    }

}

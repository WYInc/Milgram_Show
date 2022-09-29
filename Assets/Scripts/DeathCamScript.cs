using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathCamScript : MonoBehaviour
{
    //scream, electrocution, rhythmic

    public GameObject Scream;
    public GameObject Electrocution;
    public GameObject Laughter;


    public void playDeathScream()
    {
        Scream.gameObject.GetComponent<AudioSource>().Play();
    }

    public void playDeathElectrocution()
    {
        Electrocution.gameObject.GetComponent<AudioSource>().Play();
    }

    public void playLaughter()
    {
        Laughter.gameObject.GetComponent<AudioSource>().Play();
    }


}

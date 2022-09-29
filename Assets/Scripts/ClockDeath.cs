using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockDeath : MonoBehaviour
{

    public GameObject GM;
    public GameObject Bells;

    public void outOfTime()
    {
        Debug.Log("Working");
        Bells.gameObject.GetComponent<AudioSource>().Play();
        GM.gameObject.GetComponent<Game_Manager>().timerDeath();
    }

}

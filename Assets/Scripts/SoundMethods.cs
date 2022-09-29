using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMethods : MonoBehaviour
{
    public GameObject Speaker;
    public GameObject Camera;
    public GameObject Pipe;

    public GameObject ElectrocutionCamera;
    public GameObject DeathCamera;
    public GameObject WakeUpCamera;
    public GameObject WinCamera;

    private void Start()
    {
        playLaugh1();
    }

    public void playLaugh1()
    {
        Speaker.gameObject.GetComponent<AudioSource>().Play();
    }



}

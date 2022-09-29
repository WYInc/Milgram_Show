using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBox : MonoBehaviour
{
    public GameObject[] Lights;
    public GameObject gmlightbox;
    private float TimerDuration = 3f;
    private float Timer = 0f;
    private int WhichLight = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Timer >= TimerDuration)
        {

            nextLight(WhichLight);
            Timer = 0f;

        }
        else
        {
            Timer = Timer + Time.deltaTime;
        }
    }


    public void nextLight(int LightNumber)
    {
        switch (LightNumber) {
            case 0:
                Lights[0].GetComponent<MeshRenderer>().material.EnableKeyword("_EMISSION");
                Lights[3].GetComponent<MeshRenderer>().material.DisableKeyword("_EMISSION");
                WhichLight += 1;
                gmlightbox.gameObject.GetComponent<Game_Manager>().WhichLightOn = 0;
                //Debug.Log(WhichLight);
                break;
            case 1:
                Lights[1].GetComponent<MeshRenderer>().material.EnableKeyword("_EMISSION");
                Lights[0].GetComponent<MeshRenderer>().material.DisableKeyword("_EMISSION");
                WhichLight += 1;
                gmlightbox.gameObject.GetComponent<Game_Manager>().WhichLightOn = 1;
                //Debug.Log(WhichLight);
                break;
            case 2:
                Lights[2].GetComponent<MeshRenderer>().material.EnableKeyword("_EMISSION");
                Lights[1].GetComponent<MeshRenderer>().material.DisableKeyword("_EMISSION");
                WhichLight += 1;
                gmlightbox.gameObject.GetComponent<Game_Manager>().WhichLightOn = 2;
                //Debug.Log(WhichLight);
                break;
            case 3:
                Lights[3].GetComponent<MeshRenderer>().material.EnableKeyword("_EMISSION");
                Lights[2].GetComponent<MeshRenderer>().material.DisableKeyword("_EMISSION");
                WhichLight = 0;
                gmlightbox.gameObject.GetComponent<Game_Manager>().WhichLightOn = 3;
                //Debug.Log(WhichLight);
                break;


        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchScript : MonoBehaviour
{
    //public GameObject Light;
    private bool Switchup = false;
    //private bool LightOn = false;
    // Start is called before the first frame update

    public GameObject gm;

    public GameObject SwitchSound;


    public int whichSwitch;

    void Start()
    {
        //gm = gameObject.GetComponent<Game_Manager>();

    }

    public void OnMouseDown()
    {
        SwitchSound.gameObject.GetComponent<AudioSource>().Play();
        if (Switchup == true)
        {
            switchDown();
            signalGameManager();
        }
        else
        {
            switchUp();
            signalGameManager();
        }
    }
        public void switchDown()
        {
            this.gameObject.transform.eulerAngles = new Vector3(-30f, 0f, 0f);
            Switchup = false;
            
        }


    public void switchUp()
    {
        this.gameObject.transform.eulerAngles = new Vector3(30f, 0f, 0f);
        Switchup = true;
        
    }
        

        //section for testing on/off function with lights connected to switches
        //lights now separated from switch function
        //if (LightOn == false)
        //{
        //    Light.GetComponent<MeshRenderer>().material.EnableKeyword("_EMISSION");
        //    LightOn = true;
        //    //GreenLight.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor")
        //}
        //else
        //{
        //    Light.GetComponent<MeshRenderer>().material.DisableKeyword("_EMISSION");
        //    LightOn = false;
        //}
    

    public void signalGameManager()
    {

        gm.gameObject.GetComponent<Game_Manager>().SwitchBoolChange(whichSwitch);
        gm.gameObject.GetComponent<Game_Manager>().shouldDoorOpen();
      
        //gameObject.GetComponent<Game_Manager>().SwitchBoolChange();
        //if (whichSwitch == 1)
        //{
 
            //GetComponent<Game_Manager>().SwitchBoolChange();
            //Debug.Log("Script Running");
        //}
        //GetComponent<Game_Manager>().canDoorOpen();
    }
}

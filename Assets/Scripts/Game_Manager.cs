using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class Game_Manager : MonoBehaviour
{


    [HideInInspector]
    public int Switch1Up = 0;
    [HideInInspector]
    public int Switch2Up = 0;
    [HideInInspector]
    public int Switch3Up = 0;
    [HideInInspector]
    public int Switch4Up = 0;
    [HideInInspector]
    public int Switch5Up = 0;
    [HideInInspector]
    public int Switch6Up = 0;


    public GameObject SwitchAccess;
    public GameObject SwitchAccess2;
    public GameObject SwitchAccess3;
    public GameObject SwitchAccess4;
    public GameObject SwitchAccess5;
    public GameObject SwitchAccess6;

    //public float CountDownTime;
    //private float CurrentTime;

    public int WhichLightOn;

    public GameObject CameraPosition;
    public Transform[] NodePositions;
    public GameObject[] ColliderObjects;

    public GameObject Camera1;
    public GameObject Camera2;
    public GameObject ElectrocutionCamera;
    public GameObject NeighborCamera;
    public GameObject WinCamera;
    public GameObject DeathCamera;

    public GameObject BackButton;


    private int Electrocutions;

    private bool GameStart = true;

    //private bool PlayNeighborElect = true;


    [SerializeField] private Animator DoorPivot;

    [SerializeField] private string doorOpen = "DoorOpen";

    [SerializeField] private Animator WakeUpAnimator;

    [SerializeField] private string WakeUpTour = "WakeUpTour";

    [SerializeField] private Animator ElectrocutionAnimator;

    [SerializeField] private string ElectrocutionAnimation = "Electrocution";

    [SerializeField] private Animator DeathAnimator;

    [SerializeField] private string DeathAnimation = "Death";

    [SerializeField] private Animator NeighborAnimator;

    [SerializeField] private string NeighborAnimation = "Neighbor";

    [SerializeField] private Animator WinAnimator;

    [SerializeField] private string WinAnimation = "Win";

    [SerializeField] private Animator ClockAnimator;

    [SerializeField] private string Clock5Min = "Clock";

    [SerializeField] private string Clock10Min = "Clock10min";

    public GameObject LockSound;

    private int Health;
    public GameObject Heart1;
    public GameObject Heart2;
    public GameObject Heart3;



    //Start is called before the first frame update



    void Start()
    {

        if (GameStart == true)
        {
            //block below is for TESTING WITHOUT WAKE ANIMATION, TO DO NORMAL START, COMMENT OUT OR 
            //DELETE BLOCK BELOW AND UNCOMMENT FOLLOWING BLOCK
            //Camera1.SetActive(false);
            //Camera2.SetActive(true);
            //ElectrocutionCamera.SetActive(false);
            //NeighborCamera.SetActive(false);
            //WinCamera.SetActive(false);
            //DeathCamera.SetActive(false);
            //GameStart = false;
            //ClockAnimator.Play("Clock");

            Camera1.SetActive(true);
            Camera2.SetActive(false);
            BackButton.SetActive(false);
            ElectrocutionCamera.SetActive(false);
            NeighborCamera.SetActive(false);
            WinCamera.SetActive(false);
            DeathCamera.SetActive(false);
            Health = 0;
            updateHearts();
            WakeUpAnimator.Play(WakeUpTour);
            StartCoroutine(switchCamera(55));
            GameStart = false;
        }

        Electrocutions = 0;
        
        //CurrentTime = 10;
    }

    IEnumerator switchCamera(int AnimationLength)
    {
        yield return new WaitForSeconds(AnimationLength);
        Camera2.SetActive(true);
        Camera1.SetActive(false);
        Health = 3;
        updateHearts();
        BackButton.SetActive(true);
        ClockAnimator.Play("Clock");
        //transform.position = new Vector3(-0.079f, 2.849f, -5.92f);
        //transform.rotation = Quaternion.Euler(-80, -436, 353);
    }

    public void updateHearts()
    {
        if(Health == 3)
        {
            Heart3.SetActive(true);
            Heart2.SetActive(true);
            Heart1.SetActive(true);
        }
        else if (Health == 2)
        {
            Heart3.SetActive(false);
        }
        else if(Health == 1)
        {
            Heart3.SetActive(false);
            Heart2.SetActive(false);
        }
        else if (Health == 0)
        {
            Heart3.SetActive(false);
            Heart2.SetActive(false);
            Heart1.SetActive(false);
        }
    }



    public void shouldDoorOpen()
    {
        if (Switch1Up == 0 && Switch2Up == 1 && Switch3Up == 0 && Switch4Up == 0 && Switch5Up == 1 && Switch6Up == 1)
        {
            Health = 0;
            updateHearts();
            BackButton.SetActive(false);
            DoorPivot.Play(doorOpen);
            Camera2.SetActive(false);
            WinCamera.SetActive(true);
            WinAnimator.Play("Win");
            StartCoroutine(afterWin(11.8f));
        }

        IEnumerator afterWin(float AnimationLength)
        {
            yield return new WaitForSeconds(AnimationLength);
            SceneManager.LoadScene(3);

        }


    }

    public void PreviousNode()
    {
        if (CameraPosition.transform.position.z > -1.17f)
        {
            Sequence seq = DOTween.Sequence();
            seq.Append(CameraPosition.transform.DOMove(NodePositions[3].position, 0.75f));
            seq.Join(CameraPosition.transform.DORotate(new Vector3(NodePositions[3].rotation.eulerAngles.x, NodePositions[3].rotation.eulerAngles.y, 0f), 0.75f));
            //CameraPosition.transform.position = NodePositions[3].position;
            //CameraPosition.transform.rotation = NodePositions[3].rotation;
        }
        else if (CameraPosition.transform.position.z < -1f)
        {

            Sequence seq = DOTween.Sequence();
            seq.Append(CameraPosition.transform.DOMove(NodePositions[2].position, 0.75f));
            seq.Join(CameraPosition.transform.DORotate(new Vector3(NodePositions[2].rotation.eulerAngles.x, NodePositions[2].rotation.eulerAngles.y, 0f), 0.75f));
            //CameraPosition.transform.position = NodePositions[2].position;
            //CameraPosition.transform.rotation = NodePositions[2].rotation;
        }


    }



    public void SwitchBoolChange(int SwitchNumber)
    {
        switch (SwitchNumber)
        {
            case 1:
                if (WhichLightOn == 2)
                {
                    if (Switch1Up == 0)
                    {
                        Switch1Up = 1;
                    }
                    else
                    {
                        Switch1Up = 0;
                    }
                    StartCoroutine(delayLockSound());
                }
                else
                {
                    StartCoroutine(SwitchDelay(1));
                    Debug.Log("Electrocution");
                    electrocutionMethod();
                }
                //Debug.Log("Switch 1:" + Switch1Up);
                break;
            case 2:
                StartCoroutine(SwitchDelay(2));
                Debug.Log("Electrocution");
                electrocutionMethod();
                break;
            case 3:
                if (WhichLightOn == 0)
                {
                    if (Switch3Up == 0)
                    {
                        Switch3Up = 1;
                    }
                    else
                    {
                        Switch3Up = 0;
                    }
                    StartCoroutine(delayLockSound());
                }
                else
                {
                    StartCoroutine(SwitchDelay(3));
                    Debug.Log("Electrocution");
                    electrocutionMethod();
                }
                //Debug.Log("Switch 3:" + Switch3Up);
                break;
            case 4:
                if (WhichLightOn == 3)
                {
                    if (Switch4Up == 0)
                    {
                        Switch4Up = 1;
                    }
                    else
                    {
                        Switch4Up = 0;
                    }
                    StartCoroutine(delayLockSound());
                }
                else
                {
                    StartCoroutine(SwitchDelay(4));
                    Debug.Log("Electrocution");
                    electrocutionMethod();
                }
                //Debug.Log("Switch 4:" + Switch4Up);
                break;
            case 5:
                StartCoroutine(SwitchDelay(5));
                Debug.Log("Electrocution");
                electrocutionMethod();
                //if (Switch5Up == 0)
                //{
                //    Switch5Up = 1;
                //}
                //else
                //{
                //    Switch5Up = 0;
                //}
                //Debug.Log("Switch 5:" + Switch5Up);
                break;
            case 6:
                if (WhichLightOn == 1)
                {
                    if (Switch6Up == 0)
                    {
                        Switch6Up = 1;
                    }
                    else
                    {
                        Switch6Up = 0;
                    }
                    StartCoroutine(delayLockSound());
                }
                else
                {
                    StartCoroutine(SwitchDelay(6));
                    Debug.Log("Electrocution");
                    electrocutionMethod();
                }
                //Debug.Log("Switch 6:" + Switch6Up);
                break;
        }
    }

    IEnumerator SwitchDelay(int switchNumberForReset)
    {
        yield return new WaitForSeconds(1);
        if (switchNumberForReset == 1)
        {
            SwitchAccess.gameObject.GetComponent<SwitchScript>().switchDown();
        }
        else if (switchNumberForReset == 2)
        {
            SwitchAccess2.gameObject.GetComponent<SwitchScript>().switchDown();
        }
        else if (switchNumberForReset == 3)
        {
            SwitchAccess3.gameObject.GetComponent<SwitchScript>().switchDown();
        }
        else if (switchNumberForReset == 4)
        {
            SwitchAccess4.gameObject.GetComponent<SwitchScript>().switchDown();
        }
        else if (switchNumberForReset == 5)
        {
            SwitchAccess5.gameObject.GetComponent<SwitchScript>().switchDown();
        }
        else
        {
            SwitchAccess6.gameObject.GetComponent<SwitchScript>().switchDown();
        }
    }

    public void electrocutionMethod()
    {
        if (Electrocutions == 0 || Electrocutions == 2)
        {
            Health -= 1;
            updateHearts();
            Camera2.SetActive(false);
            BackButton.SetActive(false);
            ElectrocutionCamera.SetActive(true);
            ElectrocutionAnimator.Play("Electrocution");
            StartCoroutine(afterElectCamera(11.5f, ElectrocutionCamera));
            Electrocutions += 1;         
            
        }
        else if(Electrocutions == 1)
        {
            Camera2.SetActive(false);
            BackButton.SetActive(false);
            NeighborCamera.SetActive(true);
            NeighborAnimator.Play("Neighbor");
            StartCoroutine(afterElectCamera(13.8f, NeighborCamera));
            //PlayNeighborElect = false;
            Electrocutions += 1;
        }
        else if(Electrocutions == 3)
        {
            Health -= 1;
            updateHearts();
            Camera2.SetActive(false);
            BackButton.SetActive(false);
            DeathCamera.SetActive(true);
            DeathAnimator.Play("Death");
            //StartCoroutine(afterElectCamera(23.8f, NeighborCamera));
            StartCoroutine(afterDeath(31.5f));
        }


        IEnumerator afterElectCamera(float AnimationLength, GameObject whichcamera)
        {
            yield return new WaitForSeconds(AnimationLength);
            Camera2.SetActive(true);
            BackButton.SetActive(true);
            whichcamera.SetActive(false);

        }

    }

    IEnumerator afterDeath(float AnimationLength)
    {
        yield return new WaitForSeconds(AnimationLength);
        SceneManager.LoadScene(2);

    }
    IEnumerator delayLockSound()
    {
        yield return new WaitForSeconds(0.7f);
        LockSound.gameObject.GetComponent<AudioSource>().Play();
    }

    public void timerDeath()
    {
        Health = 0;
        updateHearts();
        Camera2.SetActive(false);
        BackButton.SetActive(false);
        DeathCamera.SetActive(true);
        DeathAnimator.Play("Death");
        StartCoroutine(afterDeath(31.5f));
    }
}

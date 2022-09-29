using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkScript : MonoBehaviour
{
    private Animation topLid;
    private Animation bottomLid;
    // Start is called before the first frame update
    void Start()
    {
        topLid = gameObject.GetComponent<Animation>();
        topLid["topLid"].layer = 123;
        bottomLid = gameObject.GetComponent<Animation>();
        topLid["bottomLid"].layer = 123;

    }


    IEnumerator blinkDelay()
    {
        yield return new WaitForSeconds(3);
        topLid.Play("TopLid");
        bottomLid.Play("BottomLid");
    }

}

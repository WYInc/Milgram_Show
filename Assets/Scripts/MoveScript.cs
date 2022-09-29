using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour
{
    public Transform CameraView;
    public Collider DoorCollider;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //MouseMove(DoorCollider);
    }

    //public void MouseMove(Collider collider)
    //{
        
    //}

    //private void MouseMove()
    //{
    //    if (Input.GetMouseButton(0))
    //    {
    //        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 5);
    //        Vector3 shipPos = Camera.main.ScreenToWorldPoint(mousePos);


    //        gameObject.transform.position = Vector3.MoveTowards(transform.position, shipPos, 1 * Time.deltaTime);
    //    }
    //}
}

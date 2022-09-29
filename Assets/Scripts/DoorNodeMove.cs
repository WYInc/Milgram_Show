using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DoorNodeMove : MonoBehaviour
{
    public GameObject CameraPosition;
    //public Transform y_axis;
    //public Transform x_axis;
    public Transform TargetPosition;
    public Transform BackPosition;
    [HideInInspector]
    public Collider col;
    public GameObject OtherForColEnable;
    public GameObject OtherForColEnable2;

    public GameObject SwooshSound;
    //public Quaternion CameraRotation;

    public bool HasNeighbor;
    public bool Has2Neighbors;

    private void Start()
    {
        col = GetComponent<Collider>();
    }
    //If want to use mousePOV to drag-look, change below to OnMouseUp
    private void OnMouseDown()
    {


        Sequence seq = DOTween.Sequence();
        seq.Append(CameraPosition.transform.DOMove(TargetPosition.position, 0.75f));
        seq.Join(CameraPosition.transform.DORotate(new Vector3(TargetPosition.rotation.eulerAngles.x, TargetPosition.rotation.eulerAngles.y, 0f), 0.75f));
        SwooshSound.gameObject.GetComponent<AudioSource>().Play();

        if (col != null)
        {
            col.enabled = false;
        }

        if (HasNeighbor == true)
        {
            enableNeighborCollider();
        }

        //CameraPosition.transform.position = TargetPosition.position;
        //CameraPosition.transform.rotation = TargetPosition.rotation;
    }

    public void enableCollider()
    {
        col.enabled = true;
    }

    public void enableNeighborCollider()
    {
        OtherForColEnable.gameObject.GetComponent<DoorNodeMove>().enableCollider();
        if (Has2Neighbors == true)
        {
            OtherForColEnable2.gameObject.GetComponent<DoorNodeMove>().enableCollider();
        }
    }



}

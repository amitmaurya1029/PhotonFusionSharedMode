using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class BallControler : XRGrabInteractable
{

    void Start()
    {

    }


    void Update()
    {

    }




    protected override void Grab()
    {
        base.Grab();
        Debug.Log("Ball Grabbed");
    }

    protected override void Drop()
    {
        base.Drop();
        Debug.Log("Ball Dropped");
    }
}

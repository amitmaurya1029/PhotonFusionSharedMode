using System.Collections;
using System.Collections.Generic;
using Fusion;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class BallControler : XRGrabInteractable
{

    private NetworkObject networkObject;
    void Start()
    {
        networkObject = GetComponent<NetworkObject>();
        
    }


    void Update()
    {

    }




    protected override void Grab()
    {
        base.Grab();
        if (!networkObject.HasStateAuthority)
        {
           networkObject.RequestStateAuthority();
           Debug.Log("Ball Grabbed");
            return;
        }
        
    }

    // protected override void Drop()
    // {
    //     base.Drop();
    //     if (networkObject.HasStateAuthority)
    //     {
    //         networkObject.ReleaseStateAuthority();
    //     }
        


    //     Debug.Log("Ball Dropped");
    // }
}

using System.Collections;
using System.Collections.Generic;
using Fusion;
using UnityEngine;

public class PlayerColor : NetworkBehaviour
{
    public MeshRenderer meshRenderer;
    
    [Networked, OnChangedRender(nameof(ColorChange))]
    public Color changeColorOverNetwork { get; set; }           // we use auto implemented property , and add the network attribute above.

    void Start()
    {

    }

    void Update()
    {
        if (HasStateAuthority && Input.GetKeyDown(KeyCode.E))
        {
            // Changing the material color here directly does not work since this code is only executed on the client pressing the button and not on every client.
            changeColorOverNetwork = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1f);
        }
    }



    void ColorChange()
    {
        meshRenderer.material.color = changeColorOverNetwork;
    }

    // in photon fusion there is a function called onChangeRender  on each time when network property gets
    //  change this onchangerendere fun gets call



    // think of a stateAuthority means a individual client that has a authority to change the network property.
}



// network property gets added to synchronize the color 
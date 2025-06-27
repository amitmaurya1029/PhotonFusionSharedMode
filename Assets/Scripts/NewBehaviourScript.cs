using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using Fusion;
using TMPro;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

    }





    // network nunner is the main script in photon fusion / core component which runs the photon fusion 


    // in multiplayer game we instanciate gameobject per player, spawaning an gameobject on network has a special 
    //FunctionArgs call runner.spawn. which thakes care to spawning the object to everyone.

    public void EndOFiNPUTfeildend()
    {
        Debug.Log("End of Input field");
    }
    
}

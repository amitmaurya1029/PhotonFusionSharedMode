using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnonomusFunctions : MonoBehaviour
{
    // create delegates 

    public delegate void MyDelegate();

     MyDelegate myDelegate = new MyDelegate(ShowObjectDistance);
    // MyDelegate myDelegate = ShowObjectDistance;

    void Start()
    {
        MyExtension.ResetPosition(this);

        DataClass.instance.AssignMethodsToButton(myDelegate);
    }



    public static void ShowObjectDistance()
    {
        Debug.Log("distance is 30 m");
    }
    
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public static class MyExtension
{
    public static void ResetPosition(this MonoBehaviour mono)
    {
        mono.transform.position = Vector3.zero;
    }



    // need to create an exetension method that will assign an function to a button.


    public static void AddFunctionToButoon(this Button button, UnityAction action)
    {
        button.onClick.AddListener(delegate {action.Invoke();});
    }
}

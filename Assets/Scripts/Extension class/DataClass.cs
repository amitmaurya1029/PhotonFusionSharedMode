using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DataClass : MonoBehaviour
{
    [SerializeField] private Button button;

    // letes make an singleton

    public static DataClass instance;

    void Awake()
    {
        if (instance != null)
        {
            instance = null;
        }
        else
        {
            instance = this;
        }
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    public void AssignMethodsToButton(UnityAction action)
    {
        
        button.AddFunctionToButoon(action);
    }

    internal void AssignMethodsToButton(AnonomusFunctions.MyDelegate myDelegate)
    {
        throw new NotImplementedException();
    }
}

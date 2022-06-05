using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebuggText : MonoBehaviour
{
    public string output = "";
    public string stack = "";

    void OnEnable()
    {
        Application.logMessageReceived += HandleLog;
    }

    private void Start()
    {

    }

    void OnDisable()
    {
        Application.logMessageReceived -= HandleLog;
    }

    void HandleLog(string logString, string stackTrace, LogType type)
    {
        if(type == LogType.Warning || type == LogType.Error)
        {
            this.gameObject.GetComponent<Text>().text = type.ToString() + ": " + logString;
        }        
    }
}

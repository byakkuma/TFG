using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Configuration : MonoBehaviour
{
    [Header("Configuracion Agarre")]
    [SerializeField] protected grabOption MetodoDeAgarre;
    [SerializeField] protected grabChange MetodoDeCambio;

    [HideInInspector] 
    public configurationStruct grab;

    private void Start()
    {
        grab.grabMethod = MetodoDeAgarre;
        grab.changeMethod = MetodoDeCambio;
    }

    
}
public struct configurationStruct
{
    public grabOption grabMethod;
    public grabChange changeMethod;
}
public enum grabChange
{
    Button,
    Sign,
    None
}
public enum grabOption
{
    Grab,
    OVRGrab,
    Sign
}

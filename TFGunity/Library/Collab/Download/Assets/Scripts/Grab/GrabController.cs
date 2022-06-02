using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabController : MonoBehaviour
{
    /*
     * Este scrept se encarga de intercambiar entre las dos posibles manos que hay
     *  Unas son las manos para poder agarrar objetos
     *  Las otras son las que se utilizan para pulsar botones (Hace un mejor seguimineto)
     */
    public GameObject leftHand;
    public GameObject rightHand;
    public GameObject snappingLeftHand;
    public GameObject snappingRighttHand;
    private List<GameObject> buttons;
    // Guarda los distintos botones que sen agarrables para desactivarlos tambien
    void Start()
    {
        buttons = new List<GameObject>();
        GrabbableButton[] buttonsGrBu = FindObjectsOfType<GrabbableButton>();
        foreach (GrabbableButton button in buttonsGrBu)
        {
            buttons.Add(button.gameObject);
        }

        grabOff();
    }
    public void switchGrab()
    {
        if(leftHand.GetComponent<OVRMesh>().enabled == true)
        {
            grabOn();
        } 
        else
        {
            grabOff();
        }
    }

    // Activa el poder agarrar objetos
    public void grabOn()
    {
        leftHand.GetComponent<OVRMeshRenderer>().enabled = false;
        leftHand.GetComponent<OVRMesh>().enabled = false;
        rightHand.GetComponent<OVRMeshRenderer>().enabled = false;
        rightHand.GetComponent<OVRMesh>().enabled = false;
        snappingLeftHand.SetActive(true);
        snappingRighttHand.SetActive(true);
        foreach(GameObject button in buttons){
            button.GetComponent<GrabbableButton>().GrabbableOn();
        }
    }
    // Desactiva el poder agarrar objetos
    public void grabOff()
    {
        leftHand.GetComponent<OVRMeshRenderer>().enabled = true;
        leftHand.GetComponent<OVRMesh>().enabled = true;
        rightHand.GetComponent<OVRMeshRenderer>().enabled = true;
        rightHand.GetComponent<OVRMesh>().enabled = true;
        snappingLeftHand.SetActive(false);
        snappingRighttHand.SetActive(false);
        foreach (GameObject button in buttons)
        {
            button.GetComponent<GrabbableButton>().GrabbableOff();
        }
    }
}

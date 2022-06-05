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
    public GrabbableButton[] buttons;
    public MenuController menuController;
    private bool grabActive;
    // Guarda los distintos botones que sen agarrables para desactivarlos tambien
    void Start()
    {
        grabActive = false;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            switchGrab();
        }
    }
    public void switchGrab()
    {
        bool repit = true;
        while (repit)
        {
            try 
            {
                if(!grabActive)
                {
                    grabOn();
                    grabActive = true;
                } 
                else
                {
                    grabOff();
                    grabActive = false;
                }
                repit = false;
            } catch
            {
                repit = true;
            }
        }
    }

    // Activa el poder agarrar objetos
    public void grabOn()
    {
        menuController.hideMenu();
        rightHand.GetComponent<OVRMesh>().enabled = false;
        leftHand.GetComponent<OVRMesh>().enabled = false;
        rightHand.GetComponent<OVRMeshRenderer>().enabled = false;
        leftHand.GetComponent<OVRMeshRenderer>().enabled = false;
        rightHand.GetComponent<SkinnedMeshRenderer>().enabled = false;
        leftHand.GetComponent<SkinnedMeshRenderer>().enabled = false;
        snappingLeftHand.SetActive(true);
        snappingRighttHand.SetActive(true);
        buttons = GameObject.FindObjectsOfType<GrabbableButton>();
        foreach (GrabbableButton button in buttons)
        {
            button.GetComponent<GrabbableButton>().GrabbableOn();
        }
    }
    // Desactiva el poder agarrar objetos
    public void grabOff()
    {
        menuController.showMenu();
        rightHand.GetComponent<OVRMesh>().enabled = true;
        leftHand.GetComponent<OVRMesh>().enabled = true;
        rightHand.GetComponent<OVRMeshRenderer>().enabled = true;
        leftHand.GetComponent<OVRMeshRenderer>().enabled = true;
        rightHand.GetComponent<SkinnedMeshRenderer>().enabled = true;
        leftHand.GetComponent<SkinnedMeshRenderer>().enabled = true;
        snappingLeftHand.SetActive(false);
        snappingRighttHand.SetActive(false);
        buttons = GameObject.FindObjectsOfType<GrabbableButton>();
        foreach (GrabbableButton button in buttons)
        {
            button.GetComponent<GrabbableButton>().GrabbableOff();
        }
    }
}

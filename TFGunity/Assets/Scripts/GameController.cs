using OculusSampleFramework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    /*
     * Este scrept se encarga de manejar cuando se detectan o dejan de detectar las manos y el esqueleto
     */

    // variables a asignar
    public GameObject player;
    public GameObject panel;
    public MenuController menuController;
    // --

    private GameObject camara;
    private GameObject rightHand;
    private GameObject leftHand;
    private GameObject rightHandTrack;
    private GameObject leftHandTrack;
    private Text dinamicRHandText;
    private Text dinamicLHandText;
    private bool fistLeftHandTime = false;
    private bool fistRightHandTime = false;

    // configuration
    private Configuration config;



    // Se asignan los valores de diferentes componentes necesarios
    void Start()
    {
        camara = player.GetComponent<Transform>().GetChild(1).gameObject;                   // Devuelve la camara
        rightHand = camara.GetComponent<Transform>().GetChild(0).GetChild(5).gameObject;    // Devuelve la mano derecha
        leftHand = camara.GetComponent<Transform>().GetChild(0).GetChild(4).gameObject;     // Repetimos con la mano izqueirda
        rightHandTrack = rightHand.GetComponent<Transform>().GetChild(1).gameObject;        // Devuelve el objeto encargado del trackeo de la mano
        leftHandTrack = leftHand.GetComponent<Transform>().GetChild(1).gameObject;     // Repetimos con la mano izqueirda
        dinamicRHandText = panel.GetComponent<Transform>().GetChild(2).GetChild(1).GetChild(1).GetComponent<Text>();
        dinamicLHandText = panel.GetComponent<Transform>().GetChild(2).GetChild(2).GetChild(1).GetComponent<Text>();
        config = this.GetComponent<Configuration>();
    }

    // Se comprueba si se sigue sabiendo la posicion de las manos y el esqueleto
    void Update()
    {
        bool rTracked = rightHandTrack.GetComponent<OVRHand>().IsTracked;                                   // Devuelve si se sabe donde esta la mano derecha
        bool lTracked = leftHandTrack.GetComponent<OVRHand>().IsTracked;                                    // Repetimos con la mano izquierda
        OVRHand.TrackingConfidence rConfidence = rightHandTrack.GetComponent<OVRHand>().HandConfidence;     // Devuelve como de seguro esta de la posicion de la mano (High o Low)
        OVRHand.TrackingConfidence lConfidence = leftHandTrack.GetComponent<OVRHand>().HandConfidence;      // Repetimos con la mano izquierda

        if (!fistLeftHandTime)
        {
            if (lTracked && lConfidence == OVRHand.TrackingConfidence.High)
            {
                fistLeftHandTime = true;
                menuController.activateLeftHand();
            }
        }
        if (!fistRightHandTime)
        {
            if (rTracked && rConfidence == OVRHand.TrackingConfidence.High)
            {
                fistRightHandTime = true;
                menuController.activateRightHand();
            }
        }

        /*
        { //hace invisibles las manos si no sabe su posicion
            if (rTracked && rConfidence == OVRHand.TrackingConfidence.High)
            {
                if (!rightHandTrack.GetComponent<OVRMeshRenderer>().enabled)
                {
                    // esto se dara solo cuando este seguro de la posicion de la mano
                    rightHandTrack.GetComponent<OVRMeshRenderer>().enabled = true;
                    rightHandTrack.GetComponent<SkinnedMeshRenderer>().enabled = true;
                    dinamicRHandText.text = "True";
                }
            }
            else
            {
                if (rightHandTrack.GetComponent<OVRMeshRenderer>().enabled)
                {                    
                    rightHandTrack.GetComponent<OVRMeshRenderer>().enabled = false; // hacemos invisibles las manos cuando no estemos seguros de la pocion
                    rightHandTrack.GetComponent<SkinnedMeshRenderer>().enabled = false;
                    dinamicRHandText.text = "False";
                }
            }

            if (lTracked && lConfidence == OVRHand.TrackingConfidence.High)
            {
                if (!leftHandTrack.GetComponent<OVRMeshRenderer>().enabled)
                {
                    if (!fistTime)
                    {
                        fistTime = true;
                        menuController.activateHand();
                        //GameObject.Find("Menus").GetComponent<MenuController>().inicialiceMenu();
                    }
                    // esto se dara solo cuando este seguro de la posicion de la mano
                    leftHandTrack.GetComponent<OVRMeshRenderer>().enabled = true;
                    leftHandTrack.GetComponent<SkinnedMeshRenderer>().enabled = true;
                    dinamicLHandText.text = "True";
                }
            }
            else
            {
                if (leftHandTrack.GetComponent<OVRMeshRenderer>().enabled)
                {
                    leftHandTrack.GetComponent<OVRMeshRenderer>().enabled = false; // hacemos invisibles las manos cuando no estemos seguros de la pocion
                    leftHandTrack.GetComponent<SkinnedMeshRenderer>().enabled = false;
                    dinamicLHandText.text = "False";
                }
            }

        }   // visibilidad de las manos

        /* esto es para los dedos
        OVRHand.TrackingConfidence fingerConfidence = rightHandTrack.GetComponent<OVRHand>().GetFingerConfidence(OVRHand.HandFinger.Index);     // Devuelve como de seguro esta de la posicion de los dedos (High o Low)
        if(fingerConfidence == OVRHand.TrackingConfidence.High)
        {
            // Esto se dara solo cuando este seguro de la posicion de los dedos
            bool isIndexFingerPinching = rightHandTrack.GetComponent<OVRHand>().GetFingerIsPinching(OVRHand.HandFinger.Index);                  // Devuelve si el dedo indice esta pinchando algo
            if (isIndexFingerPinching)
            {
                // Esto se dara solo cuando la mano este pinchando algo
                float ringFingerPinchStrength = rightHandTrack.GetComponent<OVRHand>().GetFingerPinchStrength(OVRHand.HandFinger.Ring);         // Devuelve la fuerza con la que presiona?????
            }
        }
        */
    }
}

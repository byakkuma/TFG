using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System;
using OculusSampleFramework;
using UnityEngine.UI;

public class ForearmMenu: Menu
{
    /*
     * Este scrept se encarga de colocar donde corresponde el menu de el antebrazo
     */

    /* Mano a la que se le va a adjuntar el menú, en este caso la izquierda */
    [Header("Subdominant Hand")]
    [SerializeField] protected OVRSkeleton leftHand;

    private List<OVRBone> leftFingerBones = null;

    /* Se hace un listado de los huesos de la mano subdominante, se redimensionan y se colocan las opciones del menú en el "antebrazo" */
    public override void setPosition()
    {
        leftFingerBones = new List<OVRBone>(leftHand.Bones);
        foreach (var bone in leftFingerBones)
        {
            if (bone.Id == OVRSkeleton.BoneId.Hand_ForearmStub)
            {
                /* Las opciones se establecen como hijos del hueso de la muñeca y se reescala*/
                foreach (var option in menuOptions)
                {
                    option.transform.SetParent(bone.Transform);
                    rescaleObject(option);
                }

                /* Palma hacia abajo */
                menuOptions[0].transform.localPosition = new Vector3(0.190f, -0.0345f, -0.04f);
                menuOptions[0].transform.localRotation = Quaternion.Euler(45.0f, 0.0f, 180.0f);

                menuOptions[1].transform.localPosition = new Vector3(0.135f, -0.0315f, -0.04f);
                menuOptions[1].transform.localRotation = Quaternion.Euler(45.0f, 0.0f, 180.0f);

                menuOptions[2].transform.localPosition = new Vector3(0.080f, -0.0295f, -0.04f);
                menuOptions[2].transform.localRotation = Quaternion.Euler(45.0f, 0.0f, 180.0f);
                 
                menuOptions[3].transform.localPosition = new Vector3(0.025f, -0.0280f, -0.04f);
                menuOptions[3].transform.localRotation = Quaternion.Euler(45.0f, 0.0f, 180.0f);
            }
        }
    }

    // reescala los botones para adaptarlos a los dedos
    private void rescaleObject(GameObject attachedObject)
    {
        Vector3 rescale1 = attachedObject.transform.localScale;
        rescale1.x = 0.005f;
        rescale1.y = 0.01f;
        rescale1.z = 0.005f;
        attachedObject.transform.localScale = rescale1;
    }

    private void Update()
    {
        //this.gameObject.transform.rotation
    }
    /*
    public override void buttonInteract(string name)
    {
        if (!botonPulsadoRec && !botonPulsadoAhora)
        {
            botonPulsadoAhora = true;
            Debug.LogWarning("Accionado boton: "+name);
            //panel.GetComponent<Transform>().GetChild(2).GetChild(4).GetChild(1).GetComponent<Text>().text = "true";
            //Text dinamicText = panel.GetComponent<Transform>().GetChild(2).GetChild(3).GetChild(1).GetComponent<Text>();
            //Debug.LogWarning(int.Parse(dinamicText.text));
            //dinamicText.text = (int.Parse(dinamicText.text) + 1).ToString();
        }
    }*/
}

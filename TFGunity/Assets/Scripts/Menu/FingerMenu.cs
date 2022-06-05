using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System;

public class FingerMenu : Menu
{
    /*
     * Este scrept se encarga de colocar donde corresponde el menu de los dedos
     */

    /* Mano a la que se le va a adjuntar el menú, en este caso la izquierda */
    [Header("Subdominant Hand")]
    [SerializeField] protected OVRSkeleton leftHand;

    

    /* Se redimensionan y se colocan las opciones del menú en las puntas de los dedos */
    public override void setPosition()
    {
        List<OVRBone> leftFingerBones = null;
        leftFingerBones = new List<OVRBone>(leftHand.Bones);
        List<OVRBone> fingerTips = new List<OVRBone>();
        foreach (OVRBone bone in leftFingerBones)
        {
            Debug.Log(bone.Id.ToString());
            if (bone.Id.ToString().Contains("Tip") && !bone.Id.ToString().Contains("Thumb"))
            {
                fingerTips.Add(bone);
            }
        }
        for (int i = 0; i < menuOptions.Count; i++)
        {
            rescaleObject(menuOptions[i], fingerTips[i]);
        }
    }


    /* Se establece el objeto como hijo del hueso de la punta del dedo, se reescala y se posiciona */
    private void rescaleObject(GameObject attachedObject, OVRBone bone)
    {
        attachedObject.transform.SetParent(bone.Transform);

        // Se reescala la opción
        Vector3 rescale = attachedObject.transform.localScale;
        rescale.x = 0.001971896f;
        rescale.y = 0.001971897f;
        rescale.z = 0.001971897f;
        attachedObject.transform.localScale = rescale;

        // Se coloca la opción
        attachedObject.transform.localPosition = new Vector3(0, 0, 0);
        attachedObject.transform.localRotation = Quaternion.Euler(0, -90, 0);
        attachedObject.transform.localPosition = new Vector3(attachedObject.transform.localPosition.x + 0.007f, attachedObject.transform.localPosition.y + 0.008f, attachedObject.transform.localPosition.z);
    }
    /*
    public override void buttonInteract(string name)
    {
        if (!botonPulsadoRec && !botonPulsadoAhora)
        {
            botonPulsadoAhora = true;
            Debug.LogWarning("Accionado boton: " + name);
            //panel.GetComponent<Transform>().GetChild(2).GetChild(4).GetChild(1).GetComponent<Text>().text = "true";
            //Text dinamicText = panel.GetComponent<Transform>().GetChild(2).GetChild(3).GetChild(1).GetComponent<Text>();
            //Debug.LogWarning(int.Parse(dinamicText.text));
            //dinamicText.text = (int.Parse(dinamicText.text) + 1).ToString();
        }
    }*/
}

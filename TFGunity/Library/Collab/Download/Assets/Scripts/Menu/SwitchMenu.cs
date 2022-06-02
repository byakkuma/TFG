using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchMenu : Menu
{
    /*
    * Este scrept se encarga de colocar donde corresponde el menu de permanente
    */

    /* Mano a la que se le va a adjuntar el menú, en este caso la izquierda */
    [Header("Subdominant Hand")]
    [SerializeField] protected OVRSkeleton leftHand;

    

    /* Se redimensionan y se colocan las opciones del menú en las puntas de los dedos */
    public override void setPosition()
    {
        List<OVRBone> leftFingerBones = null;
        leftFingerBones = new List<OVRBone>(leftHand.Bones);
        List<OVRBone> position = new List<OVRBone>();
        foreach (OVRBone bone in leftFingerBones)
        {
            if (bone.Id == OVRSkeleton.BoneId.Hand_ForearmStub)
            {
                position.Add(bone);
                break;
            }
        }
        for (int i = 0; i < menuOptions.Count; i++)
        {
            rescaleObject(menuOptions[i], position[i]);
        }
    }


    /* Se establece el objeto como hijo del hueso, se reescala y se posiciona */
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
        attachedObject.transform.localPosition = new Vector3(-0.06f, -0.015f, 0f);
        attachedObject.transform.localRotation = Quaternion.Euler(0f, -90f, 0f);
    }
}

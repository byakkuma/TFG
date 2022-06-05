using System.Collections;
using System.Collections.Generic;
using UnityEngine;
             
public class ForearmSliderMenu : Menu
{
    public override void setPosition()
    {
        menuOptions[0].transform.position = new Vector3(0.3f,0.9f,0);

        Vector3 rescale1 = menuOptions[0].transform.localScale;
        rescale1.x = 0.005f;
        rescale1.y = 0.01f;
        rescale1.z = 0.005f;
        menuOptions[0].transform.localScale = rescale1;

        /*
        leftFingerBones = new List<OVRBone>(leftHand.Bones);
        foreach (var bone in leftFingerBones)
        {
            if (bone.Id == OVRSkeleton.BoneId.Hand_ForearmStub)
            {
                /* Las opciones se establecen como hijos del hueso de la muñeca y se reescala*//*
                foreach (var option in menuOptions)
                {
                    option.transform.SetParent(bone.Transform);
                    rescaleObject(option);
                }

                /* Palma hacia abajo *//*
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
*/
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
}

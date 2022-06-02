using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System;

public class FingerMenu : Menu
{
    
    /* Mano a la que se le va a adjuntar el menú, en este caso la izquierda */
    [Header("Subdominant Hand")]
    [SerializeField] protected OVRSkeleton leftHand;

    

    /* Opciones del menú */
    private List<GameObject> menuOptions;


    private List<OVRBone> leftFingerBones = null;


    /* Se hace un listado de los huesos de la mano subdominante y se coloca el menú */
    public override void Initialize()
    {
        leftFingerBones = new List<OVRBone>(leftHand.Bones);
        nOptions = 4;
        menuOptions = new List<GameObject>();
        for (int i = 0; i < nOptions; i++)
        {
            GameObject buttonToSave = Instantiate(button);

            buttonToSave.GetComponent<ButtonListener>().proximityEvent.AddListener(delegate { this.buttonInteract(this.name); });
            buttonToSave.GetComponent<ButtonListener>().actionEvent.AddListener(delegate { this.buttonInteract(this.name); });
            buttonToSave.GetComponent<ButtonListener>().contactEvent.AddListener(delegate { this.buttonInteract(this.name); });
            buttonToSave.GetComponent<ButtonListener>().defaultEvent.AddListener(delegate { this.buttonExit(); });

            buttonToSave.name = buttonToSave.name + "Forearm" + i;
            buttonToSave.transform.SetParent(GameObject.Find("Buttons").transform);
            menuOptions.Add(buttonToSave);
        }
        setPosition();
    }

    /* Se redimensionan y se colocan las opciones del menú en las puntas de los dedos */
    public override void setPosition()
    {
        for (int i = 0; i < menuOptions.Count; i++)
        {
            rescaleObject(menuOptions[i], leftFingerBones[i]);
        }
    }


    /* Se establece el objeto como hijo del hueso de la punta del dedo, se reescala y se posiciona */
    private void rescaleObject(GameObject attachedObject, OVRBone bone)
    {
        attachedObject.transform.SetParent(bone.Transform);

        // Se reescala la opción
        Vector3 rescale = attachedObject.transform.localScale;
        rescale.x = 0.01971896f;
        rescale.y = 0.01971897f;
        rescale.z = 0.01971897f;
        attachedObject.transform.localScale = rescale;

        // Se coloca la opción
        attachedObject.transform.localPosition = new Vector3(0f, 0f, 0f);
        attachedObject.transform.localRotation = Quaternion.Euler(0.0f, 0.0f, 90.0f);
    }

    public override void buttonInteract(string name)
    {
        if (!botonPulsadoRec && !botonPulsadoAhora)
        {
            botonPulsadoAhora = true;
            Debug.LogWarning("Accionado boton");
            //panel.GetComponent<Transform>().GetChild(2).GetChild(4).GetChild(1).GetComponent<Text>().text = "true";
            //Text dinamicText = panel.GetComponent<Transform>().GetChild(2).GetChild(3).GetChild(1).GetComponent<Text>();
            //Debug.LogWarning(int.Parse(dinamicText.text));
            //dinamicText.text = (int.Parse(dinamicText.text) + 1).ToString();
        }
    }

    /* Se desactivan las opciones del menú */
    public override void hide()
    {
        foreach (var option in menuOptions)
        {
            option.SetActive(false);
        }
    }

    public override void show()
    {
        foreach (var option in menuOptions)
        {
            option.SetActive(true);
        }
    }
}

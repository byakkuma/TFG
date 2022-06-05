using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HandPosing.Interaction;
using OculusSampleFramework;

public class GrabbableButton : MonoBehaviour
{
    /*
     * Este scrept se encarga de permitir a los botones que son agarrables desactivar o reactivar esta funcionalidad
     */
    // Reactiva la opcion de agarrar botones
    public void GrabbableOn()
    {
        this.GetComponent<Grabbable>().enabled = true;
        this.GetComponent<Snappable>().enabled = true;
        this.transform.GetChild(0).gameObject.SetActive(true);
        this.transform.GetChild(1).gameObject.SetActive(true);
        this.transform.GetChild(2).gameObject.SetActive(true);
        this.transform.GetChild(3).gameObject.SetActive(true);

        //si se va a agarrar el boton se desactivan sus funcionalidades como boton
        this.transform.GetChild(4).GetComponent<ButtonController>().enabled = false;
        this.transform.GetChild(4).GetComponent<ButtonListener>().enabled = false;
    }

    // Descativa la opcion de agarrar botones
    public void GrabbableOff()
    {
        this.GetComponent<Grabbable>().enabled = false;
        this.GetComponent<Snappable>().enabled = false;
        this.transform.GetChild(0).gameObject.SetActive(false);
        this.transform.GetChild(1).gameObject.SetActive(false);
        this.transform.GetChild(2).gameObject.SetActive(false);
        this.transform.GetChild(3).gameObject.SetActive(false);

        //Hacemos que le boton vuelva a poder pulsarse una vez no se va a agarrar
        this.transform.GetChild(4).GetComponent<ButtonController>().enabled = true;
        this.transform.GetChild(4).GetComponent<ButtonListener>().enabled = true;
    }
}

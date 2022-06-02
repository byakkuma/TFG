using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Menu : MonoBehaviour
{
    [Header("Menu Options")]
    [SerializeField] protected GameObject button;

    public int nOptions;

    protected bool botonPulsadoAhora = false;
    protected bool botonPulsadoRec = false;

    public abstract void Initialize();

    public abstract void setPosition();

    public abstract void buttonInteract(string name);

    public void buttonExit()
    {
        if (!botonPulsadoRec && botonPulsadoAhora)
        {
            botonPulsadoRec = true;
            StartCoroutine(ExitButton());
        }
    }

    IEnumerator ExitButton()
    {
        //Espera dos segundos
        yield return new WaitForSeconds(0.7f);
        //Permite que se vuelva a pulsar el boton
        botonPulsadoAhora = false;
        botonPulsadoRec = false;
        //panel.GetComponent<Transform>().GetChild(2).GetChild(4).GetChild(1).GetComponent<Text>().text = "false";
    }

    public abstract void hide();

    public abstract void show();
}

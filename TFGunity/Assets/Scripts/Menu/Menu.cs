using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Menu : MonoBehaviour
{
    /*
     * Es la clase abstracta de los menus, con las distintas funcionalidades que tienen estos
     */

    [Header("Menu Options")]
    [SerializeField] protected GameObject button;

    public int nOptions;
    public GrabController grabController;

    /* Controlan la pulsacion de los botones */
    protected bool botonPulsadoAhora = false;
    protected bool botonPulsadoRec = false;

    /* Opciones del menú */
    public List<GameObject> menuOptions;

    [HideInInspector]
    public bool isPositionSet = false;

    public void Start()
    {
        grabController = GameObject.FindObjectOfType<GrabController>();
    }

    // Crea los potones tiene el menu
    public void Initialize()
    {
        

        menuOptions = new List<GameObject>();
        for (int i = 0; i < nOptions; i++)
        {
            GameObject buttonToSave = Instantiate(button);
            buttonToSave.name = buttonToSave.name + this.name + i;

            if (this.name.Contains("Body"))
            {
                buttonToSave = buttonToSave.transform.GetChild(4).gameObject;
            }

            buttonToSave.GetComponent<ButtonListener>().proximityEvent.AddListener(delegate { this.buttonInteract(buttonToSave.name); });
            buttonToSave.GetComponent<ButtonListener>().actionEvent.AddListener(delegate { this.buttonInteract(buttonToSave.name); });
            buttonToSave.GetComponent<ButtonListener>().contactEvent.AddListener(delegate { this.buttonInteract(buttonToSave.name); });
            buttonToSave.GetComponent<ButtonListener>().defaultEvent.AddListener(delegate { this.buttonExit(buttonToSave.name); });

            if(!this.name.Contains("Slider"))
                buttonToSave.transform.GetChild(3).GetComponentInChildren<Text>().text = (i + 1).ToString();

            menuOptions.Add(buttonToSave);
        }

        foreach(GameObject option in menuOptions)
        {
            option.SetActive(false);
        }
    }

    // Activa los botones cuando se cumplen las condiciones (Manos o esqueleto visibles)
    public void activate()
    {
        foreach (GameObject option in menuOptions)
        {
            option.SetActive(true);
        }
        setPosition();
        isPositionSet = true;
    }

    // Coloca las opciones del menu en el sitio correspondiente
    public abstract void setPosition();

    // Realiza la accion pertinente que le toque al boton correspondiente 
    public void buttonInteract(string name)
    {
        if (!botonPulsadoRec && !botonPulsadoAhora)
        {
            botonPulsadoAhora = true;
            Debug.LogWarning("Accionado boton: " + name);
            if (name.Contains("SwitchMenu"))
            {
                grabController.switchGrab();
            }
            if (name.Contains("Slider"))
            {
                GameObject.FindObjectOfType<SliderController>().enterInZone();
            }
        }
    }

    // Calcula cuando se ha dejado de pulsar el boton
    public void buttonExit(string name)
    {
        if (!botonPulsadoRec && botonPulsadoAhora)
        {
            botonPulsadoRec = true;
            StartCoroutine(ExitButton());
            if (name.Contains("Slider"))
            {
                GameObject.FindObjectOfType<SliderController>().exitFromZone();
            }
        }
    }

    // Temporizador encargado de ver el tiempo que ha pasado desde que se ha dejado de pulsar el boton para evitar pulsaciones solapadas
    IEnumerator ExitButton()
    {
        //Espera dos segundos
        yield return new WaitForSeconds(0.7f);
        //Permite que se vuelva a pulsar el boton
        botonPulsadoAhora = false;
        botonPulsadoRec = false;
        //panel.GetComponent<Transform>().GetChild(2).GetChild(4).GetChild(1).GetComponent<Text>().text = "false";
    }

    // oculta el menu
    public void hide()
    {
        foreach (var option in menuOptions)
        {
            option.SetActive(false);
        }
    }

    // vuelve visible el menu
    public void show()
    {
        foreach (var option in menuOptions)
        {
            option.SetActive(true);
        }
    }
}

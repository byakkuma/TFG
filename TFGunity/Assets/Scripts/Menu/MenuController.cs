using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    /*
     * Se encarga de inicalizar los distintos menus
     */
    private Dictionary<string, GameObject> menus = new Dictionary<string, GameObject>();
    private List<GameObject> activeMenus = new List<GameObject>();
    public GameController gameController;
    private Configuration configuration;
    private bool rightHandActivaate;
    private bool leftHandActivaate;
    private bool bodyActivaate;


    // Guarda todos los menus que hay
    void Start()
    {
        configuration = GameObject.FindObjectOfType<Configuration>();
        foreach (Transform child in this.transform)
        {
            if (child.gameObject.activeSelf)
            {
                menus.Add(child.name, child.gameObject);
            }
        }
        inicialiceMenu();
        // activamos los menu que no necesiten un esqueleto
        if (!menus["BodyMenu"].GetComponent<BodyMenu>().isSetPosition)
        {
            activateBodyMenu();
        }
        gameController.GetComponent<GrabController>().grabOff();        
    }

    // Inicializa cada menu
    public void inicialiceMenu()
    {
        foreach(KeyValuePair<string, GameObject> menu in menus)
        {
            if(!menu.Key.Contains("Switch"))
            {
                menu.Value.GetComponent<Menu>().Initialize();
            } else if (configuration.grab.changeMethod.Equals(grabChange.Button))
            {
                menu.Value.GetComponent<Menu>().Initialize();
            }
        }
    }

    // activamos los menus que necesitan la iniciacion del cuerpo
    public void activateLeftHand()
    {
        menus["FingerMenu"].GetComponent<FingerMenu>().activate();
        menus["SwitchMenu"].GetComponent<SwitchMenu>().activate();
        // guardamos la posicion del indice en cuanto lo detectamos        
    }

    public void activateRightHand()
    {
        if(bodyActivaate)
            menus["ForearmSliderMenu"].GetComponent<ForearmSliderMenu>().menuOptions[0].GetComponent<SliderController>().fingerPosition = GameObject.Find("FingerTipPokeToolIndex(Clone)").transform;
        GameObject.FindObjectOfType<GestureDetection>().iniciate();
    }

    // activamos el menu corporal
    public void activateBodyMenu()
    {
        menus["BodyMenu"].GetComponent<BodyMenu>().activate();
    }

    // activamos los menus que necesitan la iniciacion del esqueleto
    public void activateBody()
    {
        Debug.LogWarning("Entro");
        menus["BodyMenu"].GetComponent<BodyMenu>().activate();
        menus["ForearmMenu"].GetComponent<BodyMenu>().activate();
        if(rightHandActivaate)
            menus["ForearmSliderMenu"].GetComponent<ForearmSliderMenu>().activate();
    }
    
    public void hideMenu()
    {
        foreach (KeyValuePair<string, GameObject> menu in menus)
        {
            if (menu.Value.activeInHierarchy && (menu.Value.GetComponent<Menu>().name.Contains("Finger") || menu.Value.GetComponent<Menu>().name.Contains("Forearm")) && !menu.Value.GetComponent<Menu>().isPositionSet)
            {
                activeMenus.Add(menu.Value);
                menu.Value.GetComponent<Menu>().hide();
            }
        }
    }
    public void showMenu()
    {
        if(activeMenus.Count > 0)
        {
            foreach (GameObject menu in activeMenus)
            {
                if (menu.GetComponent<Menu>().isPositionSet)
                {
                    activeMenus.Remove(menu);
                    menu.GetComponent<Menu>().show();
                    menu.GetComponent<Menu>().activate();
                }
            }
        }
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    private Dictionary<string, GameObject> menus = new Dictionary<string, GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform child in this.transform)
        {
            if (child.gameObject.activeSelf)
            {
                menus.Add(child.name, child.gameObject);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void inicialiceMenu()
    {
        foreach(KeyValuePair<string, GameObject> menu in menus)
        {
            menu.Value.GetComponent<Menu>().Initialize();
        }
    }
}

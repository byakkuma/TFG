using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyMenu : Menu
{
    /*
     * Este scrept se encarga de colocar donde corresponde el menu corporal
     */

    public bool isSetPosition = false;
    public GameObject mesa;

    private void Start()
    {
        // aqui habra que mirar si previamente se a definido ya una posicion para los botones (por ahora simplemente lo dejo a false)
        isSetPosition = false;
    }
    public override void setPosition()
    {
        if (isSetPosition)
        {
            // es este caso se colocaran en la misma posicion en la que estavan anterioremente, que deberia haberse guardado en el fichero
        }
        else
        {
            float longitudMesa = mesa.GetComponent<Collider>().bounds.size.z-1;
            // en este caso se repartiran en la mesa
            for (int i = 0; i < menuOptions.Count; i++)
            {
                Vector3 extremoMesa1 = new Vector3(mesa.transform.position.x, mesa.transform.position.y + 0.1f, mesa.transform.position.z - (longitudMesa / 2.4f));
                Vector3 extremoMesa2 = new Vector3(mesa.transform.position.x, mesa.transform.position.y + 0.1f, mesa.transform.position.z + (longitudMesa / 2.4f));
                menuOptions[i].transform.parent.position = Vector3.Lerp(extremoMesa1, extremoMesa2, i / (menuOptions.Count - 1f));
                
                menuOptions[i].transform.parent.SetParent(this.transform);
            }
        }
    }
}

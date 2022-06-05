using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prueba : MonoBehaviour
{
    // para comprobar donde esta el objeto con respcto al mismo padre
    public Transform seguimiento;
    private Transform seguimientoLocal;


    public GameObject kinect;
    public List<GameObject> bonesPositions;
    public GameObject nearBone;

    // para comprobar la rotacion
    public GameObject player;

    private void Start()
    {
        bonesPositions = new List<GameObject>();
        //seguimientoLocal = this.transform.GetChild(0).transform;
        foreach (Transform child in kinect.transform.GetChild(0))
        {
            bonesPositions.Add(child.gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        // para comprobar donde esta el objeto con respcto al mismo padre
        /*
        seguimientoLocal.position = seguimiento.position;
        float boxMinX = this.GetComponent<BoxCollider>().bounds.extents.x;
        Debug.LogWarning(Math.Abs(seguimientoLocal.localPosition.x - this.transform.localPosition.x - boxMinX));/**/

        // para comprobar la rotacion
        //Vector3 playerDirection = (player.transform.position - this.transform.position);
        //float diference = Vector3.Angle(playerDirection, this.transform.forward);
        //Debug.LogWarning(diference);


        //Debug.LogWarning(this.transform.localEulerAngles.x);
        ////Debug.LogWarning(this.transform.localRotation.x);

        float minDist = Mathf.Infinity; 
        foreach (GameObject bone in bonesPositions)
        {
            float dist = Vector3.Distance(bone.GetComponent<SphereCollider>().bounds.center, this.transform.position);
            if (dist < minDist)
            {
                nearBone = bone;
                minDist = dist;
            }
        }
        Debug.LogWarning(nearBone.name + ": " + minDist);

    }
}

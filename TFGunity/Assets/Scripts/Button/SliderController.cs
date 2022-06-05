using OculusSampleFramework;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    public Transform fingerPosition;

    private bool isInZone = false;
    private float minSliderValue;
    private float maxSliderValue;
    private GameObject sliderObject;
    private Vector3 sliderBase;
    private float distanciaCentro;

    private void Start()
    {
        sliderObject = this.transform.GetChild(3).gameObject;
        sliderBase = sliderObject.transform.GetChild(1).GetChild(0).position;
        minSliderValue = sliderObject.GetComponent<Slider>().minValue;
        maxSliderValue = sliderObject.GetComponent<Slider>().maxValue;

        distanciaCentro = Vector3.Dot(this.transform.position - sliderBase, this.transform.position - sliderBase);
    }

    // Update is called once per frame
    void Update()
    {
        if (isInZone)
        {
            float distancia = Vector3.Dot(this.transform.position - sliderBase, fingerPosition.position - sliderBase);
            distancia = ((distancia * ((maxSliderValue - minSliderValue) / 2)) / distanciaCentro);

            if (distancia < minSliderValue)
                distancia = minSliderValue;
            else if (distancia > maxSliderValue)
                distancia = maxSliderValue;
            sliderObject.GetComponent<Slider>().value = distancia;
        }
    }

    public void enterInZone()
    {
        isInZone = true;
    }
    public void exitFromZone()
    {
        isInZone = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RGB_Controller : MonoBehaviour
{
    public Material material;
    public Slider redSlider;
    public Slider greenSlider;
    public Slider blueSlider;

    public void ChangeColor()
    {
        material.color = new Color(redSlider.value, greenSlider.value, blueSlider.value, 1f);
    }

    /*Hoe het wertkt:
     * Zet de material op de op het object waar je de kleur van wilt veranderen.
     * Zet het script op de camera.
     * Voeg een material toe aan het script.
     * Voeg de 3 sliders toe aan het script.*/

}

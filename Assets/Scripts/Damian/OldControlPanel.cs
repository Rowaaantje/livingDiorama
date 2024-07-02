using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldControlPanel : MonoBehaviour
{
    [Header("Select Objects to control")]
    public GameObject[] objects;

    [Header("Select Lights to control")]
    public Light[] lights;

    [Header("Select the animations to control")]
    public Animator[] animators;

    public enum ObjectState
    {
        On,
        Off
    }

    [Header("Object visible")]
    [Tooltip("Every object that are assigned in the list will be shown or hidden")]
    public ObjectState objectVisibility;

    [Header("Object color")]
    [Tooltip("Changes the color of the list assigned objects")]
    public Color objectColor = Color.white;

    [Space(15)]

    [Header("Lights on or off")]
    [Tooltip("Every light that are assigned in the list will be on or off")]
    public ObjectState lightState;

    [Header("Light color")]
    [Tooltip("Changes the color of the list assigned lights")]
    public Color lightColor = Color.white;

    [Header("Animation Controls")]
    [Tooltip("Toggle animations on or off")]
    public bool playAnimations = true;

    [Tooltip("Set the speed of the animations")]
    [Range(0.1f, 3.0f)]
    public float animationSpeed = 1.0f;

    private void OnValidate()
    {
        UpdateObjectVisibility();
        UpdateLightState();
        UpdateObjectColor();
        UpdateLightColor();
        UpdateAnimationState();
        UpdateAnimationSpeed();
    }

    void UpdateObjectVisibility()
    {
        if (objects != null)
        {
            foreach (GameObject obj in objects)
            {
                if (obj != null)
                {
                    switch (objectVisibility)
                    {
                        case ObjectState.On:
                            obj.SetActive(true);
                            break;
                        case ObjectState.Off:
                            obj.SetActive(false);
                            break;
                    }
                }
            }
        }
    }

    void UpdateLightState()
    {
        if (lights != null)
        {
            foreach (Light light in lights)
            {
                if (light != null)
                {
                    light.enabled = (lightState == ObjectState.On);
                }
            }
        }
    }

    void UpdateObjectColor()
    {
        foreach (GameObject obj in objects)
        {
            if (obj != null)
            {
                Renderer renderer = obj.GetComponent<Renderer>();
                if (renderer != null)
                {
                    renderer.sharedMaterial.color = objectColor;
                }
            }
        }
    }

    void UpdateLightColor()
    {
        if (lights != null)
        {
            foreach (Light light in lights)
            {
                if (light != null)
                {
                    light.color = lightColor;
                }
            }
        }
    }

    void UpdateAnimationState()
    {
        foreach (Animator animator in animators)
        {
            if (animator != null)
            {
                if (playAnimations)
                {
                    animator.speed = animationSpeed;
                    animator.Play("AnimationName");
                }
                else
                {
                    animator.speed = 0;
                }
            }
        }
    }

    void UpdateAnimationSpeed()
    {
        foreach (Animator animator in animators)
        {
            if (animator != null)
            {
                animator.speed = animationSpeed;
            }
        }
    }

    public void ChangeObjectColor(Color newColor)
    {
        objectColor = newColor;
        UpdateObjectColor();
    }

    public void ChangeLightColor(Color newColor)
    {
        lightColor = newColor;
        UpdateLightColor();
    }
}

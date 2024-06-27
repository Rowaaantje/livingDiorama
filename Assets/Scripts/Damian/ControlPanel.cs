using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPanel : MonoBehaviour
{
    [Header("Choose to Show or hide objects")]
    public ObjectState hideShowObject;

    [Header("Choose to turn lights on or off")]
    public ObjectState lightControl;

    [Header("Add all lights you want to control")]
    public Light[] lights;

    [Header("Add all Objects you want to hide or show")]
    public GameObject[] objects;

    private void OnValidate()
    {
        UpdateObjectsState();
        UpdateLightState();
    }

    void UpdateObjectsState()
    {
        if (objects != null)
        {
            foreach (GameObject obj in objects)
            {
                if (obj != null)
                {
                    switch (hideShowObject)
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
                    switch (lightControl)
                    {
                        case ObjectState.On:
                            light.enabled = true;
                            break;
                        case ObjectState.Off:
                            light.enabled = false;
                            break;
                    }
                }
            }
        }
    }

    public enum ObjectState
    {
        On,
        Off
    }
}

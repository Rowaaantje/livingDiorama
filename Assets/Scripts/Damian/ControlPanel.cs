using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ControlPanel", menuName = "scripts/ControlPanel", order = 1)]
public class ControlPanel : ScriptableObject
{
    [Header("Choose to Show or hide objects")]
    public ObjectState hideShowObject;

    [Header("Choose to turn lights on or off")]
    public ObjectState lightControl;

    [Header("Add all lights you want to control")]
    public List<Light> lights = new List<Light>();

    [Header("Add all Objects you want to hide or show")]
    public List<GameObject> objects = new List<GameObject>();

    public void UpdateObjectsState()
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

    public void UpdateLightState()
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

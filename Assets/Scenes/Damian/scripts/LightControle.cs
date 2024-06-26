using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class LightControle : MonoBehaviour
{
    public List<Light> lights = new List<Light>();
    public Toggle toggle;

    void Start()
    {
        if (toggle == null)
        {
            Debug.LogError("Toggle component not assigned in LightControl script.");
            return;
        }

        toggle.onValueChanged.AddListener(ToggleLights);
    }

    void ToggleLights(bool isOn)
    {
        foreach (Light light in lights)
        {
            light.enabled = isOn;
        }
    }

    void OnDestroy()
    {
        toggle.onValueChanged.RemoveListener(ToggleLights);
    }
}

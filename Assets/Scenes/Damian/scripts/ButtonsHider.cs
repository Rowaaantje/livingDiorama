using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsHider : MonoBehaviour
{
    public List<MonoBehaviour> UIElements = new List<MonoBehaviour>();
    public Toggle ToggleButton;
    public string ShowText = "Show";
    public string HideText = "Hide";

    void Start()
    {
        if (UIElements.Count == 0)
        {
            Debug.LogError("UIElements list is empty. Please assign UI elements in the Inspector.");
            return;
        }

        if (ToggleButton == null)
        {
            Debug.LogError("ToggleButton is not assigned. Please assign a toggle in the Inspector.");
            return;
        }

        Text toggleText = ToggleButton.GetComponentInChildren<Text>();
        if (toggleText != null)
        {
            toggleText.text = UIElements[0].gameObject.activeSelf ? HideText : ShowText;
        }
        else
        {
            Debug.LogError("ToggleButton does not have a Text component.");
        }

        ToggleButton.onValueChanged.AddListener(delegate {
            ButtonShowHide(ToggleButton.isOn);
        });
    }

    public void ButtonShowHide(bool isOn)
    {
        foreach (MonoBehaviour element in UIElements)
        {
            if (element != null)
            {
                element.gameObject.SetActive(isOn);
                if (element.gameObject.activeSelf)
                {
                    bool anyActive = true;

                }
            }
            else
            {
                Debug.LogWarning("An element in the UIElements list is null. Please check your assignments.");
            }
        }

        Text toggleText = ToggleButton.GetComponentInChildren<Text>();
        if (toggleText != null)
        {
            toggleText.text = isOn ? HideText : ShowText;
        }
        else
        {
            Debug.LogError("ToggleButton does not have a Text component.");
        }
    }
}

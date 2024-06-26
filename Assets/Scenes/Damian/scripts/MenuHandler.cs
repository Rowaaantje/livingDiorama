using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuHandler : MonoBehaviour
{
    public string mainMenuSceneName = "MainMenu"; 
    public GameObject popupGameObject; 

    public void MainMenuButton()
    {
        SceneManager.LoadScene(mainMenuSceneName);
    }

    public void ShowPopupButton()
    {
        if (popupGameObject != null)
        {
            popupGameObject.SetActive(true);
        }
        else
        {
            Debug.LogWarning("Popup GameObject is not assigned.");
        }
    }

    public void ClosePopupButton()
    {
        if (popupGameObject != null)
        {
            popupGameObject.SetActive(false);
        }
        else
        {
            Debug.LogWarning("Popup GameObject is not assigned.");
        }
    }
}

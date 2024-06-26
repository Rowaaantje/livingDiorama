using UnityEngine;
using TMPro;

public class PlayPause : MonoBehaviour
{
    public TMP_Text buttonText; 

    private bool isPlaying = false;

    void Start()
    {
        buttonText.text = "Play";
    }

    public void TogglePlayPause()
    {
        isPlaying = !isPlaying;
        buttonText.text = isPlaying ? "Pause" : "Play";
        Debug.Log("test");
    }
}

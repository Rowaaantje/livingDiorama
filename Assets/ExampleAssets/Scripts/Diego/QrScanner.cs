using System.Collections;
using System.Collections.Generic;
//using ZXing;
//using IronBarCode;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class QrScanner : MonoBehaviour
{
    [SerializeField]
    private RawImage imageBackground;
    [SerializeField]
    private AspectRatioFitter aspectRatioFitter;
    [SerializeField]
    private TextMeshProUGUI textOutput;
    [SerializeField]
    private RectTransform scanZone;

    private bool cameraInitialized;
    private WebCamTexture cameraTexture;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void InitializeCamera()
    {
        WebCamDevice[] devices = WebCamTexture.devices;

        if (devices.Length == 0)
        {
            cameraInitialized = false;
            return;
        }

        /*for (int i = 0; i <device.Length> == 0; i++) 
        { 
            cameraInitialized = false;
        }*/
    }
}

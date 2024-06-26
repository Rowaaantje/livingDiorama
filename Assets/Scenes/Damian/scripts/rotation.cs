using UnityEngine;
using UnityEngine.UI;

public class rotation : MonoBehaviour
{
    public GameObject targetObject; 
    public float rotationSpeed = 180f;

    private Slider slider;

    void Start()
    {
        slider = GetComponent<Slider>();

        slider.onValueChanged.AddListener(OnSliderValueChanged);
    }

    void OnSliderValueChanged(float value)
    {
        float angle = value * 360f;

        targetObject.transform.rotation = Quaternion.Euler(0f, angle, 0f);
    }
}

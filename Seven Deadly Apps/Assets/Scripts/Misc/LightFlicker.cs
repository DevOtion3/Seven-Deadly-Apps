using DG.Tweening;
using UnityEngine;

public class LightFlicker : MonoBehaviour
{
    public Light flickerLight;

    public float maxIntensity = 1f;
    public float minIntensity = 0f;
    public float flickerInterval = 0.5f;

    private float nextFlickerTime;
    private Color[] flickerColors = {
        new Color(1f, 1f, 1f, 0.5f),     // White with 50% opacity
        new Color(0.464f, 0.141f, 0.141f, 0.5f), // Red with 50% opacity
        new Color(0f, 0.008f, 0.106f)    // Dark blue
    };

    private void Start()
    {
        if (flickerLight == null)
        {
            flickerLight = GetComponent<Light>();
        }
    }

    private void Update()
    {
        if (flickerLight != null && Time.time >= nextFlickerTime)
        {
            DOVirtual.Float(flickerLight.intensity, Random.Range(minIntensity, maxIntensity), 0.25f,
                value => flickerLight.intensity = value);
            DOVirtual.Color(flickerLight.color, flickerColors[Random.Range(0, flickerColors.Length)], 0.25f,
                value => flickerLight.color = value);
            nextFlickerTime = Time.time + Random.Range(0, flickerInterval);
        }
    }
}

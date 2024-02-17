using UnityEngine;

public class LightFlicker : MonoBehaviour
{
    public Light flickerLight;

    public float maxIntensity = 1f;
    public float minIntensity = 0f;
    public float flickerInterval = 0.5f;

    private float nextFlickerTime;
    private Color[] flickerColors = { new Color(1f, 1f, 1f, 0.5f), new Color(0f, 0f, 0f, 0.5f), new Color(0.464f, 0.141f, 0.141f, 0.5f)};

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
            flickerLight.intensity = Random.Range(minIntensity, maxIntensity);
            flickerLight.color = flickerColors[Random.Range(0, flickerColors.Length)];
            nextFlickerTime = Time.time + Random.Range(0, flickerInterval);
        }
    }
}

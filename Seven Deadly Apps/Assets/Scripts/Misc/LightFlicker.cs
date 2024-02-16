using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LightFlicker : MonoBehaviour{
    public Light flickerLight;

    public float maxIntensity;
    public float minIntensity;
    public float flickerInterval;

    float nextFlickerTime;

    public void Start(){
        if(flickerLight == null){
            flickerLight = GetComponent<Light>();
        }
    }

    public void Update(){
        if(flickerLight != null && Time.time >= nextFlickerTime){
            flickerLight.intensity = Random.Range(minIntensity, maxIntensity);
            flickerLight.color = Random.ColorHSV(0, 1, 0, 1, 1, 1);
            nextFlickerTime = Time.time + Random.Range(0, flickerInterval);
        }
    }
}

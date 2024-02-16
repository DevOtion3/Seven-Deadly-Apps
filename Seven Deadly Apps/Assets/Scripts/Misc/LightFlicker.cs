using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LightFlicker : MonoBehaviour{
    public Light light;

    public float maxIntensity;
    public float minIntensity;
    public float flickerInterval;

    float nextFlickerTime;

    public void Update(){
        if(Time.time >= nextFlickerTime){
            light.intensity = Random.Range(minIntensity, maxIntensity);
            nextFlickerTime = Time.time + Random.Range(0, flickerInterval);
        }
    }
}

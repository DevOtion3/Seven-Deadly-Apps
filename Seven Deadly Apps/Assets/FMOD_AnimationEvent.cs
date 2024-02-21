using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class FMOD_AnimationEvent : MonoBehaviour
{
    private FMOD.Studio.EventInstance stepInstane;
    private FMOD.Studio.EventInstance clothInstane;

    public FMODUnity.EventReference stepEvent;
    public FMODUnity.EventReference clothEvent;

    public void PlaySFX(string anim)
    {

        
        if(anim == "step")
        {
            FMODUnity.RuntimeManager.PlayOneShotAttached(stepEvent, gameObject);
        }

        if (anim == "cloth")
        {
            FMODUnity.RuntimeManager.PlayOneShotAttached(clothEvent, gameObject);
        }
    }

    private void Awake()
    {
        stepInstane = RuntimeManager.CreateInstance(stepEvent);
    }

    public void SetParameter(string param, float value)
    {
        stepInstane.setParameterByName(param, value);
        Debug.Log("a");
    }
}
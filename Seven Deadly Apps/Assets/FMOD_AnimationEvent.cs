using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FMOD_AnimationEvent : MonoBehaviour
{
    private FMOD.Studio.EventInstance stepInstane;
    private FMOD.Studio.EventInstance clothInstane;

    public FMODUnity.EventReference stepEvent;
    public FMODUnity.EventReference clothEvent;

    [SerializeField] private float vel;

    private Animator animator;

    
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    
    private void Update()
    {
        vel = animator.GetFloat("Input Magnitude");
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("PlayerVelocity", vel);
    }

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
}
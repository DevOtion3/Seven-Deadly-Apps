using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    new private BoxCollider collider;
    private void Awake()
    {
        collider = GetComponent<BoxCollider>();
    }

    private void Start()
    {
        
    }
}

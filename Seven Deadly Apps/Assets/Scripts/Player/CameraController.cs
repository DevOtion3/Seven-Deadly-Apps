using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject followTarget;
    public float verticalDistance = 10;
    public float moveSpeed = 1;

    private void Update(){
        Vector3 targetPosition = followTarget.transform.position;
        targetPosition.y +=  verticalDistance;

        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * moveSpeed);
    }
}

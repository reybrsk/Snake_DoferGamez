using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{

    private float cameraSpeed;
    
    
    
    // Start is called before the first frame update
   

    // Update is called once per frame
    void FixedUpdate()
    {
        cameraSpeed = FindObjectOfType<SnakeMovement>().speed;
        transform.DOMove(transform.position + Vector3.forward * cameraSpeed * Time.fixedDeltaTime, .1f);
    }
}

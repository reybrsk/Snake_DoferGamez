using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField, Range(0f, 1f)] private float rotationSpeed;
    
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,360f*Time.deltaTime*rotationSpeed,0);
       
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckLineScript : MonoBehaviour
{

    [SerializeField]private Material checkPointMat;
    
    
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Renderer>().material = checkPointMat;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if(other.CompareTag("Player"))
        {
            other.gameObject.GetComponent<MeshRenderer>().material = checkPointMat;
            if (other.gameObject.GetComponent<SnakeConstruct>())
            {
                other.gameObject.GetComponent<SnakeConstruct>().material = checkPointMat;
            }
        }
    }
}

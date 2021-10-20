using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class BodyLookAt : MonoBehaviour
{
    public Transform parrent;

    private float _duration;
    private float _distance;
    // Start is called before the first frame update
    void Start()
    {
        _distance = FindObjectOfType<SnakeConstruct>().distance;
        _duration = FindObjectOfType<SnakeConstruct>().duration;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (parrent != null)
        {
            _duration = FindObjectOfType<SnakeConstruct>().duration;
            transform.LookAt(parrent);
            transform.DOMove(parrent.position - parrent.forward * _distance,_duration);
        }
        
        
    }
    
    
    
}

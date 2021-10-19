using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class SnakeMovement : MonoBehaviour
{
    [SerializeField, Range(0f, 20f)]private float baseSpeed = 12f;
    public float speed;

    private SnakeConstruct _snakeConstruct;

    private void Start()
    {
        _snakeConstruct = FindObjectOfType<SnakeConstruct>();
    }

    void FixedUpdate()
    {
        if (!_snakeConstruct.isFever)
        {
            Move();
        }
        else
        {
            FeverMove();
        }
        
    }

    private void FeverMove()
    {
        speed = baseSpeed * 3f;
        var posVec = new Vector3(0, transform.position.y,
            transform.position.z + Vector3.forward.z * speed * Time.fixedDeltaTime);
        transform.DOMove(posVec, .1f);
    }


    private void Move()
    {
        speed = baseSpeed;
        if (Input.GetMouseButton(0) && Input.mousePosition.x > 50 && Input.mousePosition.x < 500)
        {
       
            var posX = (Input.mousePosition.x / 50f) - 4.5f;
            
            if (posX < -4f || posX > 4f) return;
            
            
            var posVec = new Vector3(posX, transform.position.y,
                transform.position.z + Vector3.forward.z * speed * Time.fixedDeltaTime);
            transform.DOMove(posVec, .1f);
            
        } 
        else
        {
            transform.DOMove(transform.position + Vector3.forward * speed * Time.fixedDeltaTime, .1f);
        }
    }
}

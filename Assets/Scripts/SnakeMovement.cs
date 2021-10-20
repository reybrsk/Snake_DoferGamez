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
    [SerializeField] private Camera camera;

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
        Debug.Log(Input.touchCount + "Input.touchCount");
        if(Input.touchCount > 0)
        {
            
            var touchPosition = Input.GetTouch(0).position;
            var cameraRay = camera.ScreenPointToRay(touchPosition);
            RaycastHit[] hits = Physics.RaycastAll(cameraRay);
            for (int i = 0; i < hits.Length; i++)
            {
                if (hits[i].collider.CompareTag("Floor"))
                {
                    var posX = hits[i].point.x;
                    if (posX < -4f || posX > 4f) return;
                    var posVec = new Vector3(posX, transform.position.y,
                        transform.position.z + Vector3.forward.z * speed * Time.fixedDeltaTime);
                    
                    transform.DOMove(posVec, .1f);
                    
                }
            }
        }
        else
        {
            transform.DOMove(transform.position + Vector3.forward * speed * Time.fixedDeltaTime, .1f);
        }
        
    }
}

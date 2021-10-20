using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class EatScript : MonoBehaviour
{


    private Material _checkMat;
    private SnakeConstruct _snakeConstruct;

    private LevelEvents levelEvents;
    public int _feverCount = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        _snakeConstruct = FindObjectOfType<SnakeConstruct>();
        levelEvents = FindObjectOfType<LevelEvents>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_feverCount == 3)
        {
            _snakeConstruct.isFever = true;
            _feverCount = 0;
            levelEvents.crystalNumber = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (_snakeConstruct.isFever)
        {
            Eat(other.gameObject);
            _feverCount = 0;
            return;
        }
        
        
        if (other.gameObject.CompareTag("Cristal"))
        {
            
            Eat(other.gameObject);
            _feverCount++;
            return;
        }
        
        if (!other.gameObject.CompareTag("Enemy"))
        {
            return;
        }
       
        
        _checkMat = GetComponentInParent<SnakeConstruct>().material;
        var targetMat = other.GetComponentInParent<ColorScript>().material;
        bool isTrueColor = targetMat == _checkMat;
        
        if (isTrueColor)
        {
            Eat(other.gameObject);
            _feverCount = 0;
        }
        else GameOver();



    }

    private void GameOver()
    {
        
        levelEvents.restartPanel.SetActive(true);
        Time.timeScale = 0.1f;
    }

    private void Eat(GameObject eatObject)
    {
        if (eatObject.CompareTag("GameController")) return;
        if (eatObject.CompareTag("Floor")) return;
        

        
        eatObject.transform.DOMove(transform.position, .3f);
        eatObject.transform.DOScale(0f, .3f).OnComplete(()=> Destroy(eatObject));
        if (eatObject.CompareTag("Cristal") && !_snakeConstruct.isFever)
        {
            levelEvents.crystalNumber++;
        }
    }
}

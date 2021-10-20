using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ObstructionDead : MonoBehaviour
{


    [SerializeField] private GameObject boomGameObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && !other.GetComponent<ThisIsBody>()) Death(other.gameObject);
    }

    private void Death(GameObject other)
    {
        if (!other.GetComponent<SnakeConstruct>() || !other.GetComponent<SnakeConstruct>().isFever)
            
        {
            transform.DOMove(other.transform.position, 1f);
            transform.DOScale(0f, 1f);
            Instantiate(boomGameObject, other.transform.position, Quaternion.identity);
            other.transform.DOScale(Vector3.one, .3f);

            LevelEvents levelEvents = FindObjectOfType<LevelEvents>();
            levelEvents.restartPanel.SetActive(true);

            
            Destroy(other);
            Destroy(gameObject);
            Time.timeScale = .1f;
        }



    }
}

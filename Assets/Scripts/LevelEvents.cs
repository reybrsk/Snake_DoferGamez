using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEvents : MonoBehaviour
{

    public GameObject restartPanel;
    public int crystalNumber;
    private SnakeConstruct _snakeConstruct;

    private void Start()
    {
        _snakeConstruct = FindObjectOfType<SnakeConstruct>();
    }

   

    public void Restart()
    {
        SceneManager.LoadScene("SampleScene");
    }
}

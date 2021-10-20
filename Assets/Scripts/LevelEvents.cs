using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEvents : MonoBehaviour
{

    public GameObject restartPanel;
    public int crystalNumber;
    

   

    public void Restart()
    {
        SceneManager.LoadScene("SampleScene");
    }
}

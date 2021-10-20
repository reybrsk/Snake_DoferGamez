using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrystalCount : MonoBehaviour
{
    private Text text;
    private LevelEvents _levelEvents;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        text.text = $"0";
        _levelEvents = FindObjectOfType<LevelEvents>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = _levelEvents.crystalNumber.ToString();
    }
}

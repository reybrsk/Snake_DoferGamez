using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeConstruct : MonoBehaviour
{
    [SerializeField] private int snakeLength;
    [SerializeField] private GameObject body;
    [SerializeField,Range(0f,1f)] public float distance  = 0.5f;
    [Range(0f,1f)] public float duration;
    private List<GameObject> _bodyMeshes = new List<GameObject>();
    public Material material;
    public bool isFever = false;
    private bool _isFevered = false;
    [SerializeField] private int feverTime = 3;


    // private IEnumerator _coroutine;
    
    private void Start()
    {
        Time.timeScale = 1f;
        
        
        _bodyMeshes.Add(this.gameObject);
        gameObject.GetComponent<Renderer>().material = material;

            for (int i = 1; i-1 < snakeLength; i++)
        {
            var inst = Instantiate(body, transform.position - Vector3.forward * distance * (float)(i + 1),
                Quaternion.identity);
            _bodyMeshes.Add(inst);
            inst.GetComponent<BodyLookAt>().parrent = _bodyMeshes[i - 1].transform;
            inst.GetComponent<Renderer>().material = material;
          
        }
    }

    private void Update()
    {
        if (isFever && !_isFevered)
        {
            StartCoroutine(FeverTimer(feverTime));
             _isFevered = true;
        }
    }
   
    private IEnumerator FeverTimer(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            print("WaitAndPrint " + Time.time);
            isFever = false;
            _isFevered = false;
        }
    }
}

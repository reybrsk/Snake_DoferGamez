using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteAlways]
public class ColorScript : MonoBehaviour
{
    private Renderer[] _renderers;
    [SerializeField] public Material material;
    
    
    // Start is called before the first frame update
    void Start()
    {
        _renderers = gameObject.GetComponentsInChildren<Renderer>();
        for (int i = 0; i < _renderers.Length; i++)
        {
            _renderers[i].material = material;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

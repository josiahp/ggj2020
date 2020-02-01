using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject light;

    void Start()
    { 
        light.transform.GetComponent<Light>().color = Color.red;
        light.transform.GetComponent<Renderer>().material.color = Color.red;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

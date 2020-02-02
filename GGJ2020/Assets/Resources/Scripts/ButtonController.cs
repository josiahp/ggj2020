using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public GameObject activeObject;
    public GameObject inactiveObject;
    public GameObject boxController;

    public BoxController.Mechanism mechanismType;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (activeObject.active)
        {
            activeObject.SetActive(false);
            activeObject.GetComponent<BoxCollider>().enabled = false;
            inactiveObject.SetActive(true);
            inactiveObject.GetComponent<BoxCollider>().enabled = true;
        } else if (inactiveObject.active)
        {
            activeObject.SetActive(true);
            activeObject.GetComponent<BoxCollider>().enabled = true;
            inactiveObject.SetActive(false);
            inactiveObject.GetComponent<BoxCollider>().enabled = false;
        }

        boxController.GetComponent<BoxController>().FlipMechanism(mechanismType);
    }
}

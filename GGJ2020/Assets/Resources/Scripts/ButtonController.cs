using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public GameObject buttonPressed;
    public GameObject buttonUnpressed;

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
        Debug.Log("pressed");
        if (buttonPressed.active)
        {
            Debug.Log("switched1!");
            buttonPressed.SetActive(false);
            buttonPressed.GetComponent<BoxCollider>().enabled = false;
            buttonUnpressed.SetActive(true);
            buttonUnpressed.GetComponent<BoxCollider>().enabled = true;
        } else if (buttonUnpressed.active)
        {
            Debug.Log("switched2!");
            buttonPressed.SetActive(true);
            buttonPressed.GetComponent<BoxCollider>().enabled = true;
            buttonUnpressed.SetActive(false);
            buttonUnpressed.GetComponent<BoxCollider>().enabled = false;
        }
    }
}

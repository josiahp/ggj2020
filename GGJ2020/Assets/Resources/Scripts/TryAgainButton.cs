using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TryAgainButton : MonoBehaviour
{
    public GameObject GameController;
    public GameObject EndPage;
    public GameObject StartPage;

    public void Start()
    {
        gameObject.GetComponentInChildren<Text>().text = "You got " + GameController.GetComponent<GameController>().GetScore().ToString() + " points!";
    }

    public void OnClickTryagainButton ()
    {
        Application.Quit();
    }
}

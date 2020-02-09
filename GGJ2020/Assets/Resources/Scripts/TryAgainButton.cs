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
    }

    public void OnClickTryagainButton ()
    {
        EndPage.SetActive(false);
        GameController.GetComponent<GameController>().StartGame();
    }

    public void OnClickQuitButton ()
    {
        Application.Quit();
    }
   
}

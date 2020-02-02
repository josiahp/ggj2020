using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TryAgainButton : MonoBehaviour
{
    public GameObject GameController;
    public GameObject EndPage;
    public GameObject StartPage;
    public void OnClickTryagainButton ()
    {
        EndPage.SetActive(false);
        GameController.GetComponent<GameController>().StartGame();
    }
}

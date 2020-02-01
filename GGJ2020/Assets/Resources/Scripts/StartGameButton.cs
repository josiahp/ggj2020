using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameButton : MonoBehaviour
{
    public GameObject Parent;
    public GameObject GameController;

    public void OnClickStartButton ()
    {
        Parent.SetActive(false);
        GameController.GetComponent<GameController>().StartGame();
    }

}

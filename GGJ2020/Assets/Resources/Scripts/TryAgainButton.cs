using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TryAgainButton : MonoBehaviour
{
    public GameObject StartPage;
    public GameObject GameController;
    public void OnClickTryagainButton ()
    {
        StartPage.SetActive(false);
    }
}

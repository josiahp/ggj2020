using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject StartPage;
    public GameObject Timer;

    public float conveyorBeltSpeed = 1.0f;
    private float speedModifier = -0.5f;

    private List<GameObject> boxes = new List<GameObject>();

    // public string gameState = "not started";
    private GameStates gameState = GameStates.NOT_STARTED;
    public enum GameStates : byte{
        NOT_STARTED = 0,
        STARTED,
        FINISHED
    }

    public void StartGame()
    {
        gameState = GameStates.STARTED;
    }

    // Start is called before the first frame update
    void Start()
    {
        StartPage.SetActive(true);
        StartCoroutine("GenerateBoxes");
        StartCoroutine("DeleteBoxes");
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject box in boxes.ToArray())
        {
            box.transform.position = box.transform.position + new Vector3(GetConveyerBeltSpeed() * Time.deltaTime, 0f, 0f);
        }
    }

    private IEnumerator GenerateBoxes()
    {
        while (true)
        {
            GameObject box;

            bool isChicken = Random.Range(0, 50) == 0;
            if (isChicken)
            {
                Debug.Log("CHICKEN");
                box = Instantiate(Resources.Load<GameObject>("Prefabs/chicken leg piece"));
            } else
            {
                box = Instantiate(Resources.Load<GameObject>("Prefabs/Placeholder"));
            }

            box.transform.RotateAround(box.GetComponentInChildren<Renderer>().bounds.center, Vector3.up, Random.Range(-10.0f, 10.0f));

            bool isComicallyLarge = Random.Range(0, 50) == 0;
            if (isComicallyLarge)
            {
                box.transform.localScale += new Vector3(1.0f, 1.0f, 1.0f);
            }

            boxes.Add(box);
            yield return new WaitForSeconds(4);
        }
    }

    private IEnumerator DeleteBoxes()
    {
        while (true)
        {
            if(boxes[0].transform.position.x <= -3) 
            {
                Destroy(boxes[0]);
                boxes.RemoveAt(0);
            }
            yield return new WaitForSeconds(1);
        }
    }

    public float GetConveyerBeltSpeed()
    {
        return conveyorBeltSpeed * speedModifier;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject StartPage;
    public GameObject Timer;
    public GameObject EndPage;

    public float conveyorBeltSpeed = 1.0f;
    private float speedModifier = -0.5f;

    public int count;
    public int score;

    private List<GameObject> boxes = new List<GameObject>();

    private GameStates gameState = GameStates.NOT_STARTED;
    public enum GameStates : byte {
        NOT_STARTED = 0,
        STARTED,
        FINISHED
    }

    public void StartGame()
    {   
        count = 10;
        gameState = GameStates.STARTED;
        InvokeRepeating("Ticker", 0, 1f);
        Timer.SetActive(true);
    }

    public void Ticker()
    {
        if (count != 0) {
            Timer.GetComponentInChildren<Text>().text = "TIME: " + count.ToString();
            count--;
        } else if (count == 0) {
            gameState = GameStates.FINISHED;
            CancelInvoke();
            Timer.SetActive(false);
            EndPage.SetActive(true);
            score = 0;
        }
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
                box = Instantiate(Resources.Load<GameObject>("Prefabs/HappyDevice"));
            }

            box.transform.RotateAround(box.GetComponentInChildren<Renderer>().bounds.center, Vector3.up, Random.Range(-10.0f, 10.0f));

            bool isComicallyLarge = Random.Range(0, 50) == 0;
            if (isComicallyLarge)
            {
				box.transform.localScale *= 3.0f;
            }

            boxes.Add(box);
            yield return new WaitForSeconds(4);
        }
    }

    private IEnumerator DeleteBoxes()
    {
        while (true)
        {
            // Debug.Log(boxes[0].GetComponentInChildren);
            if(boxes[0].transform.position.x <= -1.5)
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

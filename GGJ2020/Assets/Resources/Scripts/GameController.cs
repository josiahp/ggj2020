using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject StartPage;
    public float conveyorBeltSpeed = 1.0f;
    private float speedModifier = -0.5f;

    private List<GameObject> boxes = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        StartPage.SetActive(true);
        StartCoroutine("GenerateBoxes");
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
            boxes.Add(Instantiate(Resources.Load<GameObject>("Prefabs/Placeholder")));
            
          

            yield return new WaitForSeconds(3);
        }
    }

    public float GetConveyerBeltSpeed()
    {
        return conveyorBeltSpeed * speedModifier;
    }

}

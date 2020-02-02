using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogsController : MonoBehaviour
{
    public GameObject GameController;
    private GameObject dog2, dog1;

    private float dog2PositionX = 1;
    private float dog1PositionX = -1;

    // Start is called before the first frame update
    void Start()
    {
        dog2 = Instantiate(Resources.Load<GameObject>("Prefabs/dog2"));
        dog1 = Instantiate(Resources.Load<GameObject>("Prefabs/dog1"));
        dog2.transform.position = new Vector3(-2f, 0.5f, 0.3f);
        dog1.transform.position = new Vector3(4f, 0.5f, 0.3f);
    }

    // Update is called once per frame
    void Update()
    {
        dog2.transform.position = dog2.transform.position + new Vector3((GameController.GetComponent<GameController>().GetConveyerBeltSpeed() - 0.3f) * Time.deltaTime * dog2PositionX, 0f, 0f);
        dog1.transform.position = dog1.transform.position + new Vector3((GameController.GetComponent<GameController>().GetConveyerBeltSpeed() + 0.1f) * Time.deltaTime * dog1PositionX, 0f, 0f);

        if (dog2.transform.position.x <= -5.0f || dog2.transform.position.x >= 5.0f )
        {
            dog2PositionX = dog2PositionX * -1;
            dog2.transform.Rotate(0f, 0f, dog2.transform.rotation.z + 180f * dog2PositionX);
        }
        if (dog1.transform.position.x <= -4.0f || dog1.transform.position.x >= 5.0f )
        {
            dog1PositionX = dog1PositionX * -1;
            dog1.transform.Rotate(0f, 0f, dog1.transform.rotation.z - 180f * dog1PositionX);
        }
    }
}

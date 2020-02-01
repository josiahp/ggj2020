using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBeltController : MonoBehaviour
{
    private GameObject conveyorBelt1, conveyorBelt2;

    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine("Movement");
        conveyorBelt1 = Instantiate(Resources.Load<GameObject>("Prefabs/Conveyor Belt"));
        conveyorBelt2 = Instantiate(Resources.Load<GameObject>("Prefabs/Conveyor Belt"));

        conveyorBelt1.transform.position = new Vector3(3.0f, 0.1f, -0.5f);
        conveyorBelt2.transform.position = new Vector3(conveyorBelt1.transform.position.x + conveyorBelt2.GetComponentInChildren<Renderer>().bounds.size.x, 0.1f, -0.5f);

    }

    // Update is called once per frame
    void Update()
    {
        conveyorBelt1.transform.position = conveyorBelt1.transform.position + new Vector3(-0.5f * Time.deltaTime, 0f, 0f);
        conveyorBelt2.transform.position = conveyorBelt2.transform.position + new Vector3(-0.5f * Time.deltaTime, 0f, 0f);

        if (conveyorBelt1.transform.position.x <= -6.0f)
        {
            conveyorBelt1.transform.position = new Vector3(conveyorBelt2.transform.position.x + conveyorBelt2.GetComponentInChildren<Renderer>().bounds.size.x, 0.1f, -0.5f);
        }
        else if (conveyorBelt2.transform.position.x <= -6.0f)
        {
            conveyorBelt2.transform.position = new Vector3(conveyorBelt1.transform.position.x + conveyorBelt1.GetComponentInChildren<Renderer>().bounds.size.x, 0.1f, -0.5f);
        }
    }

    /*
    private IEnumerator Movement()
    {
        Vector3 pos = this.gameObject.transform.position;
        pos.x += 1.0f;
        

        yield return new WaitForSeconds(1f);
    }*/
}

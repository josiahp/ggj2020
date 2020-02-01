using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightPulse : MonoBehaviour
{
    Light lt;
    float originalRange;
    float duration = 1.0f;

    private Material redLight;
    private Material yellowLight;
    private Material greenLight;

    void Start()
    {
        lt = GetComponentInChildren<Light>();
        originalRange = lt.range;

        int rnd = Random.Range(0, 3);

        if (rnd == 0)
        {
            redLight = Resources.Load<Material>("Materials/Red Light");
            gameObject.GetComponent<MeshRenderer>().material = redLight;
            lt.color = Color.red;
        } else if (rnd == 1)
        {
            yellowLight = Resources.Load<Material>("Materials/Yellow Light");
            gameObject.GetComponent<MeshRenderer>().material = yellowLight;
            lt.color = Color.yellow;
        }
        else if (rnd == 2)
        {
            greenLight = Resources.Load<Material>("Materials/Green Light");
            gameObject.GetComponent<MeshRenderer>().material = greenLight;
            lt.color = Color.green;
        }


    }

    void Update()
    {
        var amplitude = Mathf.PingPong(Time.time, duration);

        // Transform from 0..duration to 0.5..1 range.
        amplitude = amplitude / duration * 2f + 0.5f;

        // Set light range.
        lt.range = originalRange * amplitude;
    }
}

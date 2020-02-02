using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightPulse : MonoBehaviour
{
    Light lt;
    float originalRange;
    float duration = 1.0f;


    void Start()
    {
        lt = GetComponentInChildren<Light>();
        originalRange = lt.range;

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

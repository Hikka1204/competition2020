using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blinker : MonoBehaviour
{

    public float interval = 1.0f;

    void Start()
    {
        StartCoroutine("Blink");
    }

    IEnumerator Blink()
    {
        while (true)
        {
            var renderComponent = GetComponent<Renderer>();
            var lightComponent = GetComponent<Light>();
            renderComponent.enabled = !renderComponent.enabled;
            lightComponent.enabled = !lightComponent.enabled;
            yield return new WaitForSeconds(interval);
        }
    }

}
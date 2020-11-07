using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class op_room_lighting : MonoBehaviour
{
    public float interval = 1.0f;
    [SerializeField] private Material _default;
    [SerializeField] private Material _change;

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
            renderComponent.material = _default;
            lightComponent.enabled = !lightComponent.enabled;
            yield return new WaitForSeconds(interval);
            renderComponent.material = _change;
            lightComponent.enabled = !lightComponent.enabled;
            yield return new WaitForSeconds(interval);
        }
    }
}

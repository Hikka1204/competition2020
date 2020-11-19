using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class op_room_lighting : MonoBehaviour
{
    public float interval = 1.0f;
    [SerializeField] private Material _default;
    [SerializeField] private Material _change;
    private GameObject Child;
    private bool isEvent;   

    void Start()
    {
        isEvent = false;
        StartCoroutine("Blink");
    }

    private void OnEnable()
    {
        StartCoroutine("Blink");
    }

    public void setIsEvent(bool a)
    {
        isEvent = a;
    }

    IEnumerator Blink()
    {
        while (true)
        {
            var renderComponent = GetComponent<Renderer>();
            var lightComponent = GetComponent<Light>();
            renderComponent.material = _default;
            lightComponent.enabled = false;
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            yield return new WaitForSeconds(interval);
            if (isEvent == true) yield break;
            renderComponent.material = _change;
            lightComponent.enabled = true;
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            yield return new WaitForSeconds(interval);
        }
    }
}

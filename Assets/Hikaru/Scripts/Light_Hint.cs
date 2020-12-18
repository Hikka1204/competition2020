using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light_Hint : MonoBehaviour
{
    public float interval = 1.0f;
    //[SerializeField] private Material _default;
    //[SerializeField] private Material _change;
    private GameObject Child;
    private bool isEvent = false;
    private bool stopEvent = false;

    void Start()
    {
        isEvent = false;
        stopEvent = false;
        //StartCoroutine("Blink");
    }

    private void OnEnable()
    {
        //StartCoroutine("Blink");
    }

    public void setIsEvent(bool a)
    {
        stopEvent = a;
    }

    private void Update()
    {
        if (isEvent == false)
        {
            isEvent = true;
            stopEvent = false;
            StartCoroutine("Blink");
        }
    }

    private IEnumerator Blink()
    {
        while (true)
        {
            //var renderComponent = GetComponent<Renderer>();
            var lightComponent = gameObject.transform.GetChild(0).gameObject.GetComponent<Light>();
            //renderComponent.material = _default;
            lightComponent.enabled = false;
            //gameObject.transform.GetChild(0).gameObject.SetActive(false);
            yield return new WaitForSeconds(interval);
            if (stopEvent == true) yield break;
            //renderComponent.material = _change;
            lightComponent.enabled = true;
            //gameObject.transform.GetChild(0).gameObject.SetActive(true);
            yield return new WaitForSeconds(interval);
        }
    }

}

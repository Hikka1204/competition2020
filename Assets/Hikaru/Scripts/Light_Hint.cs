using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light_Hint : MonoBehaviour
{
    public float interval = 1.0f;
    [SerializeField] private float MaxInterval = 0.5f;
    [SerializeField] private float MinInterval = 0.1f;
    float IntervalSum = 0.2f;
    private Material _default;
    [SerializeField] private Material _change;
    //private bool isEvent = false;
    private bool stopEvent = false;

    void Start()
    {
        //isEvent = false;
        _default = GetComponent<Renderer>().material;
        stopEvent = false;
        //StartCoroutine("Blink");
    }

    private void OnEnable()
    {
        //StartCoroutine("Blink");
    }

    public void StopLight()
    {
        stopEvent = true;
    }

    public void StartLight()
    {
        stopEvent = false;
        StartCoroutine("Blink");
    }

    //private void Update()
    //{
    //    if (isEvent == false)
    //    {
    //        isEvent = true;
    //        stopEvent = false;
    //        StartCoroutine("Blink");
    //    }
    //}

    private IEnumerator Blink()
    {
        while (true)
        {
            var renderComponent = GetComponent<Renderer>();
            var lightComponent1 = gameObject.transform.GetChild(0).gameObject.GetComponent<Light>();
            var lightComponent2 = gameObject.transform.GetChild(1).gameObject.GetComponent<Light>();
            float random = Random.Range(MinInterval, MaxInterval);
            Debug.Log(random);
            renderComponent.material = _default;
            lightComponent1.enabled = false;
            lightComponent2.enabled = false;
            //gameObject.transform.GetChild(0).gameObject.SetActive(false);
            //gameObject.transform.GetChild(1).gameObject.SetActive(false);
            yield return new WaitForSeconds(random);
            random = Random.Range(MinInterval, MaxInterval);
            if (stopEvent == true) yield break;
            renderComponent.material = _change;
            lightComponent1.enabled = true;
            lightComponent2.enabled = true;
            //gameObject.transform.GetChild(0).gameObject.SetActive(true);
            yield return new WaitForSeconds(random);
        }
    }

}

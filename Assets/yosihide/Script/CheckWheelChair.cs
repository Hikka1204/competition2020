using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckWheelChair : MonoBehaviour
{
    GameObject WheelChair;
    WheelChairMove wcm;
    WheelChair_Check wcc;

    // Start is called before the first frame update
    void Start()
    {
        WheelChair = GameObject.Find("Wheelchair");
        wcm = WheelChair.GetComponent<WheelChairMove>();
        wcc = WheelChair.GetComponent<WheelChair_Check>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            wcm.enabled = true;
        }

        if(other.gameObject.tag == "Wall")
        {
            wcc.enabled = true;
            wcm.enabled = false;
        }
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextController : MonoBehaviour
{
    void Start()
    {
        if (this.gameObject.name.Contains("Staff"))
            transform.localScale = new Vector3(-1f, 1f, 1f);
        else if(this.gameObject.name.Contains("Room"))
        transform.localScale = new Vector3(-0.15f, 0.15f, 0.1f);
    }

    void Update()
    {
        transform.LookAt(Camera.main.transform);
    }


    //private void OnTriggerEnter(Collider other)
    //{
    //    if(other.gameObject.tag == "Hand")
    //        this.gameObject.SetActive(true);
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.gameObject.tag == "Hand")
    //        this.gameObject.SetActive(false);
    //}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextOnoff : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Hand")
            this.transform.GetChild(1).gameObject.SetActive(true);
        //this.gameObject.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Hand")
            this.transform.GetChild(1).gameObject.SetActive(false);
    }
}

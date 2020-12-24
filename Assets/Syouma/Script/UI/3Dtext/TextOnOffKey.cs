using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextOnOffKey : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Hand")
            this.transform.GetChild(0).gameObject.SetActive(true);
        Debug.Log("aaaaaaaaaa");
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Hand")
            this.transform.GetChild(0).gameObject.SetActive(false);
    }

}

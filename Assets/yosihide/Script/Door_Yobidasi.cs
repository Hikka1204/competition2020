using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Yobidasi : MonoBehaviour
{
    GameObject Door;
    AutomaticDoor script;
    float currenttime = 3.0f;
    float t_time = 0.0f;
    AudioSource audioSource;
    //public AudioClip TentekibouSE;

    void Start()
    {
        Door = GameObject.Find("Door");
        script = GetComponent<AutomaticDoor>();
        //script = Door.GetComponent<AutomaticDoor>();
        //audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            //script.enabled = true;
            //audioSource.PlayOneShot(TentekibouSE);
        }
    }
}

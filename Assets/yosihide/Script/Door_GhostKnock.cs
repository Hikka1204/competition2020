using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_GhostKnock : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] AudioClip KnockSE;
    GameObject Door;
    VibrateController Vibscript;

    

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        Door = GameObject.Find("Door_Pivot");
        Vibscript = Door.gameObject.GetComponent<VibrateController>();
        //Vibscript.enabled = false;
        
    }

    private void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            
            audioSource.PlayOneShot(KnockSE);
            Destroy(gameObject.GetComponent<Door_GhostKnock>());
            
            
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nursecall : MonoBehaviour
{
    //効果音の設定
    AudioSource audioSource;
    public AudioClip NurseCallSE;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    
    
        void OnTriggerEnter(Collider other)
        {

            if (other.gameObject.tag == "Player")
            {
                Debug.Log("aa");
                audioSource.PlayOneShot(NurseCallSE);
            }
        }
    
}

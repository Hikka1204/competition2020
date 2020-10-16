using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tenteki_Yobi : MonoBehaviour
{
    private Tentekibou tenteki;
    float currenttime = 3.0f;
    float t_time = 0.0f;
    AudioSource audioSource;
    public AudioClip TentekibouSE;

    void Start()
    {
        tenteki = GetComponent<Tentekibou>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            tenteki.enabled = true;
            audioSource.PlayOneShot(TentekibouSE);
        }
    }
}

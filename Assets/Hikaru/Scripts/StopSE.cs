﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopSE : MonoBehaviour
{

    private AudioSource Audio;
    [SerializeField] private byte _fmgFlg = 1;
    [SerializeField] private FlgManeger fmg;
    private bool colflg = false;

    // Start is called before the first frame update
    void Start()
    {
        Audio = gameObject.GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Audio.clip != null && colflg == true && Input.GetKeyDown("e"))
        {
            Audio.Stop();
            fmg.GetFlg(_fmgFlg);
            Destroy(gameObject.GetComponent<StopSE>());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Hand")
        {
            colflg = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Hand")
        {
            colflg = false;
        }
    }
}

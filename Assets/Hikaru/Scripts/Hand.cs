﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField] AudioClip _PickUp;
    byte keyFlg;    //キーのフラグ　数字で制御
    private bool colflg;
    private GameObject Keyg;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = transform.root.root.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (colflg == true && Input.GetKeyDown("e"))
        {
            keyFlg = Keyg.gameObject.GetComponent<Key1>().GetKey();

            audioSource.clip = _PickUp;
            audioSource.Play();
            colflg = false;
            Destroy(Keyg.gameObject);
        }
    }

    public byte GetKey()
    {
        return keyFlg;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Key")
        {
            colflg = true;
            Keyg = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Key")
        {
            colflg = false;
            Keyg = null;
        }
    }


}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class EventCallKey : MonoBehaviour
{

    [SerializeField] private GameObject _EventCallKey_staging_enemy;
    [SerializeField] CharacterController _p_Chara;
    [SerializeField] FirstPersonController _p_Fir;
    [SerializeField] GlitchEffect _p_CameraGl;
    [SerializeField] private EventCamera _eventCamera;
    [SerializeField] private float _Event_CameraTime = 5;
    private bool isEvent = false;
    // Start is called before the first frame update
    void Start()
    {
        isEvent = false;
    }

    private void OnEnable()
    {
        if (isEvent)
        {
            isEvent = false;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(isEvent == false)
        {
            isEvent = true;
            StartCoroutine("Event");
        }
    }

    IEnumerator Event()
    {
        _EventCallKey_staging_enemy.SetActive(false);
        _p_CameraGl.enabled = true;
        _p_Chara.enabled = false;
        _p_Fir.enabled = false;
        yield return new WaitForSeconds(0.5f); //待つ
        _EventCallKey_staging_enemy.SetActive(true);
        yield return new WaitForSeconds(0.5f); //待つ
        _p_CameraGl.enabled = false;
        _eventCamera.enabled = true;
        _eventCamera.CameraNum(3);
        yield return new WaitForSeconds(_Event_CameraTime); //待つ
        _eventCamera.CameraStop();
        _p_Chara.enabled = true;
        _p_Fir.enabled = true;
        gameObject.SetActive(false);
        yield break;
    }

}

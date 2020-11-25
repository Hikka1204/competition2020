﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class EventExit1 : MonoBehaviour
{

    [SerializeField] private GameObject _enemy;
    [SerializeField] private Vector3 _spawnPo;
    [SerializeField] CharacterController _p_Chara;
    [SerializeField] FirstPersonController _p_Fir;
    [SerializeField] EventCamera _p_CameraObject;
    [SerializeField] GlitchEffect _p_CameraGl;
    [SerializeField] private float _eventRate = 2f;
    private float EventTime;


    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        if (EventTime > 0)
        {
            EventTime -= Time.deltaTime;
            _enemy.GetComponent<Nav_Enemy_Scarecrow>().GetPlayer(true);
            if (EventTime <= 0)
            {
                _p_CameraObject.CameraStop();
                _p_CameraObject.enabled = false;
                _p_CameraGl.enabled = false;
                _p_Chara.enabled = true;
                _p_Fir.enabled = true;
                //Destroy(gameObject);
                gameObject.SetActive(true);
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _enemy.SetActive(false);
            _enemy.transform.position = _spawnPo;
            _p_CameraObject.enabled = true;
            _p_CameraObject.CameraNum(0);
            _p_CameraGl.enabled = true;
            _p_Chara.enabled = false;
            _p_Fir.enabled = false;
            EventTime = _eventRate;
            _enemy.SetActive(true);
        }

    }

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.gameObject.tag == "Player")
    //    {
    //        _enemy.SetActive(false);
    //        _enemy.transform.position = _spawnPo;
    //        _p_CameraObject.enabled = true;
    //        _p_CameraGl.enabled = true;
    //        _p_Chara.enabled = false;
    //        _p_Fir.enabled = false;
    //        EventTime = _eventRate;
    //        _enemy.SetActive(true);
    //    }
    //}

}

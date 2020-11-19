using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Event_Op : MonoBehaviour
{
    private bool isNear;    //　ドアエリアに入っているかどうか
    private bool isEvent;   //Eventが起きたかどうか
    private AudioSource audioSource;
    [SerializeField] private float _eventRate = 2f;
    private float EventTime;
    [SerializeField] private GameObject WallDes;    //消す壁
    [SerializeField] private GameObject Event_Op_room;
    void Start()
    {
        isNear = false;
        isEvent = false;
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
    }

    private void OnDestroy()
    {
        Event_Op_room.SetActive(true);
    }


    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player" || col.gameObject.tag == "Hand")
        {
            isNear = true;
            return;
        }

    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player" || col.gameObject.tag == "Hand")
        {
            isNear = false;
            return;
        }
    }
}

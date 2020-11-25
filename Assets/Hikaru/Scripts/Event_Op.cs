using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Event_Op : MonoBehaviour
{
    [SerializeField] private GameObject Event_Op_room;

    void Start()
    {

    }

    void Update()
    {

    }

    private void OnDisable()
    {
        Event_Op_room.SetActive(true);
    }

}

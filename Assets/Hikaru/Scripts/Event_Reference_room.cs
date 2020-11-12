using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_Reference_room : MonoBehaviour
{
    [SerializeField] private GameObject[] Shelf = new GameObject[7];
    [SerializeField] private byte _fmgFlg = 5;
    [SerializeField] private FlgManeger fmg;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            AddForce();
        }
    }

    private void AddForce()
    {
        for(int i = 0; i < Shelf.Length; i++)
        {
            GameObject child7 = Shelf[i].gameObject.transform.GetChild(7).gameObject;
            GameObject child8 = Shelf[i].gameObject.transform.GetChild(8).gameObject;
            for(int j = 0; j < 5; j++)
            {
                child7.transform.GetChild(j).gameObject.GetComponent<BlowOff>().enabled = true;
                child8.transform.GetChild(j).gameObject.GetComponent<BlowOff>().enabled = true;
            }
            Shelf[i].gameObject.GetComponent<BlowOff>().enabled = true;
        }
        fmg.GetFlg(_fmgFlg);
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand_Spawn : MonoBehaviour {

    [SerializeField] private GameObject hand;

    private float RandomDestroyReat;
    private float DestroyTime;
   

	// Use this for initialization
	void Start () {
        //hand = gameObject.transform.GetChild(0).gameObject;
        hand.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            hand.gameObject.SetActive(true);
        }

        RandomDestroyReat = 0;
    }

}

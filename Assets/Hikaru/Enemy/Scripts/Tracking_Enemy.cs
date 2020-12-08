using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tracking_Enemy : MonoBehaviour
{

    [SerializeField] private Nav_Enemy_Scarecrow parent;

    private bool playerflg = false;

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
        

        if (playerflg == false && other.gameObject.tag == "Player_Body_Tracking")
        {
            parent.GetPlayer(0);
            playerflg = true;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (playerflg == true && other.gameObject.tag == "Player_Body_Tracking")
        {
            parent.GetPlayer(1);
            playerflg = false;
        }
    }

}

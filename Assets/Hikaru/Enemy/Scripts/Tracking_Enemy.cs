using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tracking_Enemy : MonoBehaviour
{

    [SerializeField] private Nav_Enemy_Scarecrow parent;

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
        if (other.gameObject.tag == "Player_Body_Tracking")
        {
            parent.GetPlayer(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player_Body_Tracking")
        {
            parent.GetPlayer(false);
        }
    }

}

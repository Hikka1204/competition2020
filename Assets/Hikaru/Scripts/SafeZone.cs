using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeZone : MonoBehaviour
{

    [SerializeField] private GameObject Body;
    
    [SerializeField] private GameObject Enemy;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Body.SetActive(false);
            Enemy.GetComponent<Nav_Enemy_Scarecrow>().GetPlayer(2);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Body.SetActive(true);
        }
    }
}

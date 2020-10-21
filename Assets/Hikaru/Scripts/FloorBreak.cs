using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class FloorBreak : MonoBehaviour
{
    private AudioSource audio;

    private void Start()
    {
        //gameObject.SetActive(false);
        audio = GetComponent<AudioSource>();
    }

    public void destroyObject()
    {
        
        var random = new System.Random();
        var min = -3;
        var max = 3;
        gameObject.GetComponentsInChildren<Rigidbody>().ToList().ForEach(r => {
            r.gameObject.SetActive(true);
            r.isKinematic = false;
            r.transform.SetParent(null);
            r.gameObject.AddComponent<AutoDestroy>().time = 2f;
            var vect = new Vector3(random.Next(min, max), random.Next(0, max), random.Next(min, max));
            r.AddForce(vect, ForceMode.Impulse);
            r.AddTorque(vect, ForceMode.Impulse);
        });
        audio.Play();
        Destroy(gameObject);
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            for (int i = 0; i < gameObject.transform.childCount; i++)
            {
                gameObject.transform.GetChild(i).gameObject.SetActive(true);
            }
            destroyObject();
        }
    }


}

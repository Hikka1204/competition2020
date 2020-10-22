using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit_Over : MonoBehaviour
{

    private UnityStandardAssets.Characters.FirstPerson.FirstPersonController FirstPerson;
    private CameraObject cameraobject;

    // Start is called before the first frame update
    void Start()
    {
        FirstPerson = GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>();
        cameraobject = transform.GetChild(0).gameObject.GetComponent<CameraObject>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            FirstPerson.enabled = false;
            cameraobject.enabled = true;
        }
            
    }
}
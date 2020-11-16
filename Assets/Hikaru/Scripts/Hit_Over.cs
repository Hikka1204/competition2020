using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit_Over : MonoBehaviour
{

    private UnityStandardAssets.Characters.FirstPerson.FirstPersonController FirstPerson;
    private EventCamera cameraobject;
    [SerializeField] GameObject Over_UI;  //ゲームオーバーUI


    // Start is called before the first frame update
    void Start()
    {
        FirstPerson = GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>();
        cameraobject = transform.GetChild(0).gameObject.GetComponent<EventCamera>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Over_UI.SetActive(true);
            FirstPerson.enabled = false;
            cameraobject.enabled = true;
            cameraobject.CameraNum(0);
        }
            
    }
}
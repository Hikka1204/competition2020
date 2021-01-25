using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit_Over : MonoBehaviour
{

    private UnityStandardAssets.Characters.FirstPerson.FirstPersonController FirstPerson;
    private EventCamera cameraobject;
    //[SerializeField] GameObject Over_UI;  //ゲームオーバーUI
    [SerializeField] GlitchEffect _p_CameraGl;
    [SerializeField] private GameObject CanvasOver;
    [SerializeField] private GameObject SandStorm;


    // Start is called before the first frame update
    void Start()
    {
        FirstPerson = GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>();
        cameraobject = transform.GetChild(0).gameObject.GetComponent<EventCamera>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKey(KeyCode.R)) Over_UI.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            //Over_UI.SetActive(true);
            FirstPerson.enabled = false;
            cameraobject.enabled = true;
            cameraobject.CameraNum(0);
            StartCoroutine(OverEvent());

        }
            
    }

    IEnumerator OverEvent()
    {
        yield return new WaitForSeconds(0.5f); //待つ
        _p_CameraGl.enabled = true;
        yield return new WaitForSeconds(1.0f); //待つ
        CanvasOver.SetActive(true);
        Cursor.visible = true;
        SandStorm.SetActive(true);

        yield break;
    }


}
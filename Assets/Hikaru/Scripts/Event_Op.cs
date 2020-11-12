using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Event_Op : MonoBehaviour
{
    private bool isNear;    //　ドアエリアに入っているかどうか
    private bool isEvent;   //Eventが起きたかどうか
    private AudioSource audioSource;
    [SerializeField] private float _eventRate = 2f;
    private float EventTime;
    [SerializeField] private GameObject AddForce_Rubble;    //がれき
    [SerializeField] private GameObject WallDes;    //消す壁
    //[SerializeField] private Vector3 _enemy_Spawn_Position;
    //[SerializeField] private GameObject _enemy;
    //[SerializeField] CharacterController _p_Chara;
    //[SerializeField] FirstPersonController _p_Fir;
    //[SerializeField] EventCamera _p_CameraObject;
    //[SerializeField] GlitchEffect _p_CameraGl;
    //[SerializeField] AudioClip _keyOutSE;

    void Start()
    {
        isNear = false;
        isEvent = false;
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        //if (Input.GetKeyDown("e") && isNear)
        //{   //eキーが押されたらEventを始める
        //    AddForce_Rubble.SetActive(true);
        //    Destroy(WallDes);
        //}
        
        
        //if (EventTime > 0)
        //{
        //    EventTime -= Time.deltaTime;
        //    _enemy.GetComponent<Nav_Enemy_Scarecrow>().GetPlayer(true);
        //    if (EventTime <= 0)
        //    {
        //        _p_CameraObject.CameraStop();
        //        _p_CameraObject.enabled = false;
        //        _p_CameraGl.enabled = false;
        //        _p_Chara.enabled = true;
        //        _p_Fir.enabled = true;
        //        gameObject.GetComponent<DoorMove>().enabled = true;
        //    }
        //}

            //if (Input.GetKeyDown("e") && isNear && isEvent == false)    //eキーが押されたらEventを始める
            //{
            //    isEvent = true;
            //    _enemy.SetActive(true);
            //    _enemy.transform.position = _enemy_Spawn_Position;
            //    _p_CameraObject.enabled = true;
            //    _p_CameraObject.CameraNum(0);
            //    _p_CameraGl.enabled = true;
            //    _p_Chara.enabled = false;
            //    _p_Fir.enabled = false;
            //    EventTime = _eventRate;
            //}
    }

    private void OnDestroy()
    {
        AddForce_Rubble.SetActive(true);
        Destroy(WallDes);
    }


    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player" || col.gameObject.tag == "Hand")
        {
            isNear = true;
            return;
        }

    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player" || col.gameObject.tag == "Hand")
        {
            isNear = false;
            return;
        }
    }
}

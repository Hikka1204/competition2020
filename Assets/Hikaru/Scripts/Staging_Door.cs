using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Staging_Door : MonoBehaviour
{

    
    private bool isNear = false;    //　ドアエリアに入っているかどうか
    private bool isEvent = false;   //Eventが起きたかどうか
    private AudioSource audioSource;
    [SerializeField] private float _eventRate = 2f;
    private float EventTime;
    [SerializeField] private Vector3 _enemy_Spawn_Position;
    [SerializeField] private GameObject _enemy;
    [SerializeField] CharacterController _p_Chara;
    [SerializeField] FirstPersonController _p_Fir;
    [SerializeField] EventCamera _p_CameraObject;
    [SerializeField] GlitchEffect _p_CameraGl;
    [SerializeField] AudioClip _keyOutSE;

    void Start()
    {
        isNear = false;
        isEvent = false;
        audioSource = GetComponent<AudioSource>();
        gameObject.GetComponent<DoorMove>().enabled = false;
    }

    public void Respawn()
    {
        isNear = false;
        isEvent = false;
        gameObject.GetComponent<DoorMove>().enabled = false;
    }


    void Update()
    {
        if(EventTime > 0)
        {
            EventTime -= Time.deltaTime;
            _enemy.GetComponent<Nav_Enemy_Scarecrow>().GetPlayer(0);
            if (EventTime <= 0)
            {
                _p_CameraObject.CameraStop();
                _p_CameraObject.enabled = false;
                _p_CameraGl.enabled = false;
                _p_Chara.enabled = true;
                _p_Fir.enabled = true;
                gameObject.GetComponent<DoorMove>().enabled = true;
            }
        }

        if (Input.GetKeyDown("e") && isNear && isEvent == false)    //eキーが押されたらEventを始める
        {
            isEvent = true;
            _enemy.SetActive(true);
            _enemy.transform.position = _enemy_Spawn_Position;
            _p_CameraObject.enabled = true;
            _p_CameraObject.CameraNum(0);
            _p_CameraGl.enabled = true;
            _p_Chara.enabled = false;
            _p_Fir.enabled = false;
            EventTime = _eventRate;
        }
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class EventExit1 : MonoBehaviour
{

    [SerializeField] private GameObject _enemy;
    [SerializeField] private Vector3 _spawnPo;
    [SerializeField] CharacterController _p_Chara;
    [SerializeField] FirstPersonController _p_Fir;
    [SerializeField] EventCamera _eventCamera;
    [SerializeField] GlitchEffect _p_CameraGl;
    [SerializeField] private float _eventRate = 2f;
    [SerializeField] private byte _cameraNum = 7;
    [SerializeField] private GameObject EventExit;
    private float EventTime;
    private bool isEvent = false;

    // Start is called before the first frame update
    void Start()
    {
        isEvent = false;
    }
    private void OnEnable()
    {
        isEvent = false;
    }


    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (isEvent == false && other.gameObject.tag == "Player")
        {
            isEvent = true;
            EventExit.SetActive(false);
            StartCoroutine("Event");
        }

    }

    IEnumerator Event()
    {
        _enemy.SetActive(false);
        _p_CameraGl.enabled = true;
        _p_Chara.enabled = false;
        _p_Fir.enabled = false;
        yield return new WaitForSeconds(0.5f); //待つ
        _enemy.transform.position = _spawnPo;
        _enemy.SetActive(true);
        yield return new WaitForSeconds(0.2f); //待つ
        _enemy.GetComponent<Nav_Enemy_Scarecrow>().GetPlayer(true);
        _p_CameraGl.enabled = false;
        _eventCamera.enabled = true;
        _eventCamera.CameraNum(_cameraNum);
        yield return new WaitForSeconds(3.0f); //待つ
        _eventCamera.CameraStop();
        _p_Chara.enabled = true;
        _p_Fir.enabled = true;
        gameObject.SetActive(false);
        yield break;
    }

}

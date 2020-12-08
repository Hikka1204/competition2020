using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Event_First : MonoBehaviour
{
    [SerializeField] private GameObject _Staging_enemy; //エネミー
    [SerializeField] CharacterController _p_Chara;  //プレイヤーキャラクター
    [SerializeField] FirstPersonController _p_Fir;  //カメラ
    [SerializeField] GlitchEffect _p_CameraGl;  //カメラエフェクト
    [SerializeField] private EventCamera _eventCamera;  //イベントカメラ
    [SerializeField] private Zoom zoom;
    [SerializeField] private float EventTime = 5f;
    [SerializeField] private byte CameraNum = 4;
    [SerializeField] private GameObject EventFirst;

    private bool isEvent;

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
        if (other.gameObject.tag == "Player" && !isEvent)
        {
            isEvent = true;
            StartCoroutine("Event");
            EventFirst.SetActive(false);
        }
    }

    IEnumerator Event()
    {
        _Staging_enemy.SetActive(false);
        _p_CameraGl.enabled = true;
        _p_Chara.enabled = false;
        _p_Fir.enabled = false;
        yield return new WaitForSeconds(0.5f); //待つ
        _Staging_enemy.SetActive(true);
        zoom.Zoomflg = true;
        yield return new WaitForSeconds(0.2f); //待つ
        _p_CameraGl.enabled = false;
        _eventCamera.enabled = true;
        _eventCamera.CameraNum(CameraNum);
        yield return new WaitForSeconds(EventTime); //待つ
        _eventCamera.CameraStop();
        _p_Chara.enabled = true;
        _p_Fir.enabled = true;
        gameObject.SetActive(false);
        yield break;
    }


}

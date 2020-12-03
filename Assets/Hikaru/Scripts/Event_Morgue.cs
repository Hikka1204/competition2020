using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Event_Morgue : MonoBehaviour
{
    [SerializeField] private GameObject _enemy; //エネミー
    [SerializeField] private Vector3 _spawnPo;  //エネミースポーンのポジション
    [SerializeField] CharacterController _p_Chara;  //プレイヤーキャラクター
    [SerializeField] FirstPersonController _p_Fir;  //カメラ
    [SerializeField] GlitchEffect _p_CameraGl;  //カメラエフェクト
    [SerializeField] private EventCamera _eventCamera;  //イベントカメラ

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
        _enemy.GetComponent<Nav_Enemy_Scarecrow>().SetForeverTracking(true);
        _p_CameraGl.enabled = false;
        _eventCamera.enabled = true;
        _eventCamera.CameraNum(9);
        yield return new WaitForSeconds(1.5f); //待つ
        _eventCamera.CameraStop();
        _p_Chara.enabled = true;
        _p_Fir.enabled = true;
        gameObject.SetActive(true);
        yield break;
    }


}

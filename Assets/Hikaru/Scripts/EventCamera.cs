using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class EventCamera : MonoBehaviour
{
    [SerializeField] private GameObject _enemyCamera; // 注視したいオブジェクトをInspectorから入れておく
    [SerializeField] private GameObject _eventRote; // 注視したいオブジェクトをInspectorから入れておく
    [SerializeField] private GameObject _Reference_Enemy_Camera; // 注視したいオブジェクトをInspectorから入れておく
    [SerializeField] private GameObject _EventCallKey_Enemy_Camera;
    [SerializeField] private GameObject _StagingEnemy_Camera;
    public float speed = 0.1f;  // 補完スピードを決める
    private bool isEvent = false;
    private float firstRo;
    private float cameraRo = 0f;
    private GameObject targetObject;
    [SerializeField] GameObject FPSController;
    Camera FirstPersonCamera;
    [SerializeField] FirstPersonController fir;

    private void Start()
    {
        //isEvent = false;
        FirstPersonCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (isEvent == true)
        {
            // ターゲット方向のベクトルを取得
            Vector3 relativePos = targetObject.transform.position - this.transform.position;
            // 方向を、回転情報に変換
            Quaternion rotation = Quaternion.LookRotation(relativePos);
            // 現在の回転情報と、ターゲット方向の回転情報を補完する
            transform.rotation = Quaternion.Slerp(this.transform.rotation, rotation, speed);
        }
    }

    public void CameraNum(int a)
    {
        fir.isEventCamera = true;
        switch (a)
        {
            case 0: //更衣室の前
                firstRo = -145f;
                cameraRo = 1f;
                targetObject = _enemyCamera;
                isEvent = true;
                break;
            case 1: //診察室のノート
                firstRo = -124f;
                cameraRo = -6f;
                targetObject = _eventRote;
                isEvent = true;
                break;
            case 2: //資料室
                firstRo = -1f;
                cameraRo = 2f;
                targetObject = _Reference_Enemy_Camera;
                isEvent = true;
                break;
            case 3: //一番最初のイベント
                firstRo = 18f;
                cameraRo = 0f;
                targetObject = _EventCallKey_Enemy_Camera;
                isEvent = true;
                break;
            case 4: //  stagingEnemy 正規ルート
                firstRo = -79f;
                cameraRo = 0f;
                targetObject = _StagingEnemy_Camera;
                isEvent = true;
                break;
            case 5: //  stagingEnemy 違うルート
                firstRo = -3f;
                cameraRo = 0f;
                targetObject = _StagingEnemy_Camera;
                isEvent = true;
                break;
            case 6: //手術室のエネミー
                firstRo = 13f;
                cameraRo = 3.5f;
                targetObject = _enemyCamera;
                isEvent = true;
                break;
            case 7: //階段横からのエネミー
                firstRo = -145f;
                cameraRo = 1f;
                targetObject = _enemyCamera;
                isEvent = true;
                break;
            case 8: //階段中央からのエネミー
                firstRo = -90f;
                cameraRo = 2f;
                targetObject = _enemyCamera;
                isEvent = true;
                break;
            case 9: //階段中央からのエネミー
                firstRo = -269f;
                cameraRo = 3f;
                targetObject = _enemyCamera;
                isEvent = true;
                break;
        }
    }

    public bool GetEvent()
    {
        return isEvent;
    }

    public float GetChaRotation()
    {
        return transform.rotation.y;
    }

    public float GetCamRotation()
    {
        return transform.rotation.x;
    }

    public void CameraStop()
    {
        FirstPersonCamera = Camera.main;
        isEvent = false;
        fir.m_MouseLook.EventLookRotation(FPSController.transform, FirstPersonCamera.transform, firstRo, cameraRo);
        fir.isEventCamera = false;

        gameObject.GetComponent<EventCamera>().enabled = false;
    }

}

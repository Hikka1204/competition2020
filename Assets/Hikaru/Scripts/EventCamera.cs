using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventCamera : MonoBehaviour
{
    [SerializeField] private GameObject _enemyCamera; // 注視したいオブジェクトをInspectorから入れておく
    [SerializeField] private GameObject _eventRote; // 注視したいオブジェクトをInspectorから入れておく
    public float speed = 0.1f;  // 補完スピードを決める
    private bool isEvent = false;
    private GameObject targetObject;

    private void Start()
    {
        //isEvent = false;
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
        switch (a)
        {
            case 0:
                targetObject = _enemyCamera;
                isEvent = true;
                break;
            case 1:
                targetObject = _eventRote;
                isEvent = true;
                break;
        }
    }
    public void CameraStop()
    {
        isEvent = false;
        gameObject.GetComponent<EventCamera>().enabled = false;
    }

}

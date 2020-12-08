using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

//ノートオブジェクトのスクリプト　イベント系あり

public class Event_Note_Hand : MonoBehaviour
{
    [SerializeField] private GameObject _pr_camera;
    [SerializeField] private Vector3 FPS_Po = new Vector3(0.0f, 0.0f, 0.47f);
    [SerializeField] private Vector3 FPS_Ro = new Vector3(90.0f, 180.0f, 0.0f);
    [SerializeField] private byte _fmgFlg = 4;
    [SerializeField] private FlgManeger fmg;
    [SerializeField] CharacterController _p_Chara;
    [SerializeField] FirstPersonController _p_Fir;
    [SerializeField] private GameObject _exampleOb;
    [SerializeField] private EventCamera _eventCamera;
    [SerializeField] private int _eventObnum;
    private Vector3 InitPo;
    private bool isNear;
    private bool isFPS;
    private bool isEventFlg;

    // Start is called before the first frame update
    void Start()
    {
        InitPo = gameObject.transform.position;
        isNear = false;
        isFPS = false;
        isEventFlg = false;
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("e") && isNear)    //eキーが押されたら開くか閉まる
        {
            isFPS = true;
            isNear = false;
            _p_Chara.enabled = false;
            _p_Fir.enabled = false;
            gameObject.transform.parent = _pr_camera.gameObject.transform;
            gameObject.transform.localPosition = FPS_Po;
            gameObject.transform.localRotation = Quaternion.Euler(FPS_Ro.x, FPS_Ro.y, FPS_Ro.z);
            gameObject.GetComponent<MaterialChange>().StopCo();
        }

        else if (Input.GetKeyDown("e") && isFPS)
        {
            isFPS = false;
            isNear = true;
            _p_Chara.enabled = true;
            _p_Fir.enabled = true;
            gameObject.transform.parent = null;
            gameObject.transform.position = new Vector3(InitPo.x, InitPo.y, InitPo.z);
            gameObject.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
            gameObject.GetComponent<MaterialChange>().StartCo();
            if (isEventFlg == false)
            {
                fmg.GetFlg(_fmgFlg);
                isEventFlg = true;
                StartCoroutine("Event");
            }
        }


    }

    IEnumerator Event()
    {
        //yield return new WaitForSeconds(0.5f); //待つ
        _p_Chara.enabled = false;
        _p_Fir.enabled = false;
        _eventCamera.enabled = true;
        _eventCamera.CameraNum(1);
        yield return new WaitForSeconds(1.0f); //待つ
        FlagManager.Instance.Co_Event[5] = true; // イベントコメント表示
        _exampleOb.GetComponent<Example>().enabled = true;
        yield return new WaitForSeconds(5.0f); //待つ
        _eventCamera.CameraStop();
        _p_Chara.enabled = true;
        _p_Fir.enabled = true;
        Destroy(_exampleOb);

        yield break;
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
        }
    }

}

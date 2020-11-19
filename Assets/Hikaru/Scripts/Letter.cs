using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

//手紙の処理 イベント

public class Letter : MonoBehaviour
{

    [SerializeField] private GameObject _pr_camera;
    [SerializeField] private Vector3 FPS_Po = new Vector3(0.0f,0.0f,0.47f);
    [SerializeField] private Vector3 FPS_Ro = new Vector3(90.0f, 180.0f, 0.0f);
    [SerializeField] private byte _fmgFlg = 3;
    [SerializeField] private FlgManeger fmg;
    [SerializeField] CharacterController _p_Chara;
    [SerializeField] FirstPersonController _p_Fir;
    [SerializeField] private GameObject key;
    [SerializeField] private GameObject key1;
    private Vector3 InitPo;
    private Quaternion InitRo;
    private bool isNear;
    private bool isFPS;
    private bool isEventFlg;

    // Start is called before the first frame update
    void Start()
    {
        InitPo = gameObject.transform.position;
        InitRo = gameObject.transform.rotation;
        isNear = false;
        isFPS = false;
        isEventFlg = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("e") && isNear)    //取る
        {
            isFPS = true;
            isNear = false;
            _p_Chara.enabled = false;
            _p_Fir.enabled = false;
            gameObject.transform.parent = _pr_camera.gameObject.transform;
            gameObject.transform.localPosition = FPS_Po;
            gameObject.transform.localRotation = Quaternion.Euler(FPS_Ro.x, FPS_Ro.y, FPS_Ro.z);
            gameObject.GetComponent<MaterialChange>().StopCo();
            if (isEventFlg == false)
            {
                fmg.GetFlg(_fmgFlg);
                isEventFlg = true;
                key.gameObject.GetComponent<MaterialEmiChange>().enabled = true;
                key.gameObject.GetComponent<BoxCollider>().enabled = true;
                key1.gameObject.GetComponent<MaterialEmiChange>().enabled = true;
                key1.gameObject.GetComponent<BoxCollider>().enabled = true;
            }

        }

        else if (Input.GetKeyDown("e") && isFPS)
        {
            isFPS = false;
            isNear = true;
            _p_Chara.enabled = true;
            _p_Fir.enabled = true;
            gameObject.transform.parent = null;
            gameObject.transform.position = new Vector3(InitPo.x, InitPo.y, InitPo.z);
            gameObject.transform.rotation = InitRo;
            gameObject.GetComponent<MaterialChange>().StartCo();
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
        }
    }
}

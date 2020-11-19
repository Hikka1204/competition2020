using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.FirstPerson;

public class FlgManeger : MonoBehaviour
{
    private int flg = 0;
    //[SerializeField] private GameObject _EnemyObject;   //エネミー
    //flg 1
    [SerializeField] private GameObject _Uketuke_eve;   //地下室へ誘導するテキスト
    [SerializeField] private GameObject _Changing_room_rust_key;    //更衣室のカギ
    [SerializeField] private AudioSource _keyAudio;     //鍵の音
    //flg 2
    [SerializeField] private GameObject _floor65_Des;  //デストロイする床
    [SerializeField] private GameObject _breakFloor; //壊れるオブジェクトの追加
    [SerializeField] private GameObject _exitDoorOpenSE;    //離れたらドアが開く音を鳴らすオブジェクト
    [SerializeField] private GameObject _stagingEnemy;  //演出用エネミー
    [SerializeField] private GameObject _Examination_room_rust_key; //診察室のカギ
    [SerializeField] private GameObject _Stairs_rust_key; //階段のカギ
    [SerializeField] private GameObject _letter;        //手紙
    //flg 3
    [SerializeField] private GameObject _Reference_room_rust_key;   //資料室のカギ
    [SerializeField] private GameObject _EnterEvent;     //範囲外に出た時
    [SerializeField] private GameObject _NoteOb;        //ノートオブジェクト
    //flg 4
    [SerializeField] private GameObject _cameraRoll;     //カメラ回す用オブジェクト イベントに使う
    [SerializeField] private GameObject _bloodHandP;    //血の手の親オブジェクト
    [SerializeField] private GameObject _Event_Enter_Reference_room;    //資料室のイベント
    //flg 5
    [SerializeField] private GameObject _Operating_room_rust_key; //手術室のカギ
    [SerializeField] private GameObject _operating_room_lighting1;  //手術室の点灯
    [SerializeField] private GameObject _operating_room_lighting2;  //手術室の点灯
    //flg 6
    [SerializeField] private GameObject _Morgue_rust_key; //霊安室のカギ
    //flg 7
    [SerializeField] private GameObject _Emergency_exit_rust_key; //非常口のカギ
    //flg 8
    [SerializeField] private GameObject _EnemySpawn_P;  //エネミーのスポーンの親

    //リスタートするとき
    [SerializeField] private GameObject _enemy;
    [SerializeField] private Vector3[] _enemySpawnPo = new Vector3[8];
    [SerializeField] private GameObject _FPSController;
    [SerializeField] private Vector3[] _PlayerSpawnPo = new Vector3[8];
    [SerializeField] CharacterController _p_Chara;
    [SerializeField] FirstPersonController _p_Fir;
    [SerializeField] GlitchEffect _p_CameraGl;
    [SerializeField] private EventCamera _eventCamera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.R)) PlayerSpawn();
    }

    public void GetFlg(int gflg)
    {
        if(flg < gflg)
        {
            flg = gflg;
            InitObject();
        }
        
    }

    private void InitObject()
    {
        switch (flg)
        {
            case 1: //音を止めた時
                _Changing_room_rust_key.gameObject.SetActive(true);
                _keyAudio.Play();
                _Uketuke_eve.gameObject.SetActive(true);
                break;
            case 2: //更衣室の鍵を拾った時
                _breakFloor.gameObject.SetActive(true);
                _exitDoorOpenSE.gameObject.SetActive(true);
                _stagingEnemy.gameObject.SetActive(true);
                _Examination_room_rust_key.gameObject.SetActive(true);
                _Stairs_rust_key.gameObject.SetActive(true);
                _letter.gameObject.SetActive(true);
                Destroy(_floor65_Des);
                break;
            case 3: //更衣室の手紙を読んだ時
                _Reference_room_rust_key.SetActive(true);
                _EnterEvent.gameObject.SetActive(true);
                _NoteOb.gameObject.SetActive(true);
                break;
            case 4: //診察室のノートを読んだ時
                _cameraRoll.gameObject.SetActive(true);
                _bloodHandP.SetActive(true);
                _Event_Enter_Reference_room.gameObject.SetActive(true);
                break;
            case 5: //資料室でイベントが起きた時
                _Operating_room_rust_key.gameObject.SetActive(true);
                _operating_room_lighting1.GetComponent<op_room_lighting>().enabled = true;
                _operating_room_lighting2.GetComponent<op_room_lighting>().enabled = true;
                break;
            case 6: //手術室のカギを取ったら
                _operating_room_lighting1.GetComponent<op_room_lighting>().setIsEvent(true);
                _operating_room_lighting2.GetComponent<op_room_lighting>().setIsEvent(true);
                _Morgue_rust_key.gameObject.SetActive(true);
                break;
            case 7: //霊安室のカギを取ったら
                _Emergency_exit_rust_key.gameObject.SetActive(true);
                break;
            case 8: //非常口のカギを取ったら
                _EnemySpawn_P.SetActive(true);
                break;
            default:
                break;
        }
    }

    public void PlayerSpawn()
    {
        if (_enemy.activeSelf == true)
        {
            _enemy.SetActive(true);
            _enemy.GetComponent<NavMeshAgent>().enabled = true;
            _enemy.transform.position = _enemySpawnPo[flg];
        }
        _p_CameraGl.enabled = false;
        _eventCamera.CameraStop();
        _p_Chara.enabled = true;
        _p_Fir.enabled = true;
        _FPSController.transform.position = _PlayerSpawnPo[flg];
        switch (flg)
        {
            case 0:
                
                break;
            case 1:

                break;
            case 2:

                break;
            case 3:

                break;
            case 4:

                break;
            case 5:

                break;
            case 6:

                break;
            case 7:

                break;
            case 8:

                break;
            default:
                break;
        }
    } 

    IEnumerable Dray()
    {
        yield return new WaitForSeconds(0.2f);
    }

}

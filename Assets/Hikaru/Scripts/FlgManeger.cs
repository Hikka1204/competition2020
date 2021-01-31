using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.FirstPerson;

public class FlgManeger : MonoBehaviour
{
    private int flg = 0;
    private bool floor_flg = false; //壊れる床に触れて落ちたかどうか
    private int desFlg = 0;

    //[SerializeField] private GameObject _EnemyObject;   //エネミー
    //flg 1
    [SerializeField] private GameObject _Uketuke_eve;   //地下室へ誘導するテキスト
    [SerializeField] private GameObject _Changing_room_rust_key;    //更衣室のカギ
    [SerializeField] private AudioSource _keyAudio;     //鍵の音
    //flg 2
    [SerializeField] private GameObject _floor65_Des;  //デストロイする床
    [SerializeField] private GameObject _breakFloor; //壊れるオブジェクトの追加
    [SerializeField] private GameObject _exitDoorOpenSE;    //離れたらドアが開く音を鳴らすオブジェクト
    [SerializeField] private GameObject _Examination_room_rust_key; //診察室のカギ
    [SerializeField] private GameObject _Stairs_rust_key; //階段のカギ
    [SerializeField] private GameObject _letter;        //手紙
    [SerializeField] private GameObject _EventCallKey;  //イベント
    [SerializeField] private GameObject _EventFirst1;   //イベント発生用当たり判定付きオブジェクト
    [SerializeField] private GameObject _EventFirst2;   //イベント発生用当たり判定付きオブジェクト
    [SerializeField] private GameObject _EventChanging_room; //更衣室イベント用
    [SerializeField] private Light_Hint _Cylinder_Changing_room_001;    //更衣室までのライト01
    [SerializeField] private Light_Hint _Cylinder_Changing_room_002;    //更衣室までのライト02

    //flg 3
    [SerializeField] private GameObject _Reference_room_rust_key;   //資料室のカギ
    [SerializeField] private GameObject _EnterEvent1;     //範囲外に出た時
    [SerializeField] private GameObject _EnterEvent2;     //範囲外に出た時
    [SerializeField] private GameObject _NoteOb;        //ノートオブジェクト
    [SerializeField] private Light_Hint _Cylinder_Examination_room001;    //診察室までのライト01
    [SerializeField] private Light_Hint _Cylinder_Examination_room002;    //診察室までのライト02
    //flg 4
    [SerializeField] private GameObject _cameraRoll;     //カメラ回す用オブジェクト イベントに使う
    [SerializeField] private GameObject _bloodHandP;    //血の手の親オブジェクト
    [SerializeField] private GameObject _Event_Enter_Reference_room;    //資料室のイベント
    [SerializeField] private Light_Hint _Cylinder_Reference_room001;    //資料室までのライト01
    [SerializeField] private Light_Hint _Cylinder_Reference_room002;    //資料室までのライト02

    //flg 5
    [SerializeField] private GameObject _Operating_room_rust_key; //手術室のカギ
    [SerializeField] private GameObject _operating_room_lighting1;  //手術室の点灯
    [SerializeField] private GameObject _operating_room_lighting2;  //手術室の点灯
    //flg 6
    [SerializeField] private GameObject _Morgue_rust_key; //霊安室のカギ

    //flg 7
    [SerializeField] private GameObject _ZoneOP;
    [SerializeField] private GameObject _Emergency_exit_rust_key; //非常口のカギ
    [SerializeField] private Light_Hint Cylinder_Morgue_light_001;    //霊安室までのライト01
    [SerializeField] private Light_Hint Cylinder_Morgue_light_002;    //霊安室までのライト02
    [SerializeField] private Light_Hint Cylinder_Morgue_light_003;    //霊安室までのライト03
    [SerializeField] private Light_Hint Cylinder_Morgue_light_004;    //霊安室までのライト04

    //flg 8
    [SerializeField] private GameObject _EnemySpawn_P;  //エネミーのスポーンの親
    [SerializeField] private GameObject _SafeZone;

    //リスタートするとき
    [SerializeField] private GameObject _enemy;
    [SerializeField] private Vector3[] _enemySpawnPo = new Vector3[9];
    [SerializeField] private GameObject _FPSController;
    [SerializeField] private Vector3[] _PlayerSpawnPo = new Vector3[9];
    [SerializeField] private Vector3 _PlayerSpawnPo_FloorFlg;
    [SerializeField] CharacterController _p_Chara;
    [SerializeField] FirstPersonController _p_Fir;
    [SerializeField] GlitchEffect _p_CameraGl;
    [SerializeField] private EventCamera _eventCamera;
    [SerializeField] private Hand _hand;
    [SerializeField] private GameObject AddForce_Rubble;
    [SerializeField] private GameObject WallDes;    //消す壁

    //血痕
    [SerializeField] private GameObject Event1;
    [SerializeField] private GameObject Event2;
    [SerializeField] private GameObject Event3;
    [SerializeField] private GameObject Event4;
    [SerializeField] private GameObject Event5;
    [SerializeField] private GameObject Event6;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_enemy.GetComponent<Nav_Enemy_Scarecrow>().Get_Over_Flg() && Input.GetKey(KeyCode.R))
        {
            PlayerSpawn();
        }
    }

    public void FloorBreak_getFlg()
    {
        floor_flg = true;
    }

    public void GetFlg(int gflg)    //他のオブジェクトからのフラグの取得
    {
        if(flg < gflg)
        {
            flg = gflg;
            desFlg = gflg;
            InitObject();   //フラグによるオブジェクトの表示非表示
        }
        
    }

    private void InitObject()   //フラグによるオブジェクトの表示非表示
    {
        switch (flg)
        {
            case 1: //音を止めた時
                _Changing_room_rust_key.gameObject.SetActive(true);
                _keyAudio.Play();
                _Uketuke_eve.gameObject.SetActive(true);
                break;
            case 2: //更衣室の鍵を拾った時
                for (int i = 0; i < 2; i++)
                {
                    Event1.SetActive(false);
                    Event2.SetActive(true);
                    _breakFloor.gameObject.SetActive(true);
                    _exitDoorOpenSE.gameObject.SetActive(true);
                    _EventFirst1.gameObject.SetActive(true);
                    _EventFirst2.gameObject.SetActive(true);
                    _Examination_room_rust_key.gameObject.SetActive(true);
                    _Stairs_rust_key.gameObject.SetActive(true);
                    _letter.gameObject.SetActive(true);
                    _EventCallKey.SetActive(true);
                    _EventChanging_room.SetActive(true);
                    _Cylinder_Changing_room_001.StartLight();
                    _Cylinder_Changing_room_002.StartLight();
                    //Destroy(_floor65_Des);
                    _floor65_Des.SetActive(false);
                }
                break;
            case 3: //更衣室の手紙を読んだ時
                Event2.SetActive(false);
                Event3.SetActive(true);
                FlagManager.Instance.Status = 1;
                _Reference_room_rust_key.gameObject.SetActive(true);
                _EnterEvent1.gameObject.SetActive(true);
                _EnterEvent2.gameObject.SetActive(true);
                _NoteOb.gameObject.SetActive(true);
                //_Cylinder_Changing_room_001.StopLight();
                _Cylinder_Changing_room_002.StopLight();
                _Cylinder_Examination_room001.StartLight();
                _Cylinder_Examination_room002.StartLight();
                break;
            case 4: //診察室のノートを読んだ時
                Event3.SetActive(false);
                Event4.SetActive(true);
                _cameraRoll.gameObject.SetActive(true);
                _bloodHandP.SetActive(true);
                _Event_Enter_Reference_room.gameObject.SetActive(true);
                _Cylinder_Changing_room_001.StopLight();
                _Cylinder_Examination_room001.StopLight();
                _Cylinder_Examination_room002.StopLight();
                _Cylinder_Reference_room001.StartLight();
                _Cylinder_Reference_room002.StartLight();
                break;
            case 5: //資料室でイベントが起きた時
                Event4.SetActive(false);
                Event5.SetActive(true);
                FlagManager.Instance.Status = 2;
                _Operating_room_rust_key.gameObject.SetActive(true);
                _operating_room_lighting1.GetComponent<op_room_lighting>().enabled = true;
                _operating_room_lighting2.GetComponent<op_room_lighting>().enabled = true;
                _Cylinder_Reference_room001.StopLight();
                _Cylinder_Reference_room002.StopLight();
                break;
            case 6: //手術室のカギを取ったら
                FlagManager.Instance.Eventroop = false;
                _Morgue_rust_key.gameObject.SetActive(true);
                break;
            case 7: //霊安室のカギを取ったら
                Event5.SetActive(false);
                Event6.SetActive(true);
                FlagManager.Instance.Eventroop = true;
                _Emergency_exit_rust_key.gameObject.SetActive(true);
                _ZoneOP.SetActive(false);
                _operating_room_lighting1.GetComponent<op_room_lighting>().setIsEvent(true);
                _operating_room_lighting2.GetComponent<op_room_lighting>().setIsEvent(true);
                Cylinder_Morgue_light_001.StartLight();
                Cylinder_Morgue_light_002.StartLight();
                Cylinder_Morgue_light_003.StartLight();
                Cylinder_Morgue_light_004.StartLight();
                break;
            case 8: //非常口のカギを取ったら
                Event6.SetActive(true);
                FlagManager.Instance.Eventroop = false;
                _EnemySpawn_P.SetActive(true);

                _SafeZone.SetActive(false);
                Cylinder_Morgue_light_001.StopLight();
                Cylinder_Morgue_light_002.StopLight();
                Cylinder_Morgue_light_003.StopLight();
                Cylinder_Morgue_light_004.StopLight();
                break;
            default:
                break;
        }
    }

    public void PlayerSpawn()
    {
        if (_enemy.activeSelf == true)
        {
            _enemy.GetComponent<NavMeshAgent>().enabled = false;
            _enemy.SetActive(true);
            _enemy.transform.position = _enemySpawnPo[flg];
            _enemy.GetComponent<NavMeshAgent>().enabled = true;
            _enemy.GetComponent<Nav_Enemy_Scarecrow>().Respawn();
        }
        _p_CameraGl.enabled = false;
        _eventCamera.CameraStop();
        _p_Chara.enabled = true;
        _p_Fir.enabled = true;
        if (flg == 2 && floor_flg)
        {
            _FPSController.transform.position = _PlayerSpawnPo_FloorFlg;
        }
        else
        {
            if(flg == desFlg)
                _FPSController.transform.position = _PlayerSpawnPo[flg];
            else if(flg == desFlg) _FPSController.transform.position = _PlayerSpawnPo[flg + 1];
        }

        StartCoroutine(ObjectRe());
        
    }

    IEnumerator ObjectRe()
    {
        yield return new WaitForSeconds(0.5f); //待つ
        switch (flg)
        {
            case 0:

                break;
            case 1://音を止めた時

                break;
            case 2://更衣室の鍵を拾った時
                _EventChanging_room.SetActive(true);
                _Stairs_rust_key.gameObject.SetActive(true);
                //for(int i = 0; i < 2; i++)
                //{
                //    //_Changing_room_rust_key.gameObject.SetActive(true);
                //    //_floor65_Des.SetActive(true);
                //    _breakFloor.gameObject.SetActive(false);
                //    _exitDoorOpenSE.gameObject.SetActive(false);
                //    _EventFirst1.gameObject.SetActive(false);
                //    _EventFirst2.gameObject.SetActive(false);
                //    _Examination_room_rust_key.gameObject.SetActive(false);
                //    _Stairs_rust_key.gameObject.SetActive(false);
                //    _letter.gameObject.SetActive(false);
                //    _enemy.SetActive(false);
                //    _hand.SetKey(0);
                //    flg = 1;
                //}
                break;
            case 3://更衣室の手紙を読んだ時
                _Changing_room_rust_key.gameObject.SetActive(true);
                _Stairs_rust_key.gameObject.SetActive(true);
                _EnterEvent1.gameObject.SetActive(false);
                _EnterEvent2.gameObject.SetActive(false);
                if (flg != desFlg) break;
                _hand.SetKey(1);
                flg = 2;
                break;
            case 4://診察室のノートを読んだ時
                _Reference_room_rust_key.gameObject.SetActive(true);
                if (flg != desFlg) break;
                _hand.SetKey(3);
                flg = 3;
                break;
            case 5://資料室でイベントが起きた時
                _Operating_room_rust_key.gameObject.SetActive(true);
                if (flg != desFlg) break;
                //_hand.SetKey(4);
                flg = 4;
                break;
            case 6://手術室のカギを取ったら
                _Operating_room_rust_key.gameObject.SetActive(true);
                if (flg != desFlg) break;
                _hand.SetKey(4);
                flg = 5;
                break;
            case 7://霊安室のカギを取ったら
                _Morgue_rust_key.gameObject.SetActive(true);
                AddForce_Rubble.SetActive(false);
                WallDes.SetActive(true);
                if (flg != desFlg) break;
                _hand.SetKey(5);
                flg = 6;
                break;
            case 8://非常口のカギを取ったら
                if (flg != desFlg) break;
                _hand.SetKey(6);
                flg = 7;
                break;
            default:

                break;
        }
        yield break;
    }

    public void ObjectFlgActive()
    {
        _Changing_room_rust_key.gameObject.SetActive(true);
        _Examination_room_rust_key.gameObject.SetActive(true);
        _Stairs_rust_key.gameObject.SetActive(true);
        _letter.gameObject.SetActive(true);
        _Reference_room_rust_key.gameObject.SetActive(true);
        _NoteOb.gameObject.SetActive(true);
        _Event_Enter_Reference_room.gameObject.SetActive(true);
        _Operating_room_rust_key.gameObject.SetActive(true);
        _Morgue_rust_key.gameObject.SetActive(true);
        _Emergency_exit_rust_key.gameObject.SetActive(true);
        _EventChanging_room.SetActive(true);
    }

}
